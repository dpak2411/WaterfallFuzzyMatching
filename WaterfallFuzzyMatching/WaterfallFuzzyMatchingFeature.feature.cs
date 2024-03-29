﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.2.1
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18408
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace WaterfallFuzzyMatching
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.2.1")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("WaterfallFuzzyMatching")]
    public partial class WaterfallFuzzyMatchingFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "WaterfallFuzzyMatchingFeature.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "WaterfallFuzzyMatching", "       This Analytic App performs a waterfall matching process where each record " +
                    "is fuzzy matched to a household level data file to identify and validate informa" +
                    "tion about the individuals.", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 5
 #line 6
  testRunner.Given("alteryx running at \"http://gallery.alteryx.com/\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
  testRunner.And("I am logged in using \"deepak.manoharan@accionlabs.com\" and \"P@ssw0rd\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Waterfall Fuzzy Matching")]
        [NUnit.Framework.TestCaseAttribute("90", "90", "75", "85", "60", "85", "80", "75", "80", "60", "85", "Match Level Report Summary", null)]
        public virtual void WaterfallFuzzyMatching(string lvl1_HH, string lvl1_Name, string lvl2_HH, string lvl2_Name, string lvl3_HH, string lvl3_Name, string lvl4_HH, string lvl4_Name, string lvl5_HH, string lvl5_Name, string lvl6_HH, string result, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Waterfall Fuzzy Matching", exampleTags);
#line 9
this.ScenarioSetup(scenarioInfo);
#line 5
 this.FeatureBackground();
#line 10
testRunner.When(string.Format("I run Waterfall Fuzzy Matching LevelOne \"{0}\"  \"{1}\" LevelTwo \"{2}\" \"{3}\" LevelTh" +
                        "ree \"{4}\" \"{5}\" LevelFour \"{6}\" \"{7}\" LevelFive \"{8}\" \"{9}\" LevelSix \"{10}\"", lvl1_HH, lvl1_Name, lvl2_HH, lvl2_Name, lvl3_HH, lvl3_Name, lvl4_HH, lvl4_Name, lvl5_HH, lvl5_Name, lvl6_HH), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
testRunner.Then(string.Format("I see the WhoWouldWin result \"{0}\"", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
