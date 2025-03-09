namespace FileSync
{
    public class ExceptionHandler
    {
        public static void ThrowIfEmpty(string value, string message)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new Exception(message);
            }
        }

        public static void ThrowIfDirectoryDoesNotExist(string path, string message)
        {
            if (!Directory.Exists(path))
            {
                throw new Exception(message);
            }
        }
    }
}
