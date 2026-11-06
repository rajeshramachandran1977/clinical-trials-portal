using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using OptimaJet.Workflow.Core.Runtime;

namespace OptimaJet.Workflow.Core.Model
{
    public class DynamicParameterConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dynamicParameter = value as DynamicParameter;
            if (dynamicParameter == null)
            {
                writer.WriteNull();
            }
            else
            {
                writer.WriteRawValue(dynamicParameter.SerializeToJson());
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.ReadFrom(reader);
            return DynamicParameter.ParseJson(token);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DynamicParameter);
        }
    }

    /// <summary>
    /// Dynamic parameter, properties can be accessed two ways
    /// de["propertyName"] or (de as dynamic).propertyName
    /// Property names are case sensitive
    /// </summary>
    [JsonConverter(typeof(DynamicParameterConverter))]
    public sealed class DynamicParameter : DynamicObject
    {
        private const string DictionaryPropertyName = "Dictionary";
        
        private readonly Dictionary<string, object> _dictionary = new Dictionary<string, object>();
        /// <summary>
        /// Returns dictionary with all properties
        /// </summary>
        public IReadOnlyDictionary<string, object> Dictionary => _dictionary;


        /// <summary>
        /// Creates empty dynamic parameter object
        /// </summary>
        public DynamicParameter() { }

        /// <summary>
        /// Creates initialized dynamic parameter object
        /// </summary>
        public DynamicParameter(Dictionary<string, object> properties)
        {
            if (properties != null)
            {
                _dictionary = properties;
            }
        }


        /// <inheritdoc />
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            string name = binder.Name; //.ToLower();
            return _dictionary.TryGetValue(name, out result);
        }

        /// <inheritdoc />
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            var name = binder.Name; //.ToLower();

            SetProperty(name, value);

            return true;
        }

        /// <summary>
        /// Returns property value
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <returns>Property value</returns>
        public object GetProperty(string propertyName)
        {
            string name = propertyName; //.ToLower();
            _dictionary.TryGetValue(name, out var result);
            return result;
        }

        /// <summary>
        /// Sets property value
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <param name="value">Property value</param>
        public void SetProperty(string propertyName, object value)
        {
            if (!_dictionary.ContainsKey(propertyName))
            {
                _dictionary.Add(propertyName, value);
            }
            else
            {
                _dictionary[propertyName] = value;
            }
        }

        /// <summary>
        /// Indexer for getting property value
        /// </summary>
        /// <param name="propertyName">Property name</param>
        public object this[string propertyName]
        {
            set => SetProperty(propertyName, value);
            get => GetProperty(propertyName);
        }

        /// <summary>
        /// Checks either property exists in the dynamic parameter object or not.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <returns>true if  property exists in the dynamic parameter object.</returns>
        public bool HasProperty(string propertyName)
        {
            return _dictionary.ContainsKey(propertyName);
        }

        public bool IsDictionaryInsteadOfType(out string dictionaryPropertyName)
        {
            dictionaryPropertyName = null;

            if (_dictionary.Count != 1)
                return false;
            KeyValuePair<string,object>? dictionaryProperty = 
                _dictionary
                    .FirstOrNull(kvp => kvp.Key.Equals(DictionaryPropertyName, StringComparison.OrdinalIgnoreCase));
            if (dictionaryProperty?.Value == null || dictionaryProperty.Value.Value.GetType() != typeof(DynamicParameter) )
                return false;

            dictionaryPropertyName = dictionaryProperty.Value.Key;
            return true;
        }


        /// <summary>
        /// Serializes the dynamic parameter object to JSON
        /// </summary>
        /// <returns>JSON string</returns>
        public string SerializeToJson()
        {
            return JsonConvert.SerializeObject(ToSerializableDictionary(), new JsonSerializerSettings() {ContractResolver = new DefaultContractResolver()});
        }

        private Dictionary<string, object> ToSerializableDictionary()
        {
            var result = new Dictionary<string,object>();

            foreach (KeyValuePair<string,object> kvp in _dictionary)
            {
                if (kvp.Value is DynamicParameter dynamicParameter1)
                {
                    result.Add(kvp.Key, dynamicParameter1.ToSerializableDictionary());
                }
                else if (!(kvp.Value is string) && kvp.Value is IEnumerable enumerable)
                {
                    var newListValue = new List<object>();
                    foreach (object obj in enumerable)
                    {
                        if (obj is DynamicParameter dynamicParameter2)
                        {
                            newListValue.Add((dynamicParameter2.ToSerializableDictionary()));
                        }
                        else
                        {
                            newListValue.Add(obj);
                        }
                    }
                    result.Add(kvp.Key, newListValue);
                }
                else
                {
                    result.Add(kvp.Key, kvp.Value);
                }
            }

            return result;
        }

        /// <summary>
        /// Deserializes JSON the result can be casted as dynamic. The result can be simple value (string, int, double etc) or instance of DynamicParameter class
        /// </summary>
        /// <param name="json">JSON string</param>
        /// <returns>Dynamic parameter object</returns>
        public static object ParseJson(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;
            try
            {
                var token = JToken.Parse(json);
                return GetValue(token);
            }
            catch (JsonReaderException e) //processing strings
            {
                return json;
            }
        }
        
        /// <summary>
        /// Deserializes JSON the result can be casted as dynamic. The result can be simple value (string, int, double etc) or instance of DynamicParameter class
        /// </summary>
        /// <param name="jToken">Newtonsoft.JSON JToken object</param>
        /// <returns>Dynamic parameter object</returns>
        public static object ParseJson(JToken jToken)
        {
            return GetValue(jToken);
        }

        /// <summary>
        /// Creates new DynamicParameter instance
        /// </summary>
        /// <returns></returns>
        public static dynamic New()
        {
            return new DynamicParameter();
        }
        
        private static object GetValue(JToken value)
        {
            if (value == null || value.Type == JTokenType.Null)
                return null;
                
            // object valueResult;
                
            if (value is JArray jArray)
            {
                var arrayResult = new List<object>();
                foreach (JToken jToken in jArray)
                {
                    arrayResult.Add(GetValue(jToken));
                }

                return arrayResult;
            }

            if (value is JObject jObject)
            {
                DynamicParameter result = ParseJsonAsDynamicParameterObject(jObject.ToString());
                if (result.IsDictionaryInsteadOfType(out string dictionaryPropertyName))
                {
                    return  result[dictionaryPropertyName];
                }
                else
                {
                    return result;
                }
            }

            if (value.Type == JTokenType.Boolean)
            {
                return value.Value<bool>();
            }
                
            if (value.Type == JTokenType.Float)
            {
                return value.Value<double>();
            }
                
            if (value.Type == JTokenType.Integer)
            {
                long result = value.Value<long>();
                if (result <= Int32.MaxValue && result >= Int32.MinValue)
                {
                    return (int)result;
                }
                return result;
            }
                
            if (value.Type == JTokenType.Date)
            {
                return value.Value<DateTime>();
            }

            if (value.Type == JTokenType.Guid)
            {
                return value.Value<Guid>();
            }

            if (Guid.TryParse(value.ToString(), out Guid parsedGuid))
            {
                return parsedGuid;
            }

            return value.ToString();
        }
        
        /// <summary>
        /// Deserializes the dynamic parameter object from JSON
        /// </summary>
        /// <param name="json">JSON string</param>
        /// <returns>Dynamic parameter object</returns>
        private static DynamicParameter ParseJsonAsDynamicParameterObject(string json)
        {
            Dictionary<string, JToken> props = JsonConvert.DeserializeObject<Dictionary<string, JToken>>(json,ParametersSerializer.Settings);
            
            var result = new DynamicParameter();

            foreach (var prop in props)
            {
                result.SetProperty(prop.Key, GetValue(prop.Value));
            }

            return result;
        }
    }
}
