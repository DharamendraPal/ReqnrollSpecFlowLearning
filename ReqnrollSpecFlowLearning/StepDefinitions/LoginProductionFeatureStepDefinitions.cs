using System;
using NUnit.Framework;
using Reqnroll;

namespace ReqnrollSpecFlowLearning.StepDefinitions
{
    [Binding]
    public class LoginProductionFeatureStepDefinitions
    {
        [Given("user navigates to the facebook website")]
        public void GivenUserNavigatesToTheFacebookWebsite()
        {
            //throw new PendingStepException();
            Console.WriteLine("user navigates to the facebook website");
        }

        [When("user validates the homepage title")]
        public void WhenUserValidatesTheHomepageTitle()
        {
            //throw new PendingStepException();
            Console.WriteLine("user validates the homepage title");
        }

        [Then("user enters valid username")]
        public void ThenUserEntersValidUsername()
        {
            //throw new PendingStepException();
            Console.WriteLine("user enters valid username");
        }

        [Then("user enters valid password")]
        public void ThenUserEntersValidPassword()
        {
            //throw new PendingStepException();
            Console.WriteLine("user enters valid password");
        }

        [Then("user clicks on the signin button")]
        public void ThenUserClicksOnTheSigninButton()
        {
            //throw new PendingStepException();
            Console.WriteLine("user clicks on the signin button");
            Assert.Fail("Failing The Steps");
        }
    }
}
