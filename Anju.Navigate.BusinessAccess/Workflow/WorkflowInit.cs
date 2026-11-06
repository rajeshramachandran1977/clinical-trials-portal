using System;
using System.Reflection;
using System.Xml.Linq;
using Anju.Navigate.Utilities;
using OptimaJet.Workflow.Core.Builder;
using OptimaJet.Workflow.Core.Bus;
using OptimaJet.Workflow.Core.Persistence;
using OptimaJet.Workflow.Core.Runtime;
using OptimaJet.Workflow.DbPersistence;

namespace Anju.Navigate.BusinessAccess.Workflow
{
    public static class WorkflowInit
    {
        private static readonly Lazy<WorkflowRuntime> LazyRuntime = new Lazy<WorkflowRuntime>(InitWorkflowRuntime);

        public static WorkflowRuntime Runtime => LazyRuntime.Value;

        private static WorkflowRuntime InitWorkflowRuntime()
        {
            var dbProvider = new MSSQLProvider(ConfigValues.DBConnection);

            var builder = new WorkflowBuilder<XElement>(
                dbProvider,
                new OptimaJet.Workflow.Core.Parser.XmlWorkflowParser(),
                dbProvider
            );

            var runtime = new WorkflowRuntime()
                .WithBuilder(builder)
                .WithActionProvider(new ActionProvider(dbProvider))
                .WithRuleProvider(new RuleProvider(dbProvider))
                .WithPersistenceProvider(dbProvider)
                .WithTimerManager(new TimerManager())
                .WithBus(new NullBus())
                .EnableCodeActions()
                .SwitchAutoUpdateSchemeBeforeGetAvailableCommandsOn()
                .RegisterAssemblyForCodeActions(Assembly.GetExecutingAssembly())
                .Start();

            //TODO: Update Email PlugIn
            //var plugin = new OptimaJet.Workflow.Core.Plugins.BasicPlugin();
            ////Settings for SendEmail actions
            //plugin.Setting_Mailserver = "smtp.yourserver.com";
            //plugin.Setting_MailserverPort = 25;
            //plugin.Setting_MailserverFrom = "from@yourserver.com";
            //plugin.Setting_MailserverLogin = "login@yourserver.com";
            //plugin.Setting_MailserverPassword = "password";
            //plugin.Setting_MailserverSsl = true;
            //runtime.WithPlugin(plugin);

            runtime.ProcessStatusChanged += runtime_ProcessStatusChanged;
            return runtime;
        }

        private static void runtime_ProcessStatusChanged(object sender, ProcessStatusChangedEventArgs e)
        {
            if (e.NewStatus != ProcessStatus.Idled && e.NewStatus != ProcessStatus.Finalized)
                return;

            if (string.IsNullOrEmpty(e.SchemeCode))
                return;
            Runtime.PreExecuteFromCurrentActivity(e.ProcessId);
        }


    }
}
