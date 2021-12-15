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
        private IWebElement TXT_FIRST_NAME_LOCATOR;

        [FindsBy(How = How.XPath, Using = "//input[@name= 'lastName']")]
        [CacheLookup]
        private IWebElement TXT_LAST_NAME_LOCATOR;

        [FindsBy(How = How.XPath, Using = "//input[@name= 'day' and @id= 'date-of-birth-day']")]
        [CacheLookup]
        private IWebElement TXT_DAY_LOCATOR;

        [FindsBy(How = How.XPath, Using = "//input[@name= 'month' and @id= 'date-of-birth-month']")]
        [CacheLookup]
        private IWebElement TXT_MONTH_LOCATOR;

        [FindsBy(How = How.XPath, Using = "//input[@name= 'month' and @id= 'date-of-birth-month']")]
        [CacheLookup]
        private IWebElement TXT_YEAR_LOCATOR;
        
        [FindsBy(How = How.XPath, Using = "//input[@name= 'email' and @type= 'email']")]
        [CacheLookup]
        private IWebElement TXT_EMAIL_LOCATOR;

        [FindsBy(How = How.XPath, Using = "//input[@name= 'password' and @type= 'password']")]
        [CacheLookup]
        private IWebElement TXT_PASSWORD_LOCATOR;
        
        [FindsBy(How = How.XPath, Using = "//input[@name= 'terms' and @type= 'checkbox']")]
        [CacheLookup]
        private IWebElement CHK_PRIVACY_NOTICE_LOCATOR;
        
        [FindsBy(How = How.XPath, Using = "//input[@name= 'explicitConsent' and @type= 'checkbox']")]
        [CacheLookup]
        private IWebElement CHK_EXPLICIT_CONSENT_LOCATOR;
        
        [FindsBy(How = How.XPath, Using = "//input[@name= 'explicitConsent2' and @type= 'checkbox']")]
        [CacheLookup]
        private IWebElement CHK_EXPLICIT_CONSENT_2_LOCATOR;

        [FindsBy(How = How.XPath, Using = "//button[@type= 'submit']")]
        [CacheLookup]
        private IWebElement BTN_REGISTER_LOCATOR;
        
        [FindsBy(How = How.XPath, Using = "//button[@type= 'button' and @data-auto-id= 'go-to-registration-button']")]
        [CacheLookup]
        private IWebElement BTN_GO_TO_REGISTRATION_LOCATOR;

        public void clickOnRegisterBtn()
        {
            clickOnElement(BTN_REGISTER_LOCATOR);
        }

        public void clickOnGoToRegistrationBtn()
        {
            clickOnElement(BTN_GO_TO_REGISTRATION_LOCATOR);
        }

    }
}
