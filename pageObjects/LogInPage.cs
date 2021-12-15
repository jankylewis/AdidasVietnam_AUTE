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

        public void clickOnLogInLbl()
        {
            clickOnElement(LBL_LOGIN_LOCATOR);
        }

        public void clickOnLogInBtn()
        {
            clickOnElement(BTN_LOGIN_LOCATOR);
        }

    }
}
