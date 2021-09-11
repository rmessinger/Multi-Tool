using Framework;

namespace TestHarness.TestObjects
{
    public class LogMessage : Message
    {
        private string logMessage;

        public LogMessage(string output)
        {
            logMessage = output;
        }

        public string getOutput()
        {
            return logMessage;
        }
    }
}
