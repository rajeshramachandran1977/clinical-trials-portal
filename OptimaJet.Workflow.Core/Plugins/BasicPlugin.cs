using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OptimaJet.Workflow.Core.Model;
using OptimaJet.Workflow.Core.Persistence;
using OptimaJet.Workflow.Core.Runtime;

namespace OptimaJet.Workflow.Core.Plugins
{
    public delegate Task<IEnumerable<string>> UsersInRoleAsyncDelegate(string roleName, Guid? processId = null);

    public class BasicPlugin : IWorkflowPlugin, IWorkflowActionProvider, IWorkflowRuleProvider, IDesignerAutocompleteProvider, IDesignerParameterFormatProvider
    {
        public virtual string Name { get => "Workflow Basic Operations"; }
        protected Dictionary<string, string> _pluginSettings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        public Dictionary<string, string> PluginSettings { get => _pluginSettings; }
        public Dictionary<string, string> RequestHeaders = new Dictionary<string, string>();
        public char ConditionIsApprovedSeparatedChar = ';';
        public List<string> ExcludeOperations = new List<string>();

        public BasicPlugin()
        {
            
        }
        
        public BasicPlugin(Dictionary<string, string> pluginSettings)
        {            
            foreach(var p in pluginSettings)
            {
                _pluginSettings.Add(p.Key, p.Value);
            }
        }

        public void OnPluginAdd(WorkflowRuntime runtime)
        {
            
        }

        public void OnPluginRemove(WorkflowRuntime runtime)
        {
            
        }
        
        #region Plugin settings names
        
        public static readonly string SettingName_Mailserver = "MailServer";
        public static readonly string SettingName_MailserverPort = "MailServerPort";
        public static readonly string SettingName_MailserverFrom = "MailServerFrom";
        public static readonly string SettingName_MailserverLogin = "MailServerLogin";
        public static readonly string SettingName_MailserverPassword = "MailServerPass";
        public static readonly string SettingName_MailserverSsl = "MailServerSsl";
        
        #endregion

        #region Plugin settings accessors

        public string Setting_Mailserver
        {
            get
            {
                _pluginSettings.TryGetValue(SettingName_Mailserver, out string result);
                return result;
            }
            set => _pluginSettings[SettingName_Mailserver] = value;
        }

        public static readonly int SettingDefault_MailserverPort = 25;
        
        public static readonly bool SettingDefault_MailserverSsl = true;
        
        public int Setting_MailserverPort
        {
            get
            {
                if (_pluginSettings.TryGetValue(SettingName_MailserverPort, out string result))
                {
                    if (Int32.TryParse(result, out int intResult))
                    {
                        return intResult;
                    }
                }
                
                return SettingDefault_MailserverPort;
            }
            set => _pluginSettings[SettingName_MailserverPort] = value.ToString();
        }
        public string Setting_MailserverFrom
        {
            get
            {
                _pluginSettings.TryGetValue(SettingName_MailserverFrom, out string result);
                return result;
            }
            set => _pluginSettings[SettingName_MailserverFrom] = value;
        }
        
        public string Setting_MailserverLogin
        {
            get
            {
                _pluginSettings.TryGetValue(SettingName_MailserverLogin, out string result);
                return result;
            }
            set => _pluginSettings[SettingName_MailserverLogin] = value;
        }
        
        public string Setting_MailserverPassword
        {
            get
            {
                _pluginSettings.TryGetValue(SettingName_MailserverPassword, out string result);
                return result;
            }
            set => _pluginSettings[SettingName_MailserverPassword] = value;
        }
        
        public bool Setting_MailserverSsl
        {
            get
            {
                if (_pluginSettings.TryGetValue(SettingName_MailserverSsl, out string result))
                {
                    return result.ToLower() == "true";
                }

                return SettingDefault_MailserverSsl;
            }
            set => _pluginSettings[SettingName_MailserverSsl] = value.ToLowerCaseString();
        }
        
        #endregion

