using System;
using UnityEditor.TestTools.TestRunner.Api;

namespace UnityEditor.TestTools.TestRunner.UnityTestProtocol
{
    internal class UnityTestProtocolListener : ICallbacks
    {
        private IUtpMessageReporter m_UtpMessageReporter;

        public UnityTestProtocolListener(string projectPath)
        {
            m_UtpMessageReporter = new UtpMessageReporter(new UtpDebugLogger(), projectPath);
        }

        public void RunStarted(ITestAdaptor testsToRun)
        {
            m_UtpMessageReporter.ReportTestRunStarted(testsToRun);
        }

        public void RunFinished(ITestResultAdaptor testResults)
        {
            m_UtpMessageReporter.ReportRunFinished();
        }

        public void TestStarted(ITestAdaptor test)
        {
            m_UtpMessageReporter.ReportTestStarted(test);
        }

        public void TestFinished(ITestResultAdaptor result)
        {
            m_UtpMessageReporter.ReportTestFinished(result);
        }
    }
}
