using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using Reqnroll;

namespace ReqnrollSpecFlowLearning.Hooks
{
    [Binding]
    public sealed class ExtentReportHooks
    {
        public static ExtentReports extent;
        public static ExtentTest feature;
        public static ExtentTest scenario;

        private static string reportpath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "ExtentReports");
        private static string reportfile = Path.Combine(reportpath, "ExtentReports.html");

        [BeforeTestRun]
        public static void InitializeReport()
        {
            if(!Directory.Exists(reportfile))
            {
                Directory.CreateDirectory(reportpath);
            }

            var htmlReporter=new ExtentSparkReporter(reportfile);
            extent =new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }


        [AfterTestRun]
        public static void FlushReport()
        {
            extent.Flush();
        }


        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featurecontext)
        {
            feature = extent.CreateTest<Feature>(featurecontext.FeatureInfo.Title);

        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenariocontext)
        {
            //scenario= feature.CreateNode<Scenario>(scenariocontext.ScenarioInfo.Title);
            scenario = feature.CreateNode<Scenario>(scenariocontext.ScenarioInfo.Title);


        }

        [AfterStep]
        public void Afterstep(ScenarioContext scenariocontext)
        {
            var stepType=ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            var stepinfo = ScenarioStepContext.Current.StepInfo.Text;

            if (scenariocontext.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(stepinfo);
                else if (stepType == "When")
                    scenario.CreateNode<When>(stepinfo);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(stepinfo);
                else if(stepType == "And")
                    scenario.CreateNode<And>(stepinfo);
            }
            else
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(stepinfo).Fail(scenariocontext.TestError.Message);
                else if (stepType == "When")
                    scenario.CreateNode<When>(stepinfo).Fail(scenariocontext.TestError.Message); 
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(stepinfo).Fail(scenariocontext.TestError.Message); 
                else if(stepType == "And")
                    scenario.CreateNode<And>(stepinfo).Fail(scenariocontext.TestError.Message); 

            }


        }



    }
}