        #region IWorkflowActionProvider
        public const string Action_SetParameter = "SetParameter";
        public const string Action_HTTPRequest = "HTTPRequest";
        public const string Action_SendEmail = "SendEmail";
        //public const string Action
        public const string Action_CreateProcess = "CreateProcess";
        public const string Action_SetState = "SetState";
        public const string Action_SetActivity = "SetActivity";

        public const string Condition_CheckParameter = "CheckParameter";
        public const string Condition_CheckAllSubprocessesCompleted = "CheckAllSubprocessesCompleted";
        public const string Condition_IsProcessFinish = "IsProcessFinish";
        public const string Condition_IsArrovedByUsers = "IsArrovedByUsers";
        public const string Condition_IsArrovedByRoles = "IsArrovedByRoles";
        public const string Condition_CheckHTTPRequest = "CheckHTTPRequest";
        
        public virtual List<string> GetActions(string schemeCode)
        {
            var actions = new List<string>()
            {
                Action_SetParameter,
                Action_HTTPRequest,
                Action_CreateProcess,
                //Action_SetState,
                //Action_SetActivity,
                Action_SendEmail
            };

            return actions.Where(a=> !ExcludeOperations.Contains(a)).ToList();
        }

        public virtual List<string> GetConditions(string schemeCode)
        {
            var conditions = new List<string>()
            {
                Condition_CheckParameter,
                Condition_CheckAllSubprocessesCompleted,
                Condition_IsProcessFinish,
                Condition_IsArrovedByUsers
            };

            if(UsersInRoleAsync != null)
            {
                conditions.Add(Condition_IsArrovedByRoles);
            }

            conditions.AddRange(new[]
            {
                Condition_CheckHTTPRequest
            });

            return conditions.Where(c => !ExcludeOperations.Contains(c)).ToList();
        }

        public virtual bool IsActionAsync(string name, string schemeCode)
        { 
            if(name == Action_SetParameter)
            {
                return false;
            }
            return true;
        }        

