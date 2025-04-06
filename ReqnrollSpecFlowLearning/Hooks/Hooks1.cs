using Microsoft.Playwright;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Reqnroll;

namespace ReqnrollSpecFlowLearning.Hooks
{
    [Binding]
    public sealed class Hooks1
    {

        //below Line of Code Defining Dependency Injection Code
        private readonly ScenarioContext _scenarioContext;

        public Hooks1(ScenarioContext scenariocontext)
        {
            _scenarioContext = scenariocontext;
        }
        // For additional details on Reqnroll hooks see https://go.reqnroll.net/doc-hooks

        [BeforeScenario("@tag1")] /// this is process to provide Tag of Hooks() . So while runing our test cases we can pass only this particular hooks only
                                    //[BeforeScenario("@tag1","order=1")]// this will provide ordering of Hooks  mean we can have multiple hooks of same name and while running test cases they will run in this given order
                                    // While running thrgh terminal , we can execute this particular Scenario by passing command like dotnet test --filter "category=staging"
                                    //in order to generate specflow documentation, we have to install living documentation, dotnet tool install --global Specflow.Plus.LivingDoc.CLI
                                    //to invokde thos living Doc, we have to go to path of .net 6 then giv this command
                                    //livingdoc test-assembly ReqnrollSpecFlowLearning.dll -t TestExecution.json
        public void BeforeScenarioWithTag()
        {
            // Example of filtering hooks using tags. (in this case, this 'before scenario' hook will execute if the feature/scenario contains the tag '@tag1')
            // See https://go.reqnroll.net/doc-hooks#tag-scoping

            //TODO: implement logic that has to run before executing each scenario
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            // Example of ordering the execution of hooks
            // See https://go.reqnroll.net/doc-hooks#hook-execution-order

            //TODO: implement logic that has to run before executing each scenario
        }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            Console.WriteLine("Before Scenario");
            IPlaywright playwright  = await Playwright.CreateAsync();
           var  browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            var page = await browser.NewPageAsync();
            await page.SetViewportSizeAsync(1980, 1080);
            _scenarioContext["page"] = page;
            _scenarioContext["browser"] = browser;


        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
            Console.WriteLine("After Scenario");

            var page =_scenarioContext["page"] as IPage;
            var browser = _scenarioContext["browser"] as IBrowser;
            page?.CloseAsync();
            browser.CloseAsync();
        }


        [BeforeStep]
        public void BeforeSteps()
        {
            Console.WriteLine("Before Steps");
        }

        [AfterStep]
        public void AfterSteps()
        {
            Console.WriteLine("After Steps");
        }

        [BeforeFeature]
        public static void Beforefeature()
        {
            Console.WriteLine("Before Feature");
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("After feature");
        }

        [AfterTestRun]
        public static void Aftertestrun()
        {
            //Console.WriteLine("After Test Run");
            //TestContext.WriteLine("After Test Run1");
            TestContext.Progress.WriteLine("After Test Run2");
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //Console.WriteLine("Before Test Run");
            //TestContext.WriteLine("Before Test Run1");
            TestContext.Progress.WriteLine("Before Test Run2");
        }
       

    }

}