using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FishCounter : MonoBehaviour
{
    [SerializeField]
    private List<Coral> coralsInScene;

    [SerializeField]
    private List<GameObject> fishSchoolsInScene;
    [SerializeField]
    private List<GameObject> fishSchoolsInSceneToRemove;

    //private int totalFishCount = 0;
    //private int totalFishInSchools = 0;
    //private int totalSchoolsInWorld = 0;

    private int totalYellowCoralNeeds = 0;
    private int totalBlueCoralNeeds = 0;
    private int totalRedCoralNeeds = 0;

    private int totalYellowFishes = 0;
    private int totalRedFishes = 0;
    private int totalBlueFishes = 0;

    //Spawn some extra fishes in addition to fishes needed
    private int extraMargin = 3;

    private bool recountFishes = true;
    public bool RecountFishes { get => recountFishes; set => recountFishes = value; }

    #region Singleton Quickversion
    public static FishCounter fishCounterInstance;

    private void Awake()
    {
        fishCounterInstance = this;
    }

    #endregion

    private void CountFishesByColour()
    {
        totalYellowCoralNeeds = 0;
        totalRedCoralNeeds = 0;
        totalBlueCoralNeeds = 0;

        totalYellowFishes = 0;
        totalRedFishes = 0;
        totalBlueFishes = 0;

        foreach (Coral c in coralsInScene)
        {
            Debug.Log("BAjs");
            totalYellowCoralNeeds += c.fishSlotsAvailable(FishColour.YELLOW);
            totalRedCoralNeeds += c.fishSlotsAvailable(FishColour.RED);
            totalBlueCoralNeeds += c.fishSlotsAvailable(FishColour.BLUE);
        }

        foreach (GameObject school in fishSchoolsInScene)
        {
            BoidsSystem boidsSystem = school.GetComponent<BoidsSystem>();
            if (boidsSystem.agents.Count == 0)
            {
                fishSchoolsInSceneToRemove.Add(school);
            }
            else
            {
                foreach (GameObject agent in boidsSystem.agents)
                {
                    Follower f = agent.GetComponent<Follower>();
                    switch (f.GetColour())
                    {
                        case FishColour.YELLOW:
                            totalYellowFishes++;
                            break;
                        case FishColour.RED:
                            totalRedFishes++;
                            break;
                        case FishColour.BLUE:
                            totalBlueFishes++;
                            break;
                        default:
                            Debug.Log("Unknown Fish");
                            break;
                    }
                }
            }
        }
        Debug.Log("Coral need " + totalYellowCoralNeeds + ", " + totalRedCoralNeeds + ", " + totalBlueCoralNeeds);
        Debug.Log("Total fish " + totalYellowFishes + ", " + totalRedFishes + ", " + totalBlueFishes);
    }

    private void Update()
    {
        if (fishSchoolsInSceneToRemove.Count > 0)
        {
            foreach (GameObject go in fishSchoolsInSceneToRemove)
            {
                fishSchoolsInScene.Remove(go);
            }
        }

        if (recountFishes)
        {
            CountFishesByColour();
            recountFishes = false;
        }

        //If at any point total fishes of colourX are less than coral needs of colourX, spawn new fish of colourX


        //Use these to determine NumAgents in Boidssystem at spawn (number of fishes to be spawned in school)
        int yellowFishToSpawn = CalculateFishToSpawn(totalYellowCoralNeeds, totalYellowFishes);
        int redFishToSpawn = CalculateFishToSpawn(totalRedCoralNeeds, totalRedFishes);
        int blueFishToSpawn = CalculateFishToSpawn(totalBlueCoralNeeds, totalBlueFishes);


        //Ropa p� ngn spawn-funktion med ovan givna siffror
        if (yellowFishToSpawn > 0)
        {
            //Spawna Gult Fiskstim
            fishSchoolsInScene.Add(ObjectPooler.poolerInstance.SpawnFromPool("YellowSchool"));
            fishSchoolsInScene.Last<GameObject>().GetComponent<BoidsSystem>().SetNumAgents(yellowFishToSpawn + extraMargin);
            recountFishes = true;
        }

        if (redFishToSpawn > 0)
        {
            //Spawna R�tt Fiskstim
            fishSchoolsInScene.Add(ObjectPooler.poolerInstance.SpawnFromPool("RedSchool"));
            fishSchoolsInScene.Last<GameObject>().GetComponent<BoidsSystem>().SetNumAgents(redFishToSpawn + extraMargin);
            recountFishes = true;
        }

        if (blueFishToSpawn > 0)
        {
            //Spawna bl�tt Fiskstim
            fishSchoolsInScene.Add(ObjectPooler.poolerInstance.SpawnFromPool("BlueSchool"));
            fishSchoolsInScene.Last<GameObject>().GetComponent<BoidsSystem>().SetNumAgents(blueFishToSpawn + extraMargin);
            recountFishes = true;
        }

    }
    private int CalculateFishToSpawn(int needs, int total)
    {
        int i = needs - total;
        //i = i + (int)0.1 * i;
        //i += 3;
        return i;
    }

    public void RemoveSchool(BoidsSystem boidsSystem)
    {
        fishSchoolsInScene.Remove(boidsSystem.gameObject);
    }
}
