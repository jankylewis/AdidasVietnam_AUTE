using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Edge;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace AdidasVietnam_AUTE.AbstractClass
{
    public abstract class AbstractTest
    {
        public static IWebDriver driver;
        public static Actions actions;
        public static Random randomString = new Random();
        //public static WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, (int)2.5));
        public static void initializeTestCase(String browser)
        {
            if (browser=="chrome")
            {
                System.Environment.SetEnvironmentVariable("webdriver.chrome.driver",
                    @"G:\SELENIUM WITH C#\AdidasVietnam_AUTE\AdidasVietnam_AUTE\drivers\chromedriver_96.exe");
                driver = new ChromeDriver();
            }
            else if (browser != "chrome" && browser == "firefox")
            {
                System.Environment.SetEnvironmentVariable("webdriver.chrome.driver",
                    @"G:\SELENIUM WITH C#\AdidasVietnam_AUTE\AdidasVietnam_AUTE\drivers\geckodriver.exe");
                driver = new FirefoxDriver();
            }
            else if (browser != "chrome" && browser != "firefox"
            && browser == "opera")
            {
                System.Environment.SetEnvironmentVariable("webdriver.chrome.driver",
                    @"G:\SELENIUM WITH C#\AdidasVietnam_AUTE\AdidasVietnam_AUTE\drivers\operadriver.exe");
                driver = new OperaDriver();
            }
            else if (browser != "chrome" && browser != "firefox"
            && browser != "opera" && browser == "edge")
            {
                System.Environment.SetEnvironmentVariable("webdriver.chrome.driver",
                    @"G:\SELENIUM WITH C#\AdidasVietnam_AUTE\AdidasVietnam_AUTE\drivers\msEdge.exe");
                driver = new EdgeDriver();
            }
            driver.Navigate().GoToUrl("https://www.adidas.com.vn/en");
            driver.Manage().Window.Maximize();
        }
        public static void tearDownTestCase()
        {
            if (driver!= null)
            {
                driver.Close();
                driver.Dispose();
                //driver.Manage().Cookies.DeleteAllCookies();
                driver.Quit();
            }
            else
            {
                Console.WriteLine("\n //------**----------- NO DRIVER WAS FOUND! -----------**-------// \n");
                driver.Quit();
            }
        }
        public static void pauseWithThreadSleep(double timeSecond)
        {
            Thread.Sleep((int)timeSecond);
        }
        public static void clickOnElement(IWebElement elementLocator)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementLocator));
            //actions.MoveToElement(elementLocator).Click().Perform();
            elementLocator.Click();
        }
        public static void sendKeyToElement(IWebElement elementLocator, String key)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementLocator));
            if (key != null)
            {
                elementLocator.Clear();
                elementLocator.SendKeys(key);
            }
            else
            {
                Console.WriteLine("\n //------**----------- KEY CANNOT BE EMPTY! -----------**-------// \n");
            }
        }
        public static void pressEnterToElement(IWebElement elementLocator)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementLocator));
            if (elementLocator.Enabled || elementLocator.Displayed)
            {
                elementLocator.SendKeys(Keys.Enter);
            }
        }
        public static String generateRandomString(int length)
        {
            const String chars= "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new String (Enumerable.Repeat(chars, length)
                .Select(str=> str[randomString.Next(str.Length)]).ToArray());
        }
    }
}
