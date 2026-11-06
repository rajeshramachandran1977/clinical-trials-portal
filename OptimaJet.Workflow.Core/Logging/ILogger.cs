using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaJet.Workflow.Core.Logging
{
    public interface ILogger : IDisposable
    {
        void Debug(string messageTemplate, params object[] propertyValues);
        void Debug(string messageTemplate);
        void Debug(Exception exception, string messageTemplate);
        void Debug(Exception exception, string messageTemplate, params object[] propertyValues);

        void Error(Exception exception, string messageTemplate, params object[] propertyValues);
        void Error(string messageTemplate);
        void Error(Exception exception, string messageTemplate);
        void Error(string messageTemplate, params object[] propertyValues);

        void Info(string messageTemplate, params object[] propertyValues);
        void Info(Exception exception, string messageTemplate, params object[] propertyValues);
        void Info(Exception exception, string messageTemplate);
        void Info(string messageTemplate);
    }
}
