using System;
using Reqnroll;

namespace ReqnrollSpecFlowLearning.StepDefinitions
{
    [Binding]
    public class LoginFeatureStepDefinitions
    {
        [Given("I have navigated to the login page")]
        public void GivenIHaveNavigatedToTheLoginPage()
        {
            //throw new PendingStepException();
            Console.WriteLine("I have navigated to the login page");

        }

        [When("I enter valid {string} and {string}")]
        public void WhenIEnterValidAnd(string username, string password)
        {
            //throw new PendingStepException();
            Console.WriteLine("I enter valid UserName--->"+username+"and valid Password---->"+password);
        }

        [Then("I should be redirected to the dashboard")]
        public void ThenIShouldBeRedirectedToTheDashboard()
        {
            //throw new PendingStepException();
            Console.WriteLine("I should be redirected to the dashboard");
        }


        [Then("I should Select City and Country")]
        public void ThenIShouldSelectCityAndCountry(DataTable dataTable)
        {
            //throw new PendingStepException();
            //Console.WriteLine("Selecting City and Country");
            ///First Way 
            ///
            /*
            foreach (var Rows in dataTable.Rows)
            {
               string  City = Rows["City"];
               string Country = Rows["Country"];
               Console.WriteLine( City +"------------>"+Country);
            }
            */

            //Second Way to FetchData from Data Table

            var data = dataTable.Rows[0].ToDictionary(row => row.Key,row => row.Value);
            string city = data["City"];
            string country = data["Country"];
            Console.WriteLine(city +"<------------------>"+country);




        }

    }
}
