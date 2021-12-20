using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using System.Collections.ObjectModel;

namespace AdidasVietnam_AUTE.pageObjects
{
    internal class RegisterPage : AbstractClass.AbstractTest
    {

        public RegisterPage(IWebDriver driver)
        {
            LogInPage.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@name= 'firstName']")]
        [CacheLookup]
        private IWebElement TXT_FIRST_NAME_LOCATOR { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name= 'lastName']")]
        [CacheLookup]
        private IWebElement TXT_LAST_NAME_LOCATOR { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name= 'day' and @id= 'date-of-birth-day']")]
        [CacheLookup]
        private IWebElement TXT_DAY_LOCATOR { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name= 'month' and @id= 'date-of-birth-month']")]
        [CacheLookup]
        private IWebElement TXT_MONTH_LOCATOR { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name= 'month' and @id= 'date-of-birth-month']")]
        [CacheLookup]
        private IWebElement TXT_YEAR_LOCATOR { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name= 'email' and @type= 'email']")]
        [CacheLookup]
        private IWebElement TXT_EMAIL_LOCATOR { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name= 'password' and @type= 'password']")]
        [CacheLookup]
        private IWebElement TXT_PASSWORD_LOCATOR { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name= 'terms' and @type= 'checkbox']")]
        [CacheLookup]
        private IWebElement CHK_PRIVACY_NOTICE_LOCATOR { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name= 'explicitConsent' and @type= 'checkbox']")]
        [CacheLookup]
        private IWebElement CHK_EXPLICIT_CONSENT_LOCATOR { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name= 'explicitConsent2' and @type= 'checkbox']")]
        [CacheLookup]
        private IWebElement CHK_EXPLICIT_CONSENT_2_LOCATOR { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@type= 'submit']")]
        [CacheLookup]
        private IWebElement BTN_REGISTER_LOCATOR { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@type= 'button' and @data-auto-id= 'go-to-registration-button']")]
        [CacheLookup]
        private IWebElement BTN_GO_TO_REGISTRATION_LOCATOR { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//div[contains((@class), 'horizontal')]//input[@type= 'radio']//following-sibling::span")]
        [CacheLookup]
        private IWebElement CHK_GENDER_CHILD_LOCATOR { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//div[contains((@class), 'horizontal')]")]
        [CacheLookup]
        private IWebElement CHK_GENDER_PAR_LOCATOR { get; set; }

        public void clickOnRegisterBtn()
        {
            clickOnElement(BTN_REGISTER_LOCATOR);
        }

        public void clickOnGoToRegistrationBtn()
        {
            clickOnElement(BTN_GO_TO_REGISTRATION_LOCATOR);
        }

        public void sendKeyToFirstName(String firstName)
        {
            sendKeyToElement(TXT_FIRST_NAME_LOCATOR, firstName);
        }

        public void sendKeyToLastName(String lastName)
        {
            sendKeyToElement(TXT_LAST_NAME_LOCATOR, lastName);
        }

        public void sendKeyToDay(String day)
        {
            sendKeyToElement(TXT_DAY_LOCATOR, day);
        }

        public void sendKeyToMonth(string month)
        {
            sendKeyToElement(TXT_MONTH_LOCATOR, month);
        }

        public void sendKeyToYear(String year)
        {
            sendKeyToElement(TXT_YEAR_LOCATOR, year);
        }

        public void sendKeyToEmail(string email)
        {
            sendKeyToElement(TXT_EMAIL_LOCATOR, email);
        }
        public void sendKeyToPassword(String password)
        {
            sendKeyToElement(TXT_PASSWORD_LOCATOR, password);
        }

        public void selectGender(string str, IWebDriver dr)
        {
            /*
            List<string> matchingLinks = new List<string>();
            ReadOnlyCollection<IWebElement> links = driver.FindElements(By.XPath("//div[contains((@class), 'horizontal')]//input[@type= 'radio']//following-sibling::span"));
            int childSize = 0;
            foreach (IWebElement link in links)
            {
                childSize++;
            }
            Console.WriteLine("\n" + childSize + "\n");
            */
            IWebElement listParGender= dr.FindElement(By.XPath("//div[contains((@class), 'horizontal')]"));
            ReadOnlyCollection<IWebElement> listChildGender = 
                driver.FindElements(By.XPath("//div[contains((@class), 'horizontal')]//input[@type= 'radio']//following-sibling::span"));
            int genderSize = 0;
            foreach (IWebElement gender in listChildGender)
            {
                if ((gender.Text).Equals(str)) {
                    gender.Click();
                }
            }
        }

        public void checkPrivacyConsent(String strNameAttribute, IWebDriver dr)
        {
            By PAR_CHK_CONSENT = By.XPath("//h2[contains(text(), 'Register')]//following::form[@novalidate]");
            By CHILD_CHK_CONSENT = By.XPath("//label[contains((@class), 'checkbox')]//input[@type= 'checkbox']");
            IWebElement listParConsent = dr.FindElement(PAR_CHK_CONSENT);
            ReadOnlyCollection<IWebElement> listChildConsent =
                dr.FindElements(CHILD_CHK_CONSENT);
            int consentSize = 0;
            foreach (IWebElement consent in listChildConsent)
            {
                if ((consent.GetAttribute("name")).Equals(strNameAttribute)) {
                    consent.Click();
                }
            }
        }

        public void pauseWithThread(int time)
        {
            pauseWithThreadSleep(time);
        }




    }
}
