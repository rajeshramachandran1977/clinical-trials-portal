using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Anju.Navigate.Utilities
{


    public class SessionManager
    {
        #region Properties
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static readonly object ThreadLock = new object();

        private static SessionManager instance;

        public static SessionManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (ThreadLock)
                    {
                        instance = new SessionManager();
                        return instance;
                    }
                }
                return instance;
            }
        }
        #endregion

        #region Constructor
        private SessionManager()
        {
        }
        #endregion

        #region Method       

        /// <summary>
        /// Remove Session
        /// </summary>
        /// <param name="key"></param>
        public void RemoveSession(string key)
        {
           _httpContextAccessor.HttpContext.Session.Remove(key);
          
        }

        /// <summary>
        /// Remove Session All
        /// </summary>
        public void RemoveSessionAll()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
        }

        /// <summary>
        /// Check Session Exists
        /// </summary>
        /// <param name="key"></param>
        /// <returns>true/false</returns>
        public bool CheckSessionExists(string key)
        {
            if (_httpContextAccessor.HttpContext.Session.GetString(key) != null)
                return true;
            else
                return false;
        }      
        #endregion
    }

    public static class SessionExtensions
    {       
        /// Get Session
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <returns>value</returns>
        public static T GetSession<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        /// <summary>
        /// Set Object As Json
        /// </summary>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        /// <summary>
        /// Get Object From Json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        /// <summary>
        /// Get Complex Data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetComplexData<T>(this ISession session, string key)
        {
            var data = session.GetString(key);
            if (data == null)
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(data);
        }

        /// <summary>
        /// Set Complex Data
        /// </summary>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetComplexData(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
    }

}
