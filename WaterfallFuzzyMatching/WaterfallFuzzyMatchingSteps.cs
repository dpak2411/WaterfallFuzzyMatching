using System;
using System.Collections.Generic;
using AlteryxGalleryAPIWrapper;
using AnalogStoreAnalysis;
using HtmlAgilityPack;
using Newtonsoft.Json;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace WaterfallFuzzyMatching
{
    [Binding]
    public class WaterfallFuzzyMatchingSteps
    {
        public string alteryxurl;
        public string _sessionid;
        private string _appid;
        private string _userid;
        private string _appName;
        private string jobid;
        private string outputid;
        private string validationId;

        // public delegate void DisposeObject();
        //private Client Obj = new Client("https://devgallery.alteryx.com/api/");
        Client Obj = new Client("https://gallery.alteryx.com/api");
        RootObject jsString = new RootObject();


        [Given(@"alteryx running at ""(.*)""")]
        public void GivenAlteryxRunningAt(string url)
        {
            alteryxurl = url;
        }
        
        [Given(@"I am logged in using ""(.*)"" and ""(.*)""")]
        public void GivenIAmLoggedInUsingAnd(string user, string password)
        {
            _sessionid = Obj.Authenticate(user, password).sessionId;
        }
        
        [When(@"I run Waterfall Fuzzy Matching LevelOne ""(.*)""  ""(.*)"" LevelTwo ""(.*)"" ""(.*)"" LevelThree ""(.*)"" ""(.*)"" LevelFour ""(.*)"" ""(.*)"" LevelFive ""(.*)"" ""(.*)"" LevelSix ""(.*)""")]
        public void WhenIRunWaterfallFuzzyMatchingLevelOneLevelTwoLevelThreeLevelFourLevelFiveLevelSix(int Lvl1_HH, int Lvl1_Name, int Lvl2_HH, int Lvl2_Name, int Lvl3_HH, int Lvl3_Name, int Lvl4_HH, int Lvl4_Name, int Lvl5_HH, int Lvl5_Name, int Lvl6_HH)
        {
            string response = Obj.SearchApps("Matched Records");
            var appresponse = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Dictionary<string, dynamic>>(response);
            int count = appresponse["recordCount"];
            _userid = appresponse["records"][0]["owner"]["id"];
            _appName = appresponse["records"][0]["primaryApplication"]["fileName"];
            _appid = appresponse["records"][0]["id"];
            jsString.appPackage.id = _appid;
            jsString.userId = _userid;
            jsString.appName = _appName;
            string appinterface = Obj.GetAppInterface(_appid);
            dynamic interfaceresp = JsonConvert.DeserializeObject(appinterface);

            
            List<Jsonpayload.Question> questionAnsls = new List<Jsonpayload.Question>();
            questionAnsls.Add(new Jsonpayload.Question("Lvl1_HH", Lvl1_HH.ToString()));
            questionAnsls.Add(new Jsonpayload.Question("Lvl1_Name", Lvl1_Name.ToString()));
            questionAnsls.Add(new Jsonpayload.Question("Lvl2_HH", Lvl2_HH.ToString()));
            questionAnsls.Add(new Jsonpayload.Question("Lvl2_Name", Lvl2_Name.ToString()));
            questionAnsls.Add(new Jsonpayload.Question("Lvl3_HH", Lvl3_HH.ToString()));
            questionAnsls.Add(new Jsonpayload.Question("Lvl3_Name", Lvl3_Name.ToString()));
            questionAnsls.Add(new Jsonpayload.Question("Lvl4_HH", Lvl4_HH.ToString()));
            questionAnsls.Add(new Jsonpayload.Question("Lvl4_Name", Lvl4_Name.ToString()));
            questionAnsls.Add(new Jsonpayload.Question("Lvl5_HH", Lvl5_HH.ToString()));
            questionAnsls.Add(new Jsonpayload.Question("Lvl5_Name", Lvl5_Name.ToString()));
            questionAnsls.Add(new Jsonpayload.Question("Lvl6_HH", Lvl6_HH.ToString()));
            
            // questionAnsls.Add(new Jsonpayload.Question("Maximum Search Distance", maxSearchDistance));
            jsString.questions.AddRange(questionAnsls);
            jsString.jobName = "Job Name";
            var postData = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(jsString);
            string postdata = postData.ToString();
            string resjobqueue = Obj.QueueJob(postdata);
            var jobqueue = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Dictionary<string, dynamic>>(resjobqueue);
            jobid = jobqueue["id"];

            int counts = 0;
            string status = "";

        CheckValidate:
            System.Threading.Thread.Sleep(1000);
            if (status == "Completed" && counts < 15)
            {
                //string disposition = validationStatus.disposition;
            }
            else if (counts < 15)
            {
                string jobstatusresp = Obj.GetJobStatus(jobid);
                var statusResponse = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Dictionary<string, dynamic>>(jobstatusresp);
                status = statusResponse["status"];
                goto CheckValidate;
            }

            else
            {
                throw new Exception("Complete Status Not found");

            }
 

        }
        
        [Then(@"I see the WhoWouldWin result ""(.*)""")]
        public void ThenISeeTheWhoWouldWinResult(string result)
        {
            string getmetadata = Obj.GetOutputMetadata(jobid);
            dynamic metadataresp = JsonConvert.DeserializeObject(getmetadata);
            int count = metadataresp.Count;
            for (int j = 0; j <= count - 1; j++)
            {
                outputid = metadataresp[j]["id"];
            }
            string getjoboutput = Obj.GetJobOutput(jobid, outputid, "html");
            string htmlresponse = getjoboutput;
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlresponse);
            string output = doc.DocumentNode.SelectSingleNode("//div[@class='DefaultText']").InnerText;
            StringAssert.Contains(result, output);
        }
    }
}
