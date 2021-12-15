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
    public class LogInPage : AbstractClass.AbstractTest
    {
        public LogInPage(IWebDriver driver)
        {
            LogInPage.driver= driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(normalize-space(text()),'Log in')]")]
        [CacheLookup]
        private IWebElement LBL_LOGIN_LOCATOR;

        [FindsBy(How = How.XPath, Using = "//button[@type='submit' and @class]")]
        [CacheLookup]
        private IWebElement BTN_LOGIN_LOCATOR;

        [FindsBy(How = How.XPath, Using = "//input[@id='login-password' and @type= 'password']")]
        [CacheLookup]
        private IWebElement TXT_PASSWORD_LOCATOR;

        [FindsBy(How = How.XPath, Using = "//input[@id='login-email' and @type= 'email']")]
        [CacheLookup]
        private IWebElement TXT_EMAIL_LOCATOR;
        

        [FindsBy(How = How.XPath, Using = "//input[@type= 'checkbox']")]
        [CacheLookup]
        private IWebElement CHK_REMEMBER_LOCATOR;

        public void clickOnLogInLbl()
        {
            clickOnElement(LBL_LOGIN_LOCATOR);
        }

        public void clickOnLogInBtn()
        {
            clickOnElement(BTN_LOGIN_LOCATOR);
        }

        public void sendKeyToPasswordTxt(String key)
        {
            sendKeyToElement(TXT_PASSWORD_LOCATOR, key);
        }
        public void sendKeyToEmailTxt(String key)
        {
            sendKeyToElement(TXT_EMAIL_LOCATOR, key);
        }

        public void clickOnRememberChk()
        {
            clickOnElement(CHK_REMEMBER_LOCATOR);
        }

        public void pressEnterToLogInBtn()
        {
            pressEnterToElement(BTN_LOGIN_LOCATOR);
        }

    }
}
