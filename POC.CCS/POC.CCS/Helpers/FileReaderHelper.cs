namespace POC.CCS.Helpers
{
    using System.IO;

    public class FileReaderHelper
    {
        public static string ReadJsonFile(string filePath)
        {
            return File.ReadAllText(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), filePath));
        }
    }
}
