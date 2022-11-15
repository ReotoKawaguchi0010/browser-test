using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumExecuterTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var url = "https://stepline.jp/item/354432.html";
            var settings = new SeleniumExecuter.Settings();
            var v = new SeleniumExecuter.BrowserTest(url, settings);
            v.Open(url);
        }
    }
}
