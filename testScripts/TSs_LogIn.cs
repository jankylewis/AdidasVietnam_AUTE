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
using NUnit.Framework;
using System.Threading;
using AdidasVietnam_AUTE.pageObjects;

namespace AdidasVietnam_AUTE
{
    public class TSs_LogIn : AbstractClass.AbstractTest
    {
        internal LogInPage logIn;
        internal readonly String browser= "chrome";
        internal readonly By LBL_LOGIN_LOCATOR = By.XPath("//a[contains(normalize-space(text()),'Log in')]");
        internal Boolean checkIfTestCaseIsPassed;
        internal Boolean checkIfTestCaseIsFailed;
        internal Boolean checkIfTestCaseIsSkipped;

        [SetUp]
        public void beforeTestCase()
        {
            initializeTestCase(browser);
            Console.WriteLine("\n\n-\n\n //---**--------  TRIGGER WEB BROWSER ---**--------// \n\n-\n\n");
        }

        [Test]
        public void logInTest001()
        {
            pauseWithThreadSleep(550.5);
            logIn = new LogInPage(driver);
            logIn.clickOnLogInLbl();
            Console.WriteLine("\n //------**----------- CLICKED LOGIN LABEL -----------**-------// \n");
            logIn.clickOnLogInBtn();
            Console.WriteLine("\n //------**----------- CLICKED LOGIN BUTTON -----------**-------// \n");

            pauseWithThreadSleep(1200.0555);
            
        }

        [TearDown]
        public void afterTestCase()
        {
            tearDownTestCase();
            Console.WriteLine("\n\n-\n\n //---**--------  TERMINATED THE TEST CASE ---**--------// \n\n-\n\r");
        }

    }
}