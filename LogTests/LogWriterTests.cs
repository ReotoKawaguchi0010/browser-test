using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace LogTests
{
    [TestClass]
    public class LogWriterTests
    {
        [TestMethod]
        public void LogWriterTest()
        {
            var path = @"C:\Users\�͌���a�l\source\repos\browser-test\LogTests\testdata\test.log";
            var writer = new Log.LogWriter(path);

            var log = new Log.Log(200, "success", "�������܂���");
            writer.Add(log);
            Assert.IsTrue(File.Exists(path));
            File.Delete(path);
        }
    }
}
