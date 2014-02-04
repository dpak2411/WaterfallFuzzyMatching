Feature: WaterfallFuzzyMatching
         This Analytic App performs a waterfall matching process where each record is fuzzy matched to a household level data file to identify and validate information about the individuals.
             
                                     
 Background: 
  Given alteryx running at "http://gallery.alteryx.com/"
  And I am logged in using "deepak.manoharan@accionlabs.com" and "P@ssw0rd"
  
Scenario Outline: Waterfall Fuzzy Matching
When I run Waterfall Fuzzy Matching LevelOne "<Lvl1_HH>"  "<Lvl1_Name>" LevelTwo "<Lvl2_HH>" "<Lvl2_Name>" LevelThree "<Lvl3_HH>" "<Lvl3_Name>" LevelFour "<Lvl4_HH>" "<Lvl4_Name>" LevelFive "<Lvl5_HH>" "<Lvl5_Name>" LevelSix "<Lvl6_HH>"
Then I see the WhoWouldWin result "<Result>"

Examples: 
| Lvl1_HH | Lvl1_Name | Lvl2_HH | Lvl2_Name | Lvl3_HH | Lvl3_Name | Lvl4_HH | Lvl4_Name | Lvl5_HH | Lvl5_Name | Lvl6_HH | Result                       |
| 90      | 90        | 75      | 85        | 60      | 85        | 80      | 75        | 80      | 60        | 85      | Match Level Report Summary   |