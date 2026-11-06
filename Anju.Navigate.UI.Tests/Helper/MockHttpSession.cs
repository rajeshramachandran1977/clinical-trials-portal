using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Anju.Navigate.UI.Tests.Helper
{
    public class MockHttpSession : ISession
    {
        private readonly Dictionary<string, object> sessionStorage = new Dictionary<string, object>();

        public object this[string name]
        {
            get => sessionStorage[name];
            set => sessionStorage[name] = value;
        }

        string ISession.Id => throw new NotImplementedException();

        bool ISession.IsAvailable => throw new NotImplementedException();

        IEnumerable<string> ISession.Keys => sessionStorage.Keys;

        public void Clear()
        {
            sessionStorage.Clear();
        }

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public Task LoadAsync()
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            sessionStorage.Remove(key);
        }

        public void Set(string key, byte[] value)
        {
            sessionStorage[key] = value;
        }

        public Task LoadAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public Task CommitAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(string key, out byte[] value)
        {
            if (sessionStorage[key] != null)
            {
                value = Encoding.ASCII.GetBytes(sessionStorage[key].ToString());
                return true;
            }

            value = null;
            return false;
        }
    }
}
