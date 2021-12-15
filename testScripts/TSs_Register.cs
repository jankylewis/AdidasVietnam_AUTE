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

namespace AdidasVietnam_AUTE.testScripts
{
    internal class TSs_Register : AbstractClass.AbstractTest
    {

        internal RegisterPage register;
        internal LogInPage logIn;
        internal readonly String browser = "chrome";

        internal readonly By LBL_FIRST_NAME_REQUIRED_ERR_MSG_LOCATOR =
            By.XPath("//div[contains(@data-auto-id, 'firstname-field-error')]");
        internal readonly By LBL_LAST_NAME_REQUIRED_ERR_MSG_LOCATOR =
            By.XPath("//div[contains(@data-auto-id, 'lastname-field-error')]");
        internal readonly By LBL_DOB_REQUIRED_ERR_MSG_LOCATOR =
            By.XPath("//div[@id= 'date-of-birth']//div[contains(text(), 'the date you entered is not valid')]");
        internal readonly By LBL_GENDER_REQUIRED_ERR_MSG_LOCATOR =
            By.XPath("//div[@role= 'radiogroup']//div[contains(@class, 'error')]");

            

        [SetUp]
        public void beforeTestCase()
        {
            initializeTestCase(browser);
            Console.WriteLine("\n\n-\n\n //---**--------  TRIGGER WEB BROWSER ---**--------// \n\n-\n\n");
        }

        [TearDown]
        public void afterTestCase()
        {
            pauseWithThreadSleep(1500);
            tearDownTestCase();
            Console.WriteLine("\n\n-\n\n //---**--------  TERMINATED THE TEST CASE ---**--------// \n\n-\n\r");
        }

        [Test]
        public void registerTest001()
        {
            register = new RegisterPage(driver);
            logIn = new LogInPage(driver);
            logIn.clickOnLogInLbl();
            Console.WriteLine("\n //------**----------- CLICKED ON LOGIN LABEL -----------**-------// \n");
            register.clickOnGoToRegistrationBtn();
            Console.WriteLine("\n //------**----------- CLICKED ON GO TO REGISTRATION BUTTON -----------**-------// \n");
            Console.WriteLine("\n //------**----------- LEFT BLANK TO FIRST NAME FIELD -----------**-------// \n");
            Console.WriteLine("\n //------**----------- LEFT BLANK TO LAST NAME FIELD -----------**-------// \n");
            Console.WriteLine("\n //------**----------- LEFT BLANK TO DAY OF BIRTH FIELD -----------**-------// \n");
            Console.WriteLine("\n //------**----------- LEFT BLANK TO MONTH OF BIRTH FIELD -----------**-------// \n");
            Console.WriteLine("\n //------**----------- LEFT BLANK TO YEAR OF BIRTH FIELD -----------**-------// \n");
            Console.WriteLine("\n //------**----------- LEFT BLANK TO EMAIL FIELD -----------**-------// \n");
            Console.WriteLine("\n //------**----------- LEFT BLANK TO PASSWORD FIELD -----------**-------// \n");
            Console.WriteLine("\n //------**----------- LEFT BLANK PRIVACY NOTICE CHECKBOX -----------**-------// \n");
            Console.WriteLine("\n //------**----------- LEFT BLANK FIRST EXPLICIT CONSENT CHECKBOX -----------**-------// \n");
            Console.WriteLine("\n //------**----------- LEFT BLANK SECOND EXPLICIT CONSENT CHECKBOX -----------**-------// \n");
            register.clickOnRegisterBtn();
            Console.WriteLine("\n //------**----------- CLICKED ON REGISTER BUTTON -----------**-------// \n");



        }

    }
}
