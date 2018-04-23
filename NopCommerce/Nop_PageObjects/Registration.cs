using NopCommerce.Nop_Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NopCommerce.Nop_PageObjects
{
    public class Registration
    {
        IWebDriver driver = TestSetUp.WebDriver;
        string userName = "Snigdha" + TestSetUp.number;
        string email = "Snigdha" + TestSetUp.number;
        //This is how we can use selenium pagefactory , not using this time here
        // [FindsBy(How = How.XPath, Using = "//a[contains(@href,'register')]")]        public IWebElement registerBtn;
        public Registration()
        {
            // PageFactory.InitElements(driver, this);
            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
        }
        public void launchApplication()
        {
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["appUrl"]);
        }

        public void launchRegistrationPage()
        {
            driver.FindElement(By.XPath("//a[contains(@href,'register')]")).Click();
        }
        public void giveRegistrationDetails()
        {
            driver.FindElement(By.XPath("//input[contains(@name,'txtFirstName')]")).SendKeys(userName);
            driver.FindElement(By.XPath("//input[contains(@name,'txtLastName')]")).SendKeys("Mekala");
            driver.FindElement(By.XPath("//input[contains(@id,'CreateUserStepContainer_Email')]")).SendKeys(userName+"@gmail.com");
            driver.FindElement(By.XPath("//input[contains(@id,'CreateUserStepContainer_UserName')]")).SendKeys(userName);
            IWebElement role = driver.FindElement(By.XPath("//select[contains(@id,'CreateUserStepContainer_ddlRole')]"));
            new SelectElement(role).SelectByIndex(1);
            driver.FindElement(By.XPath("//input[contains(@id,'CreateUserStepContainer_Password')]")).SendKeys("commerce");
            driver.FindElement(By.XPath("//input[contains(@id,'CreateUserStepContainer_ConfirmPassword')]")).SendKeys("commerce");
            driver.FindElement(By.XPath("//input[contains(@id,'CreateUserForm___CustomNav0_StepNextButton')]")).Click();

        }

        bool result;
        public Boolean confirmRegistration()
        {
            if(driver.FindElement(By.XPath("//span[contains(@id,'CreateUserForm_CompleteStepContainer_lblCompleteStep')]")).Displayed)
                result = true;

            return result;
        }

        public void launchLoginPage()
        {
            driver.FindElement(By.XPath("//a[contains(@href,'login')]")).Click();
        }

        public void giveLoginDetails()
        {
            driver.FindElement(By.XPath("//input[contains(@id,'trlCustomerLogin_LoginForm_UserName')]")).SendKeys(userName);
            driver.FindElement(By.XPath("//input[contains(@id,'ctrlCustomerLogin_LoginForm_Password')]")).SendKeys("commerce");
            //Using this static wait because some times it is not validating the correct credentials, might be a bug in the code
            Thread.Sleep(20000);
            driver.FindElement(By.XPath("//input[contains(@id,'ctrlCustomerLogin_LoginForm_LoginButton')]")).Click();
        }

        public Boolean confirmUserLogin()
        {
            result = false;
            if (driver.FindElement(By.XPath("//a[contains(@href,'account')]")).Displayed)
                result = true;

            return result;
        }
        public void logoutApplication()
        {
            driver.FindElement(By.XPath("//a[contains(@href,'logout')]")).Click();
        }
    }
}
