using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace OptimaJet.Workflow.Core.Runtime
{
    /// <summary>
    /// Base class for all aggregating providers
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseAggregatingProvider<T>
    {
        private ReaderWriterLockSlim _readerWriterLock = new ReaderWriterLockSlim();

        private const string UniversalName = "*";

        private int _cnt = 0;

        private Dictionary<string, SortedDictionary<int, T>> _providers =
            new Dictionary<string, SortedDictionary<int, T>>() {{UniversalName, new SortedDictionary<int, T>()}};

        protected IEnumerable<T> GetOrderedProviders(string schemeCode)
        {
            return GetProviders(schemeCode).Reverse();
        }

        protected IEnumerable<T> GetProviders(string schemeCode)
        {
            _readerWriterLock.EnterReadLock();
            try
            {
                if ((!String.IsNullOrEmpty(schemeCode)) && (_providers.ContainsKey(schemeCode)))
                {
                    SortedDictionary<int, T> providersForScheme = _providers[schemeCode];
                    SortedDictionary<int, T> providersForAll = _providers[UniversalName];
                    var result = new SortedDictionary<int, T>();

                    foreach (KeyValuePair<int, T> keyValuePair in providersForScheme)
                    {
                        result.Add(keyValuePair.Key, keyValuePair.Value);
                    }

                    foreach (KeyValuePair<int, T> keyValuePair in providersForAll)
                    {
                        result.Add(keyValuePair.Key, keyValuePair.Value);
                    }

                    return result.Values;
                }
                else
                {
                    return _providers[UniversalName].Values;
                }
            }
            finally
            {
                _readerWriterLock.ExitReadLock();
            }
        }

        public void RegisterProvider(T provider, List<string> schemes = null)
        {
            _readerWriterLock.EnterWriteLock();
            try
            {
                _cnt++;
                int newIdx = _cnt;


                if (schemes == null || !schemes.Any())
                {
                    _providers[UniversalName].Add(newIdx, provider);
                }
                else
                {
                    foreach (var scheme in schemes)
                    {
                        if (_providers.ContainsKey(scheme))
                        {
                            _providers[scheme].Add(newIdx, provider);
                        }
                        else
                        {
                            _providers.Add(scheme, new SortedDictionary<int, T>() {{newIdx, provider}});
                        }
                    }
                }
            }
            finally
            {
                _readerWriterLock.ExitWriteLock();
            }
        }

        public void Clear()
        {
            _readerWriterLock.EnterWriteLock();
            try
            {
                _providers = new Dictionary<string, SortedDictionary<int, T>>() {{UniversalName, new SortedDictionary<int, T>()}};
            }
            finally
            {
                _readerWriterLock.ExitWriteLock();
            }
        }
    }
}
