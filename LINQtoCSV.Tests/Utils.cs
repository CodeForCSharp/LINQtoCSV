namespace LINQtoCSV.Tests
{
    public static class Utils
    {
        public static string NormalizeString(string s)
        {
            return s?.Replace("\r\n", "\n");
        }
    }
}