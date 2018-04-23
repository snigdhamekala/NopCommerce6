using Microsoft.VisualStudio.TestTools.UnitTesting;
using NopCommerce.Nop_PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace NopCommerce.Nop_StepDefinitions
{
    [Binding]
    public  class JsonGetAPISteps
    {
        JsonPlaceHolder myJson = new JsonPlaceHolder();
        string API_Url;
        [Given(@"I have The API URL")]
        public void GivenIHaveTheAPIURL()
        {
            API_Url = ConfigurationManager.AppSettings["API_Url"];
        }

        [When(@"I do a GET call to the API")]
        public void WhenIDoAGETCallToTheAPI()
        {
            myJson.fetchResultsFromPublicAPI(API_Url);
        }

        [Then(@"I could get the json data from the API")]
        public void ThenICouldGetTheJsonDataFromTheAPI()
        {
            Assert.IsTrue(myJson.validateData());
        }

    }
}
