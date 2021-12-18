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
        //declare object that used to call the funciton from the page object
        internal LogInPage logIn;
        //declare the browser that used to perform testing
        internal readonly String browser= "chrome";
        //initialize check points
        internal Boolean checkIfTestCaseIsPassed;
        internal Boolean checkIfTestCaseIsFailed;
        internal Boolean checkIfTestCaseIsSkipped;
        //declare information fields as text
        internal const String emailErrMsgTxt = "Please enter a valid e-mail address";
        internal const String passwordErrMsgTxt = "Please enter a password";
        internal const String wrongInforErrMsgTxt = "Incorrect email/password – please check and retry";
        internal const String passwordTxt = "flabbergasted ";
        internal const String emailTxt = "chopstick@gmail.com";
        //store locators
        internal readonly By LBL_LOGIN_LOCATOR = 
            By.XPath("//a[contains(normalize-space(text()),'Log in')]");
        internal readonly By LBL_EMAIL_ERR_MSG_LOCATOR =
            By.XPath("//div[@class='gl-vspace ']//ancestor::div[contains(@class, 'required')]//div[contains(@class, 'error')]");
        internal readonly By LBL_PASSWORD_ERR_MSG_LOCATOR =
            By.XPath("//div[@class='gl-vspace']//ancestor::div[contains(@class, 'required')]//div[contains(@class, 'error')]");
        internal readonly By LBL_WRONG_INFORMATION_ERR_MSG_LOCATOR =
            By.XPath("//div[@data-auto-id= 'login-error-message']");
        //test template to set up several actions before each test case
        [SetUp]
        public void beforeTestCase()
        {
            initializeTestCase(browser);
            Console.WriteLine("\n\n-\n\n //---**--------  TRIGGER WEB BROWSER ---**--------// \n\n-\n\n");
        }
        //test template to set up several actions after each test case to close the browser and repel driver
        [TearDown]
        public void afterTestCase()
        {
            tearDownTestCase();
            Console.WriteLine("\n\n-\n\n //---**--------  TERMINATED THE TEST CASE ---**--------// \n\n-\n\r");
        }
        //test case 001
        [Test]
        /* 
        Test case 001:
        - S1: navigate to website
        - S2: navigate to Login site
        - S3: click on Login button
        - S4: assert the error messages are observable 
        => test case is passed or vice versa
         */
        public void logInTest001()
        {
            pauseWithThreadSleep(550.5);
            
            logIn = new LogInPage(driver);
            logIn.clickOnLogInLbl();
            Console.WriteLine("\n //------**----------- CLICKED LOGIN LABEL -----------**-------// \n");
            Console.WriteLine("\n //------**----------- LEFT BLANK TO EMAIL FIELD -----------**-------// \n");
            Console.WriteLine("\n //------**----------- LEFT BLANK TO PASSWORD FIELD -----------**-------// \n");
            logIn.clickOnLogInBtn();
            Console.WriteLine("\n //------**----------- CLICKED LOGIN BUTTON -----------**-------// \n");
            String emailErrMsgGetTxt = driver.FindElement(LBL_EMAIL_ERR_MSG_LOCATOR).Text;
            String passwordErrMsgGetTxt = driver.FindElement(LBL_PASSWORD_ERR_MSG_LOCATOR).Text;
            Console.WriteLine("\n Email error message was present on the website: " + emailErrMsgGetTxt);
            Console.WriteLine("\n Password error message was present on the website: " + passwordErrMsgGetTxt);
            //assert the text on website whether it matches the expected text
            if (emailErrMsgGetTxt== emailErrMsgTxt
                && passwordErrMsgGetTxt== passwordErrMsgTxt)
            {
                this.checkIfTestCaseIsPassed = true;
                if (checkIfTestCaseIsPassed)
                {
                    Console.WriteLine("\n All the error messages were present correctly" +
                                        ". Asserted successfully test case 001! \n");
                    Assert.Pass();
                }
            }
            else
            {
                this.checkIfTestCaseIsFailed = true;
                if (checkIfTestCaseIsFailed)
                {
                    Console.WriteLine("\n All the error messages were present incorrectly" +
                                        ". Asserted unsuccessfully test case 001! \n");
                    Assert.Fail();
                }
            }
            pauseWithThreadSleep(1200.0555);
        }
        //test case 002
        [Test]
        /* 
        Test case 002:
        - S1: navigate to website
        - S2: navigate to Login site
        - S3: input a value to password field
        - S4: click on Login button
        - S5: assert the error message at email field is observable 
        => test case is passed or vice versa
         */
        public void logInTest002()
        {
            pauseWithThreadSleep(550.5);
            //declare the login page object
            logIn = new LogInPage(driver);
            logIn.clickOnLogInLbl();
            Console.WriteLine("\n //------**----------- CLICKED LOGIN LABEL -----------**-------// \n");
            Console.WriteLine("\n //------**----------- LEFT BLANK TO EMAIL FIELD -----------**-------// \n");
            logIn.sendKeyToPasswordTxt(passwordTxt);
            Console.WriteLine("\n //------**----------- SENT TEXT TO PASSWORD FIELD -----------**-------// \n");
            logIn.clickOnLogInBtn();
            Console.WriteLine("\n //------**----------- CLICKED LOGIN BUTTON -----------**-------// \n");
            String emailErrMsgGetTxt = driver.FindElement(LBL_EMAIL_ERR_MSG_LOCATOR).Text;
            Console.WriteLine("\n Email error message was present on the website: " + emailErrMsgGetTxt);
            //assert the text on website whether it matches the expected text
            if (emailErrMsgGetTxt == emailErrMsgTxt)
            {
                this.checkIfTestCaseIsPassed = true;
                if (checkIfTestCaseIsPassed)
                {
                    Console.WriteLine("\n The error message was present correctly" +
                                        ". Asserted successfully test case 002! \n");
                    Assert.Pass();
                }
            }
            else
            {
                this.checkIfTestCaseIsFailed = true;
                if (checkIfTestCaseIsFailed)
                {
                    Console.WriteLine("\n The error message was present incorrectly" +
                                        ". Asserted unsuccessfully test case 002! \n");
                    Assert.Fail();
                }
            }
            pauseWithThreadSleep(1200.0555);
        }

        [Test]
        /* 
        Test case 003:
        - S1: navigate to website
        - S2: navigate to Login site
        - S3: input a value to email field
        - S4: click on Login button
        - S5: assert the error message at password field is observable 
        => test case is passed or vice versa
         */
        public void logInTest003()
        {
            pauseWithThreadSleep(550.5);
            //initialize the login page object facilitate calling function from there
            logIn = new LogInPage(driver);
            logIn.clickOnLogInLbl();
            Console.WriteLine("\n //------**----------- CLICKED LOGIN LABEL -----------**-------// \n");
            logIn.sendKeyToEmailTxt(emailTxt);
            Console.WriteLine("\n //------**----------- SENT TEXT TO EMAIL FIELD -----------**-------// \n");
            Console.WriteLine("\n //------**----------- LEFT BLANK TO PASSWORD FIELD -----------**-------// \n");
            logIn.clickOnLogInBtn();
            Console.WriteLine("\n //------**----------- CLICKED LOGIN BUTTON -----------**-------// \n");
            String passwordErrMsgGetTxt = driver.FindElement(LBL_PASSWORD_ERR_MSG_LOCATOR).Text;
            Console.WriteLine("\n Password error message was present on the website: " + passwordErrMsgTxt);
            //verify the text whether it is shown correctly on the site
            if (passwordErrMsgGetTxt == passwordErrMsgTxt)
            {
                this.checkIfTestCaseIsPassed = true;
                if (checkIfTestCaseIsPassed)
                {
                    Console.WriteLine("\n The error message was present correctly" +
                                        ". Asserted successfully test case 003! \n");
                    Assert.Pass();
                }
            }
            else
            {
                this.checkIfTestCaseIsFailed = true;
                if (checkIfTestCaseIsFailed)
                {
                    Console.WriteLine("\n The error message was present incorrectly" +
                                        ". Asserted unsuccessfully test case 003! \n");
                    Assert.Fail();
                }
            }
            pauseWithThreadSleep(1200.0555);
        }
        //test case 004
        [Test]
        /* 
        Test case 004:
        - S1: navigate to website
        - S2: navigate to Login site
        - S3: input a invalid value to email field
        - S4: input a invalid value to password field
        - S5: click on Login button
        - S6: check whether the wrong email or password is present
        => test case is passed or vice versa
         */
        public void logInTest004()
        {
            pauseWithThreadSleep(550.5);
            //declare the object in order to get defined function from login page object
            logIn = new LogInPage(driver);
            logIn.clickOnLogInLbl();
            Console.WriteLine("\n //------**----------- CLICKED LOGIN LABEL -----------**-------// \n");
            logIn.sendKeyToEmailTxt(emailTxt);
            pauseWithThreadSleep(150.5);
            Console.WriteLine("\n //------**----------- SENT TEXT TO EMAIL FIELD -----------**-------// \n");
            logIn.sendKeyToPasswordTxt(passwordTxt);
            pauseWithThreadSleep(150.5);
            Console.WriteLine("\n //------**----------- SENT TEXT TO PASSWORD FIELD -----------**-------// \n");
            pauseWithThreadSleep(1250.5);
            logIn.pressEnterToLogInBtn();
            Console.WriteLine("\n //------**----------- CLICKED LOGIN BUTTON -----------**-------// \n");
            String wrongInforErrMsgGetTxt = driver.FindElement(LBL_WRONG_INFORMATION_ERR_MSG_LOCATOR).Text;
            Console.WriteLine("\n Wrong information error message was present on the website: " + wrongInforErrMsgGetTxt);
            //verify that the text on websites are displayed properly
            if (wrongInforErrMsgGetTxt == wrongInforErrMsgTxt)
            {
                this.checkIfTestCaseIsPassed = true;
                if (checkIfTestCaseIsPassed)
                {
                    Console.WriteLine("\n The error message was present correctly" +
                                        ". Asserted successfully test case 004! \n");
                    Assert.Pass();
                }
            }
            else
            {
                this.checkIfTestCaseIsFailed = true;
                if (checkIfTestCaseIsFailed)
                {
                    Console.WriteLine("\n The error message was present incorrectly" +
                                        ". Asserted unsuccessfully test case 004! \n");
                    Assert.Fail();
                }
            }
            pauseWithThreadSleep(1200.0555);
        }
    }
}