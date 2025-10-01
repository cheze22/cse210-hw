// File: Logger.cs
    public static class Logger
    {
        private static readonly string _logFilePath = Path.Combine(Environment.CurrentDirectory, "mindfulness_log.txt");
        public static string LogFilePath => _logFilePath;

        public static void Log(string text)
        {
            try
            {
                File.AppendAllText(_logFilePath, text + Environment.NewLine);
            }
            catch
            {
                // don't crash the app for logging errors
            }
        }
    }