using Microsoft.VisualStudio.TestTools.UnitTesting;
using NopCommerce.Nop_PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace NopCommerce.Nop_StepDefinitions
{
    [Binding]
    public  class Nop_RegistrationSteps
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef
        Registration myRegistration = new Registration();
        [Given(@"I have Nop Commerce Application Launched")]
        public void GivenIHaveNopCommerceApplicationLaunched()
        {
            myRegistration.launchApplication();
        }

        [Given(@"I launch Registration Page")]
        public void GivenILaunchRegistrationPage()
        {
            myRegistration.launchRegistrationPage();
        }

        [When(@"I submitt the Registration Page")]
        public void WhenISubmittTheRegistrationPage()
        {
            myRegistration.giveRegistrationDetails();
        }

        [Then(@"I could be Registered Successfully")]
        public void ThenICouldBeRegisteredSuccessfully()
        {
            Assert.IsTrue(myRegistration.confirmRegistration());
            
        }

        [When(@"I Launch Login Page")]
        public void WhenILaunchLoginPage()
        {
            myRegistration.launchLoginPage();
        }

        [When(@"I give user credentials")]
        public void WhenIGiveUserCredentials()
        {
            myRegistration.giveLoginDetails();
        }

        [Then(@"I should be logged in successfully")]
        public void ThenIShouldBeLoggedInSuccessfully()
        {
            
            Assert.IsTrue(myRegistration.confirmUserLogin());
        }
        [Then(@"I Should Logout")]
        public void ThenIShouldLogout()
        {
            myRegistration.logoutApplication();
        }



    }
}
