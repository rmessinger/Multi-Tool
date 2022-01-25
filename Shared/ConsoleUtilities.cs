namespace Shared
{
    public static class ConsoleUtilities
    {
        public static void Log(string s)
        {
            string prefix = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + " " + (DateTime.Now.Hour < 10 ? "0" : "") +
                DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "." + DateTime.Now.Millisecond + " - ";
            Console.WriteLine(prefix + s);
        }
    }
}