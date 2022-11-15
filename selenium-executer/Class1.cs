using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumExecuter
{
    public class BrowserTest
    {
        private string url;
        public BrowserTest(string url, Settings settings) {

        }
        
        public void Open(string url)
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Close();
        }

        public void Opens(string[] urls) { 
            new DriverManager().SetUpDriver(new ChromeConfig());
            ChromeDriver driver = new ChromeDriver();
            foreach (string url in urls) {
                driver.Navigate().GoToUrl(url);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            }
            driver.Close();
        }

        public void test(ChromeDriver driver)
        {

            String name = "itemOption[354432][tachikawa-blind-larc-double][%E6%93%8D%E4%BD%9C%E6%96%B9%E6%B3%95]";
            IWebElement selectBox = driver.FindElement(By.Name(name));
            selectBox.SendKeys("プルコード操作");
            IWebElement color1 = driver.FindElement(By.Name("itemOption[354432][tachikawa-blind-larc-double][%E5%AE%A4%E5%86%85%EF%BC%88%E6%89%8B%E5%89%8D%EF%BC%89%E5%81%B4%E7%94%9F%E5%9C%B0]"));
            color1.SendKeys("RS-8821");
            IWebElement color2 = driver.FindElement(By.Name("itemOption[354432][tachikawa-blind-larc-double][%E5%AE%A4%E5%A4%96%EF%BC%88%E5%A5%A5%EF%BC%89%E5%81%B4%E7%94%9F%E5%9C%B0]"));
            color1.SendKeys("RS-8821");
            IWebElement cartButton = driver.FindElement(By.CssSelector(".rug input[type=\"submit\"]"));
            IWebElement t = driver.FindElement(By.ClassName("haisouchui"));
            new Actions(driver)
                .MoveToElement(t)
                .Pause(TimeSpan.FromSeconds(1))
                .Click(cartButton).Perform();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IAlert alert = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            alert.Accept();
        }
    }
}
