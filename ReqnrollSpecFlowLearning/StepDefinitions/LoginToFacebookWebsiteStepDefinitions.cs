using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using Reqnroll;

namespace ReqnrollSpecFlowLearning.StepDefinitions
{
    [Binding]
    public class LoginToFacebookWebsiteStepDefinitions
    {

        private readonly ScenarioContext _scenarioContext;
        private IPage page;


        public LoginToFacebookWebsiteStepDefinitions(ScenarioContext scenariocontext)
        {
            _scenarioContext = scenariocontext;
            page=_scenarioContext["page"] as IPage;

        }

        /* Below MArked line of code in not required nOw Because nOw We are UisngDependency Injection in Hooks
        private IPlaywright playwright;
        private IBrowser browser;
        private IPage page;

        [BeforeScenario]
        public async Task setup()
        {
            playwright =await Playwright.CreateAsync();
            browser= await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            page= await browser.NewPageAsync();
            await page.SetViewportSizeAsync(1980, 1080);
        }

        [AfterScenario]
        public async Task teardown()
        {
            await page.CloseAsync();
            await browser.CloseAsync(); 
        }
        */


        [Given("Navigated to Login Page")]
        public async Task GivenNavigatedToLoginPage()
        {
            await page.GotoAsync("https://www.facebook.com/");
        }

        [When("Enter Valid Username and Password")]
        public async Task WhenEnterValidUsernameAndPassword()
        {
            await page.Locator("//input[@name='email']").FillAsync("aaaaa");
            await page.Locator("//input[@name='pass']").FillAsync("asdf");
            await page.Locator("//button[@name='login']").ClickAsync();
            
        }

        [Then("One Should be login into Facebook")]
        public async Task ThenOneShouldBeLoginIntoFacebook()
        {
            var msg = await page.Locator("//div[@class=\"_9ay7\"]").InnerTextAsync();
            Assert.That(msg.Contains("The password that you've entered is incorrect."));

        }
    }
}
