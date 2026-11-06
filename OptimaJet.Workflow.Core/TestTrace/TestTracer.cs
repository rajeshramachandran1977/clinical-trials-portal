using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace OptimaJet.Workflow.Core.TestTrace
{
    public static class TestTracer
    {
        private static readonly ConcurrentStack<string> _run 
            = new ConcurrentStack<string>();

        public static bool Enable { get; set; } = false;

        public static string CurrentTrace => _run.Aggregate((next, prev) => prev + '\n' + next);

        private static Func<string, bool> _labelFilter = null;

        public static void Clear()
        {
            _run.Clear();
        }

        public static void Reset(Func<string, bool> labelFilter)
        {
            Clear();
            _labelFilter = labelFilter;
        }
        public static void Trace(string label)
        {
            if (!Enable)
            {
                return;
            }
            if (_labelFilter?.Invoke(label) == false)
            {
                return;
            }
            _run.Push(label);
        }

        public static void Assert(string expected, Func<string, bool> filter = null)
        {
            Assert(expected.Replace("\r", "").Split('\n').ToArray(), filter);
        }

        public static void Assert(string[] expected, Func<string, bool> filter = null)
        {
            if ((expected==null || expected.Length == 0) && !_run.IsEmpty)
            {
                Throw("Expected trace is empty but records exist");
            }

            foreach (string trace in expected.Reverse())
            {
                if (!_run.TryPop(out string result))
                {
                    Throw("not found record: " + trace);
                }

                if (filter!=null && !filter(trace))
                {
                    continue;
                }

                if (trace != result)
                {
                    Throw($"expected is {trace} but actual is {result}");
                }
            }
        }

        private static void Throw(string msg)
        {
            throw new System.Exception(msg);
        }
    }
}