        public virtual void ExecuteAction(string name, ProcessInstance processInstance, WorkflowRuntime runtime, string actionParameter)
        {
            switch (name)
            {
                case Action_SetParameter:
                    ActionSetParameter(processInstance, actionParameter);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public virtual async Task ExecuteActionAsync(string name, ProcessInstance processInstance, WorkflowRuntime runtime, string actionParameter, CancellationToken token)
        {
            switch (name)
            {
                case Action_HTTPRequest:
                    await ActionGenerateHTTPRequest(processInstance, actionParameter).ConfigureAwait(false);
                    break;
                case Action_CreateProcess:
                    await ActionCreateProcess(processInstance, runtime, actionParameter).ConfigureAwait(false);
                    break;
                case Action_SetState:
                    await runtime.SetStateAsync(processInstance.ProcessId, processInstance.IdentityId, processInstance.ImpersonatedIdentityId, actionParameter).ConfigureAwait(false);
                    break;
                case Action_SetActivity:
                    await runtime.SetActivityWithExecutionAsync(processInstance.IdentityId, 
                        processInstance.ImpersonatedIdentityId, 
                        null, 
                        processInstance.ProcessScheme.FindActivity(actionParameter), 
                        processInstance).ConfigureAwait(false);
                    break;
                case Action_SendEmail:
                    await ActionSendEmail(processInstance, actionParameter).ConfigureAwait(false);                    
                    break;

                default:
                    throw new NotImplementedException();
            };
        }

        protected virtual async Task ActionSendEmail(ProcessInstance processInstance, string parameter)
        {
            string server;
            int port = SettingDefault_MailserverPort;
            string from;
            string login;
            string pass;
            bool ssl;

            var actionParams = JsonConvert.DeserializeObject<Dictionary<string, string>>(parameter);
            if (!String.IsNullOrEmpty(Setting_Mailserver))
            {
                server = Setting_Mailserver;
                port = Setting_MailserverPort;
                from = Setting_MailserverFrom;
                login = Setting_MailserverLogin;
                pass = Setting_MailserverPassword;
                ssl = Setting_MailserverSsl;
            }
            else
            {
                server = actionParams.ContainsKey(SettingName_Mailserver) ? actionParams[SettingName_Mailserver] : string.Empty;
                if(actionParams.ContainsKey(SettingName_MailserverPort))
                    int.TryParse(actionParams[SettingName_MailserverPort], out port);

                from = actionParams.ContainsKey(SettingName_MailserverFrom) ? actionParams[SettingName_MailserverFrom] : string.Empty;
                login = actionParams.ContainsKey(SettingName_MailserverLogin) ? actionParams[SettingName_MailserverLogin] : string.Empty;
                pass = actionParams.ContainsKey(SettingName_MailserverPassword) ? actionParams[SettingName_MailserverPassword] : string.Empty;
                ssl = actionParams.ContainsKey(SettingName_MailserverSsl) && actionParams[SettingName_MailserverSsl]?.ToLower() == "true";
            }

            string to = actionParams.ContainsKey("To") ? actionParams["To"] : string.Empty;
            string subject = actionParams.ContainsKey("Subject") ? actionParams["Subject"] : string.Empty;
            string body = actionParams.ContainsKey("Body") ? actionParams["Body"] : string.Empty;
            bool isHtml = actionParams.ContainsKey("IsHTML") && actionParams["IsHTML"]?.ToLower() == "true";

            using (var msg = new MailMessage(from, to, subject, body))
            {
                msg.IsBodyHtml = isHtml;

                using (var smtpClient = new SmtpClient(server, port))
                {
                    if (!string.IsNullOrEmpty(login))
                        smtpClient.Credentials = new NetworkCredential(login, pass);
                    smtpClient.EnableSsl = ssl;
                    await smtpClient.SendMailAsync(msg).ConfigureAwait(false);
                }
            }
        }

        protected virtual async Task ActionCreateProcess(ProcessInstance processInstance, WorkflowRuntime runtime, string parameter)
        {
            var actionParams = JsonConvert.DeserializeObject<Dictionary<string, string>>(parameter);
            string scheme = actionParams.ContainsKey("Scheme") ? actionParams["Scheme"] : null;

            if (string.IsNullOrEmpty(scheme))
                throw new Exception("Not found 'scheme' parameter!");

            var processId = Guid.NewGuid();
            await runtime.CreateInstanceAsync(new CreateInstanceParams(scheme, processId)).ConfigureAwait(false);
        }

        protected virtual async Task ActionGenerateHTTPRequest(ProcessInstance processInstance, string parameter)
        {
            var actionParams = JsonConvert.DeserializeObject<Dictionary<string, string>>(parameter);
            string url = actionParams.ContainsKey("Url") ? actionParams["Url"] : null;
            bool post = actionParams.ContainsKey("Post") && actionParams["Post"]?.ToLower() == "true";
            bool storeResponse = actionParams.ContainsKey("StoreResponse") && actionParams["StoreResponse"]?.ToLower() == "true";

            using (var client = new HttpClient())
            {
                if(RequestHeaders != null)
                {
                    foreach(var header in RequestHeaders){
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                if (post)
                {
                    var postContent = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("processId", processInstance.ProcessId.ToString()),
                        new KeyValuePair<string, string>("scheme", processInstance.SchemeCode)
                    });

                    using (HttpResponseMessage res = await client.PostAsync(url, postContent).ConfigureAwait(false))
                    {
                        if (storeResponse)
                        {
                            using (HttpContent content = res.Content)
                            {
                                string data = await content.ReadAsStringAsync();
                                processInstance.SetParameter(Action_HTTPRequest + "_Result", data);
                            }
                        }
                    }
                }
                else
                {
                    using (HttpResponseMessage res = await client.GetAsync(url).ConfigureAwait(false))
                    {
                        if (storeResponse)
                        {
                            using (HttpContent content = res.Content)
                            {
                                string data = await content.ReadAsStringAsync();
                                processInstance.SetParameter(Action_HTTPRequest + "_Result", data);
                            }
                        }
                    }
                }
            }
        }

        protected virtual void ActionSetParameter(ProcessInstance processInstance, string parameter)
        {
            var actionParams = JsonConvert.DeserializeObject<Dictionary<string, string>>(parameter);
            string par = actionParams.ContainsKey("Parameter") ? actionParams["Parameter"] : string.Empty;
            string value = actionParams.ContainsKey("Value") ? actionParams["Value"] : string.Empty;
            processInstance.SetParameter(par, value, ParameterPurpose.Persistence);
        }

        public virtual bool IsConditionAsync(string name, string schemeCode)
        {
            if (name == Condition_CheckParameter)
            {
                return false;
            }
            return true;
        }

        public virtual bool ExecuteCondition(string name, ProcessInstance processInstance, WorkflowRuntime runtime, string actionParameter)
        {
            var res = false;
            switch (name)
            {
                case Condition_CheckParameter:
                    res = ConditionCheckParameter(processInstance, actionParameter);
                    break;
                default:
                    throw new NotImplementedException();
            };
            return res;
        }

        public virtual async Task<bool> ExecuteConditionAsync(string name, ProcessInstance processInstance, WorkflowRuntime runtime, string actionParameter, CancellationToken token)
        {
            var res = false;
            switch (name)
            {
                case Condition_CheckAllSubprocessesCompleted:
                    res = runtime.CheckAllSubprocessesCompleted(processInstance);
                    break;
                case Condition_IsProcessFinish:
                    if (string.IsNullOrEmpty(actionParameter))
                    {
                        res = await runtime.GetProcessStatusAsync(processInstance.ProcessId).ConfigureAwait(false) == ProcessStatus.Finalized;                        
                    }
                    else
                    {
                        res = await runtime.GetProcessStatusAsync(new Guid(actionParameter)).ConfigureAwait(false) == ProcessStatus.Finalized;
                    }
                    break;
                case Condition_IsArrovedByUsers:
                    res = await ConditionIsApproved(processInstance, runtime, "roles", actionParameter).ConfigureAwait(false);
                    break;
                case Condition_IsArrovedByRoles:
                    res = await ConditionIsApproved(processInstance, runtime, "users", actionParameter).ConfigureAwait(false);
                    break;
                case Condition_CheckHTTPRequest:
                    res = await ConditionGenerateHTTPRequest(processInstance, actionParameter).ConfigureAwait(false);
                    break;

                default:
                    throw new NotImplementedException();
            };
            return res;
        }

        private bool ConditionCheckParameter(ProcessInstance processInstance, string parameter)
        {
            var actionParams = JsonConvert.DeserializeObject<Dictionary<string, string>>(parameter);
            string par = actionParams.ContainsKey("Parameter") ? actionParams["Parameter"] : string.Empty;
            string value = actionParams.ContainsKey("Value") ? actionParams["Value"] : string.Empty;
            return processInstance.GetParameter(par)?.Value?.ToString() == value;
        }

        private async Task<bool> ConditionIsApproved(ProcessInstance processInstance, WorkflowRuntime runtime, string type, string actionParameter)
        {
            if (string.IsNullOrWhiteSpace(actionParameter))
            {
                throw new Exception($"IsApproved: Fill users or roles in parameters using '{ConditionIsApprovedSeparatedChar}' to separate values!");
            }

            var history = await runtime.GetProcessHistoryAsync(processInstance.ProcessId).ConfigureAwait(false);
            var res = false;

            var valueArray = actionParameter.Contains(ConditionIsApprovedSeparatedChar) ? 
                actionParameter.Split(ConditionIsApprovedSeparatedChar) : 
                new []{ actionParameter };

            var values = valueArray.Select(c => c.Trim());
            var users = new List<string>();
            if (type == "roles")
            {
                if (UsersInRoleAsync == null)
                {
                    throw new Exception($"IsApproved: Set UsersInRole property in BasicPlugin class for using roles-based conditions!");
                }
                
                foreach(var role in values)
                {
                    var tmp = await UsersInRoleAsync(role).ConfigureAwait(false);
                    if(tmp?.Count() > 0)
                    {
                        users.AddRange(tmp);
                    }
                }                
            }
            else if (type == "users")
            {
                users = values.ToList();
            }

            foreach (var user in users)
            {
                if (!history.Any(c => c.TransitionClassifier != TransitionClassifier.Reverse &&
                     (c.ExecutorIdentityId == user || c.ActorIdentityId == user)))
                {
                    return false;
                }
            }
            res = true;

            return res;
        }

        protected virtual async Task<bool> ConditionGenerateHTTPRequest(ProcessInstance processInstance, string parameter)
        {
            var actionParams = JsonConvert.DeserializeObject<Dictionary<string, string>>(parameter);
            string url = actionParams.ContainsKey("Url") ? actionParams["Url"] : null;
            bool post = actionParams.ContainsKey("Post") && actionParams["Post"]?.ToLower() == "true";
            bool storeResponse = actionParams.ContainsKey("StoreResponse") && actionParams["StoreResponse"]?.ToLower() == "true";

            using (var client = new HttpClient())
            {
                if (RequestHeaders != null)
                {
                    foreach (var header in RequestHeaders)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                if (post)
                {
                    var postContent = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("processId", processInstance.ProcessId.ToString()),
                        new KeyValuePair<string, string>("scheme", processInstance.SchemeCode)
                    });

                    using (HttpResponseMessage res = await client.PostAsync(url, postContent).ConfigureAwait(false))
                    {
                        if (storeResponse)
                        {
                            using (HttpContent content = res.Content)
                            {
                                string data = await content.ReadAsStringAsync().ConfigureAwait(false);
                                try
                                {
                                    var results = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
                                    foreach (var result in results)
                                    {
                                        processInstance.SetParameter(result.Key, result.Value);
                                    }
                                }
                                catch (Exception ex) { }

                                processInstance.SetParameter(Action_HTTPRequest + "_Result", data);
                            }
                        }
                    }
                }
                else
                {
                    using (HttpResponseMessage res = await client.GetAsync(url).ConfigureAwait(false))
                    {
                        if (storeResponse)
                        {
                            using (HttpContent content = res.Content)
                            {
                                string data = await content.ReadAsStringAsync().ConfigureAwait(false);
                                try
                                {
                                    var results = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
                                    foreach (var result in results)
                                    {
                                        processInstance.SetParameter(result.Key, result.Value);
                                    }
                                }
                                catch (Exception ex) { }

                                processInstance.SetParameter(Action_HTTPRequest + "_Result", data);
                            }
                        }
                    }
                }
            }
            return true;
        }


        #endregion

        #region IWorkflowRuleProvider

        public UsersInRoleAsyncDelegate UsersInRoleAsync;



        public const string Rule_CheckRole = "CheckRole";

        public virtual List<string> GetRules(string schemeCode)
        {
            var rules = new List<string>();

            if (UsersInRoleAsync != null)
                rules.Add(Rule_CheckRole);
            return rules.Where(r => !ExcludeOperations.Contains(r)).ToList();
        }

        public virtual bool Check(ProcessInstance processInstance, WorkflowRuntime runtime, string identityId, string ruleName, string parameter)
        {
            throw new NotImplementedException();
        }
        public virtual async Task<bool> CheckAsync(ProcessInstance processInstance, WorkflowRuntime runtime, string identityId, string ruleName, string parameter, CancellationToken token)
        {
            switch (ruleName)
            {                
                case Rule_CheckRole:
                    return await UsersInRoleAsync(parameter, processInstance.ProcessId).ContinueWith(x => x.Result?.Contains(identityId) == true).ConfigureAwait(false);
            }

            throw new NotImplementedException();
        }

        public virtual IEnumerable<string> GetIdentities(ProcessInstance processInstance, WorkflowRuntime runtime, string ruleName, string parameter)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<string>> GetIdentitiesAsync(ProcessInstance processInstance, WorkflowRuntime runtime, string ruleName, string parameter, CancellationToken token)
        {
            switch (ruleName)
            {
                case Rule_CheckRole:
                    return await UsersInRoleAsync(parameter, processInstance.ProcessId).ContinueWith(x=> x.Result).ConfigureAwait(false);
            }

            throw new NotImplementedException();
        }

        public virtual bool IsCheckAsync(string ruleName, string schemeCode)
        {
            return true;
        }

        public virtual bool IsGetIdentitiesAsync(string ruleName, string schemeCode)
        {
            return true;
        }


        #endregion

        #region IDesigner providers

        public virtual List<string> GetAutocompleteSuggestions(SuggestionCategory category, string value, string schemeCode)
        {
            return null;
        }

        public virtual List<CodeActionParameterDefinition> GetFormat(CodeActionType type, string name, string schemeCode)
        {
            if (type == CodeActionType.Action)
            {
                if (name == Action_SendEmail)
                {
                    var emailFormat = new List<CodeActionParameterDefinition>();
                    if (!_pluginSettings.ContainsKey(SettingName_Mailserver))
                    {
                        emailFormat.AddRange(new[]{
                            new CodeActionParameterDefinition() { Name = SettingName_Mailserver, Type = ParameterType.Text, IsRequired = true },
                            new CodeActionParameterDefinition() { Name = SettingName_MailserverPort, Type = ParameterType.Number, IsRequired = true, DefaultValue = SettingDefault_MailserverPort.ToString() },
                            new CodeActionParameterDefinition() { Name = SettingName_MailserverFrom, Type = ParameterType.Text, IsRequired = true },
                            new CodeActionParameterDefinition() { Name = SettingName_MailserverLogin, Type = ParameterType.Text, IsRequired = false },
                            new CodeActionParameterDefinition() { Name = SettingName_MailserverPassword, Type = ParameterType.Text, IsRequired = false },
                            new CodeActionParameterDefinition() { Name = SettingName_MailserverSsl, Type = ParameterType.Checkbox, IsRequired = true, DefaultValue = SettingDefault_MailserverSsl.ToLowerCaseString() }
                        });
                    }

                    emailFormat.AddRange(new[]{
                        new CodeActionParameterDefinition() { Name = "To", Type = ParameterType.Text, IsRequired = true },
                        new CodeActionParameterDefinition() { Name = "Subject", Type = ParameterType.Text, IsRequired = false },
                        new CodeActionParameterDefinition() { Name = "IsHTML", Type = ParameterType.Checkbox, IsRequired = false },
                        new CodeActionParameterDefinition() { Name = "Body", Type = ParameterType.TextArea, IsRequired = false },
                    });

                    return emailFormat;
                }
                else if (name == Action_CreateProcess)
                {
                    return new List<CodeActionParameterDefinition>() {
                        new CodeActionParameterDefinition() { Name = "Scheme", Type = ParameterType.Text, IsRequired = true },
                    };
                }
                else if (name == Action_SetParameter)
                {
                    return new List<CodeActionParameterDefinition>() {
                        new CodeActionParameterDefinition() { Name = "Parameter", Type = ParameterType.Text, IsRequired = true },
                        new CodeActionParameterDefinition() { Name = "Value", Type = ParameterType.Text, IsRequired = false },
                    };
                }
                else if (name == Action_HTTPRequest)
                {
                    return new List<CodeActionParameterDefinition>() {
                        new CodeActionParameterDefinition() { Name = "Url", Type = ParameterType.Text, IsRequired = true },
                        new CodeActionParameterDefinition() { Name = "Post", Type = ParameterType.Checkbox, IsRequired = false },
                        new CodeActionParameterDefinition() { Name = "StoreResponse", Type = ParameterType.Checkbox, IsRequired = false }
                    };
                }
            }
            else if (type == CodeActionType.Condition)
            {
                if (name == Condition_CheckHTTPRequest)
                {
                    return new List<CodeActionParameterDefinition>() {
                        new CodeActionParameterDefinition() { Name = "Url", Type = ParameterType.Text, IsRequired = true },
                        new CodeActionParameterDefinition() { Name = "Post", Type = ParameterType.Checkbox, IsRequired = false },
                        new CodeActionParameterDefinition() { Name = "ReturnValue", Type = ParameterType.Text, IsRequired = false }
                    };
                }
                else if (name == Condition_CheckParameter)
                {
                    return new List<CodeActionParameterDefinition>() {
                        new CodeActionParameterDefinition() { Name = "Parameter", Type = ParameterType.Text, IsRequired = true },
                        new CodeActionParameterDefinition() { Name = "Value", Type = ParameterType.Text, IsRequired = false },
                    };
                }
            }

            return new List<CodeActionParameterDefinition>();
        }
        #endregion
    }
}
