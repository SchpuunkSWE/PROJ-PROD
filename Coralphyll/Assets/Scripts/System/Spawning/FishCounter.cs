using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCounter : MonoBehaviour
{
    [SerializeField]
    private List<Coral> coralsInScene;

    private List<BoidsSystem> fishSchoolsInScene;

    //[SerializeField]
    //private Dictionary<FishColour, List<BoidsSystem>> fishSchoolsByColourInScene;
    private int totalFishCount = 0;
    private int totalFishInSchools = 0;
    private int totalSchoolsInWorld = 0;

    private int totalYellowCoralNeeds = 0;
    private int totalBlueCoralNeeds = 0;
    private int totalRedCoralNeeds = 0;

    private int totalYellowFishes = 0;
    private int totalBlueFishes = 0;
    private int totalRedFishes = 0;

    #region Singleton Quickversion
    public static FishCounter fishCounterInstance;

    private void Awake()
    {
        fishCounterInstance = this;
    }

    #endregion

    private void Start()
    {
        foreach (Coral c in coralsInScene)
        {
            totalYellowCoralNeeds += c.GetYellowFishesNeeded();
            totalRedCoralNeeds += c.GetRedFishesNeeded();
            totalBlueCoralNeeds += c.GetBlueFishesNeeded();
        }

        foreach(BoidsSystem school in fishSchoolsInScene)
        {
            totalSchoolsInWorld++;
            foreach(GameObject agent in school.agents)
            {
                switch (agent.GetComponent<Follower>().GetColour())
                {
                    case FishColour.YELLOW: //byta mot bara "YELLOW"?
                        totalYellowFishes++;
                        break;
                    case FishColour.RED:
                        totalRedFishes++;
                        break;
                    case FishColour.BLUE:
                        totalBlueFishes++;
                        break;
                }
            }
        }

        
    }
    private void Update()
    {
        
    }
}
