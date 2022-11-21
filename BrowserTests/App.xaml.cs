using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CSV;

namespace BrowserTests
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void run() { 
            var reader = new Reader();
            reader.Open(@"C:\Users\河口怜和人\source\repos\browser-test\csv-tests\testdata\test.csv");

            var csv = reader.Get(0);
            Console.WriteLine(csv.Title);
        }
    }
}
