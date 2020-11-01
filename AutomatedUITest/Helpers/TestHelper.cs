using System.IO;
using System.Reflection;

namespace AutomatedUITest.Helpers
{
    public static class TestHelper
    {
        public static string BinFolder => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}
