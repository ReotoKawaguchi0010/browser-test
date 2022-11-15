using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSVTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var reader = new CSV.Reader();
            reader.Open(@"C:\Users\‰ÍŒû—å˜al\source\repos\browser-test\csv-tests\testdata\test.csv");

            var csv = reader.Get(0);
            System.Console.WriteLine(csv.ItemOptions[0]);

        }
    }
}
