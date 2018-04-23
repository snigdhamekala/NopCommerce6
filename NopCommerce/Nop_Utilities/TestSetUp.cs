using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace NopCommerce.Nop_Utilities
{
    [Binding]
    public class TestSetUp
    {
        public static IWebDriver WebDriver;
        public static int number;
        public static String Browser = ConfigurationManager.AppSettings["browser"];
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            number =  new Random().Next();
            WebDriver = bringMyDriver();
            WebDriver.Manage().Window.Maximize();
        }

        public static IWebDriver bringMyDriver()
        {
            switch (ConfigurationManager.AppSettings["ExecutionType"])
            {
                case "Local":
                    WebDriver = GetLocalDriver(Browser);
                    break;
                case "Remote":
                    WebDriver = GetRemoteDriver(Browser);
                    break;
                default:
                    WebDriver = GetLocalDriver(Browser);
                    break;
            }
            return WebDriver;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {

           

        }

        [AfterScenario]
        public void AfterScenario()
        {
           
            // WebDriver.Quit();
        }
        

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Thread.Sleep(6000);
            WebDriver.Quit();
        }
       
        private static IWebDriver GetLocalDriver(string browser)
        {
            var options = new ChromeOptions();
            options.AddArguments("--test-type");
            return new ChromeDriver();
        }
        private static IWebDriver GetRemoteDriver(string browser)
        {
            var capabilities = new DesiredCapabilities();
            capabilities.SetCapability("name", ConfigurationManager.AppSettings["ApplicationName"]);
            capabilities.SetCapability(CapabilityType.BrowserName, browser);
            capabilities.SetCapability(CapabilityType.Version, ConfigurationManager.AppSettings["BrowserVersion"]);
            capabilities.SetCapability(CapabilityType.Platform, ConfigurationManager.AppSettings["OS"]);
            capabilities.SetCapability("screen-resolution", ConfigurationManager.AppSettings["ScreenResolution"]);
            capabilities.SetCapability("username", ConfigurationManager.AppSettings["SaucelabsUserName"]);
            capabilities.SetCapability("accessKey", ConfigurationManager.AppSettings["SaucelabsAccessKey"]);
            // capabilities.SetCapability(CapabilityType.IsJavaScriptEnabled, true);
            return new RemoteWebDriver(new Uri(ConfigurationManager.AppSettings["SaucelabsURL"]), capabilities);
        }
    }
}
