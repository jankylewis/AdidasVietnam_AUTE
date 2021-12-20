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
        //initialize check points for asserting
        internal Boolean checkIfTestCaseIsPassed;
        internal Boolean CheckIfTestCaseIsFailed;
        internal int numberOfErrMsgArePassed; 

        //declare the object in order to use the designed function from register page object
        internal RegisterPage register;
        internal LogInPage logIn;

        //store the browser that used to perform testing
        internal readonly String browser = "chrome";
        internal static IWebDriver dr;

        //store the data to fill out the information field located at registration form
        internal String firstNameTxt;
        internal String lastNameTxt;
        internal String genderTxt;
        internal String emailTxt;
        internal String passwordTxt;
        internal String checkPrivacyConsentNameAttribute1;
        internal String checkPrivacyConsentNameAttribute2;
        internal String checkPrivacyConsentNameAttribute3;
        internal String successfulMsgAfterRegisteringTxt;
        internal String greetingMsgAfterRegisteringTxt;
        internal String welcomeLnkTxt;

        //test template to take actions before each test case
        [SetUp]
        public void beforeTestCase()
        {
            initializeTestCase(browser);
            //log to console
            Console.WriteLine("\n\n--💥💥💥💥💥--\n\n //---**--------  TRIGGER WEB BROWSER ---**--------// \n\n--💥💥💥💥💥--\n\n");
        }

        //test template to take actions after each test case to quit driver
        [TearDown]
        public void afterTestCase()
        {
            pauseWithThreadSleep(1500);
            tearDownTestCase();
            //log to console
            Console.WriteLine("\n\n--💥💥💥💥💥--\n\n //---**--------  TERMINATED THE TEST CASE ---**--------// \n\n--💥💥💥💥💥--\n\r");
        }

        //test case 001
        [Test]
        /*
         *Test case 001:
         * - S1: navigate to website
         * - S2: navigate to Log in site based on clicking the Login label on the navigation
         * - S3: click on Register button without taking actions on any information fields at registration form
         */
        public void registerTest001()
        {
            //store locators on website
            //store the locators as a list of By data type
            int numberOfLocators = (int)9;
            List<By> locatorsStorageList = new List<By>(new[] {
                By.XPath("//div[contains(@data-auto-id, 'firstname-field-error')]"),
                By.XPath("//div[contains(@data-auto-id, 'lastname-field-error')]"),
                By.XPath("//div[@id= 'date-of-birth']//div[contains(text(), 'the date you entered is not valid')]"),
                By.XPath("//div[@role= 'radiogroup']//div[contains(@class, 'error')]"),
                By.XPath("//label[@data-auto-id= 'registration-email-field-label']//following-sibling::div[1][@data-auto-id= 'registration-email-field-error']"),
                By.XPath("//label[@data-auto-id= 'registration-password-field-label']//following-sibling::div[1][@data-auto-id= 'registration-password-field-error']"),
                By.XPath("//label[@role= 'presentation' and @data-auto-id= 'registration-terms-label']//following-sibling::div"),
                By.XPath("//label[@role= 'presentation' and @data-auto-id= 'registration-explicit-consent-label']//following-sibling::div"),
                By.XPath("//label[@role= 'presentation' and @data-auto-id= 'registration-explicit-consent2-label']//following-sibling::div")
            });

            /*
             create an empty list to store the error messages as text that 
             are going to be gotten from website
            */
            List<String> errorMessagesGetTxt = new List<String>();

            //a list to store the expected error messages
            int numberOfMessages = (int)9;
            List<String> errorMessagesTxt = new List<String>(new[] {
            "Please enter your first name",
            "Please enter your last name",
            "Sorry, the date you entered is not valid, please re-enter",
            "Invalid value",
            "Please enter a valid e-mail address",
            "Please enter a password",
            "Please agree to the Privacy Notice and Terms & Conditions",
            "Please agree to the Privacy Notice",
            "Please agree to the Privacy Notice"
            });

            //reference to register and login page objects
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

            //get erorr messages as texts from website
            for (int index= 0; index< 9; index++)
            {
                errorMessagesGetTxt.Add(driver.FindElement(locatorsStorageList[index]).Text.ToString().Trim());
                Console.WriteLine("\nError message number "+ (index+1)+ ": " + 
                    driver.FindElement(locatorsStorageList[index]).Text.ToString().Trim() 
                    + " \n");
            }

            //print error messages that we have just taken from the website
            Console.WriteLine("\n-------------\n");
            Console.WriteLine("\nList of error messages that are hijacked from the website as text: \n");
            for (int indexPrinting= 0; indexPrinting< 9; indexPrinting++)
            {
                Console.WriteLine(""+ errorMessagesGetTxt[indexPrinting] + "");
            }
            Console.WriteLine("\n-------------\n");

            /*
             conduct asserting all the error messages whether they are displayed semantically 
             on the website as expected
             */

            for (int indexForAssertion= 0; indexForAssertion< 9; indexForAssertion++)
            {
                if (errorMessagesGetTxt[indexForAssertion].Contains(errorMessagesTxt[indexForAssertion])==true ||
                    errorMessagesGetTxt[indexForAssertion].Equals(errorMessagesTxt[indexForAssertion])== true)
                {
                    this.checkIfTestCaseIsPassed = true;

                    //asserted successfully an error message
                    if (checkIfTestCaseIsPassed)
                    {
                        Console.WriteLine("" + "Asserted successfully error message " +
                        (indexForAssertion + 1) + ": " + errorMessagesTxt[indexForAssertion] + "");
                        Assert.IsFalse(false);
                        numberOfErrMsgArePassed++;
                    }
                }

                //asserted unsuccessfully an error message
                else
                {
                    this.CheckIfTestCaseIsFailed = true;
                    if (CheckIfTestCaseIsFailed)
                    {
                        Console.WriteLine("\nASSERTED UNSUCCESSFULLY ERROR MESSAGE " + (indexForAssertion + 1) + " -> TEST CASE IS FAILED!\n");
                        Assert.IsFalse(true);
                        Assert.Fail();
                    }

                }
            }

            //asserted successfully all the error messages
            if ((int)numberOfErrMsgArePassed==9)
            {
                Console.WriteLine("\n---------------------------------" +
                                  "\nTEST CASE REGISTER 001 IS PASSED!\n" +
                                    "---------------------------------\n");
                Assert.Pass();
            }

            //asserted unsuccessfully at least one error message
            else if ((int)numberOfErrMsgArePassed<=9)
            {
                Console.WriteLine("\n---------------------------------" +
                                  "\nTEST CASE REGISTER 001 IS FAILED!\n" +
                                    "---------------------------------\n");
                Assert.Fail();
            }

        }

        //test case 002
        [Test]
        /*
         *Test case 002:
         * - S1: navigate to website
         * - S2: navigate to Log in site based on clicking the Login label on the navigation
         * - S3: inputted the required information fields in a valid way
         * - S4: click on Register button
         * - S5: verify the first name that we registered
         */
        public void registerTest002()
        {
            //store locators
            By SUCCESSFUL_MSG_LOCATOR = 
                By.XPath("//div[@class= 'gl-callout']//h5");
            By GREETING_AFTER_REGISTERING_LOCATOR = 
                By.XPath("//div[normalize-space(@data-auto-id= 'welcome-message-section')]//h4");
            By LNK_WELCOME_LOCATOR =
                By.XPath("//a[contains(@manual_cm_sp, 'username')]");

            //store the test data
            this.firstNameTxt = "Raul";
            this.lastNameTxt = "Gonzales";
            this.genderTxt = "Male";
            this.checkPrivacyConsentNameAttribute1 = "terms";
            this.checkPrivacyConsentNameAttribute2 = "explicitConsent";
            this.checkPrivacyConsentNameAttribute3 = "explicitConsent2";
            this.passwordTxt = "Raulgonzales";
            this.successfulMsgAfterRegisteringTxt = "Account Created";
            this.greetingMsgAfterRegisteringTxt = "Hi" + firstNameTxt;
            this.welcomeLnkTxt = "welcome back " + firstNameTxt.ToLower();

            //initialize Log in and Register page objects to use the defined method
            logIn = new LogInPage(driver);
            register = new RegisterPage(driver);

            //input information into all fields at registration form
            string afRandomStringGenerator = generateRandomString((int)4);
            this.emailTxt = "raulgonzales"+ afRandomStringGenerator+ "@gmail.com";

            //Console.WriteLine("\n"+ generateRandomString((int)4)+ "\n");
            logIn.clickOnLogInLbl();
            Console.WriteLine("\n //------**----------- CLICKED ON LOGIN LABEL -----------**-------// \n");
            register.clickOnGoToRegistrationBtn();
            Console.WriteLine("\n //------**----------- CLICKED ON GO TO REGISTRATION BUTTON -----------**-------// \n");
            register.sendKeyToFirstName(firstNameTxt+ afRandomStringGenerator);
            Console.WriteLine("\n //------**----------- INPUTTED INTO FIRST NAME FIELD -----------**-------// \n");
            register.sendKeyToLastName(lastNameTxt + afRandomStringGenerator);
            Console.WriteLine("\n //------**----------- INPUTTED INTO LAST NAME FIELD -----------**-------// \n");
            register.selectGender(genderTxt, driver);
            Console.WriteLine("\n //------**----------- SELECTED GENDER FIELD -----------**-------// \n");
            register.sendKeyToEmail(emailTxt + afRandomStringGenerator);
            Console.WriteLine("\n //------**----------- INPUTTED INTO EMAIL FIELD -----------**-------// \n");
            register.sendKeyToPassword(passwordTxt + afRandomStringGenerator);
            Console.WriteLine("\n //------**----------- INPUTTED INTO PASSWORD FIELD -----------**-------// \n");
            register.checkPrivacyConsent(checkPrivacyConsentNameAttribute1, driver);
            Console.WriteLine("\n //------**----------- CLICKED ON PRIVACY CONSENT CHECK BOX 1 -----------**-------// \n");
            register.checkPrivacyConsent(checkPrivacyConsentNameAttribute2, driver);
            Console.WriteLine("\n //------**----------- CLICKED ON PRIVACY CONSENT CHECK BOX 2 -----------**-------// \n");
            register.checkPrivacyConsent(checkPrivacyConsentNameAttribute3, driver);
            Console.WriteLine("\n //------**----------- CLICKED ON PRIVACY CONSENT CHECK BOX 3 -----------**-------// \n");
            register.clickOnRegisterBtn();
            Console.WriteLine("\n //------**----------- CLICKED ON REGISTER BUTTON AFTER COMPLETING FILLING INFORMATION FIELDS -----------**-------// \n");

            //begin assertions
            string successfulMsgGetTxt= dr.FindElement(SUCCESSFUL_MSG_LOCATOR).Text.ToString().Trim();
            string greetingMsgAfterRegisteringGetTxt = dr.FindElement(GREETING_AFTER_REGISTERING_LOCATOR).Text.ToString().Trim();
            string welcomeLnkGetTxt= dr.FindElement(LNK_WELCOME_LOCATOR).Text.ToString().Trim();
            Console.WriteLine("\n"+ "Successful message: "+ successfulMsgGetTxt+ "\n");
            Console.WriteLine("\n" + "Greeting message: " + greetingMsgAfterRegisteringGetTxt + "\n");
            Console.WriteLine("\n" + "Welcome message: " + welcomeLnkGetTxt + "\n");
            register.pauseWithThread(300);
        
            //asserting with checkpoints
            if (successfulMsgGetTxt.Equals(successfulMsgGetTxt) &&
                    greetingMsgAfterRegisteringGetTxt.Equals(greetingMsgAfterRegisteringTxt) &&
                        welcomeLnkGetTxt.Equals(welcomeLnkTxt))
            {
                this.checkIfTestCaseIsPassed = true;

                //asserted successfully those messages after registering
                if (checkIfTestCaseIsPassed)
                {
                    Console.WriteLine("\n---------------------------------" +
                                      "\nTEST CASE REGISTER 002 IS PASSED!\n" +
                                        "---------------------------------\n");
                    Assert.Pass();
                }

                //asserted unsuccessfully those messages after registering
                else 
                {
                    Console.WriteLine("\n---------------------------------" +
                                      "\nTEST CASE REGISTER 002 IS FAILED!\n" +
                                        "---------------------------------\n");
                    Assert.Fail();
                }
            }
            else
            {
                this.CheckIfTestCaseIsFailed = true;
                Console.WriteLine("\n---------------------------------" +
                  "\nTEST CASE REGISTER 002 IS FAILED!\n" +
                    "---------------------------------\n");
                Assert.Fail();
            }
        }//finish Test Case 002


    }
}
