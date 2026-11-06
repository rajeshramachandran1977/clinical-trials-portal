using System;
using System.Collections.Generic;
using System.Text;

namespace Anju.Navigation.Utilities
{
    public interface ICacheManager
    {
        T GetCache<T>(string key);

        void SetCache(string key, object value);

        void RemoveCache(string key);

        void ClearCache();
    }
}
