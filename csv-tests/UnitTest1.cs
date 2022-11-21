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
            reader.Open(@"C:\Users\�͌���a�l\source\repos\browser-test\csv-tests\testdata\test.csv");

            var csv = reader.Get(0);
            Assert.AreEqual(csv.ItemOptions[0].option_name, "�J���[��I��");
        }
    }
}
