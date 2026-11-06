using System;
using Newtonsoft.Json;
using OptimaJet.Workflow.Core.Model;

namespace OptimaJet.Workflow.Core.Runtime
{
    public static class ParametersSerializer
    {
        /// <summary>
        /// Serializer setting for JSON serializer
        /// </summary>
        public static JsonSerializerSettings Settings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        };

        /// <summary>
        /// Provides access to Workflow Engine .NET Persistence Process Parameters serialization mechanism
        /// </summary>
        /// <param name="serializedValue">Serialized value</param>
        /// <param name="parameterType">Parameter type</param>
        /// <returns>Deserialized object</returns>
        public static object Deserialize(string serializedValue, Type parameterType)
        {
            if (parameterType == typeof(DynamicParameter))
            {
                return DynamicParameter.ParseJson(serializedValue);
            }
            return JsonConvert.DeserializeObject(serializedValue, parameterType, Settings);
        }

        /// <summary>
        /// Provides access to Workflow Engine .NET Persistence Process Parameters serialization mechanism
        /// </summary>
        /// <param name="serializedValue">Serialized value</param>
        /// <returns>Deserialized object</returns>
        public static T Deserialize<T>(string serializedValue)
        {
            if (typeof(T) == typeof(DynamicParameter))
            {
                return (T)(DynamicParameter.ParseJson(serializedValue) as object);
            }
            
            return JsonConvert.DeserializeObject<T>(serializedValue, Settings);
        }

        /// <summary>
        /// Provides access to Workflow Engine .NET Persistence Process Parameters deserialization mechanism
        /// </summary>
        /// <param name="value">Parameter value</param>
        /// <param name="parameterType">Parameter type</param>
        /// <returns>Serialized string</returns>
        public static string Serialize(object value, Type parameterType)
        {
            if (value == null)
                return null;

            if (typeof(DynamicParameter) == parameterType)
            {
                return (value as DynamicParameter)?.SerializeToJson();
            }

            return JsonConvert.SerializeObject(value, parameterType, Settings);
        }

        /// <summary>
        /// Provides access to Workflow Engine .NET Persistence Process Parameters deserialization mechanism
        /// </summary>
        /// <param name="value">Parameter value</param>
        /// <returns>Serialized string</returns>
        public static string Serialize(object value)
        {
            if (value == null)
                return null;
            
            if (value is DynamicParameter dynamicParameter)
            {
                return dynamicParameter.SerializeToJson();
            }

            return JsonConvert.SerializeObject(value, Settings);
        }


    }
}
