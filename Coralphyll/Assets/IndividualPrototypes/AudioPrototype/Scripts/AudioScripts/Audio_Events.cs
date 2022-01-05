using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio_Events : MonoBehaviour
{
    // STATES IN WWISE
    // Music_State:  Combat, Defeat, Exploring, MainMenu, Victory
    // PlayerLife: Alive, Dead
    public bool isAlive = true;
    public bool inCombat = false;
    private int fishes = 0;
    public bool inMainMenu = true;
    private bool hasPlayedAlert = false;
    private string currentLevelState;
    private int tempCoral = 1;
    private int victoryCondition;
    NPCFishUtil fishInventory;
    AIController[] aiContr;
    CheckPoint[] checkPoint;
    Coral[] corals;
    private float time;
    private float tempTime;
    private float musicStateCD;
    private int tempCoralFish;
    private int tempCoralFish2;
    private string sceneIndex;
    // Start is called before the first frame update
    void Awake()
    {
        AudioScene.Levels++;
        tempTime = Random.Range(5f, 6f);
        fishInventory = GetComponent<NPCFishUtil>();
        fishes = fishInventory.getListOfFishes().Count;
        Debug.Log("Fishes: " + fishInventory.getListOfFishes().Count);
        corals = GameObject.FindObjectsOfType<Coral>();
        aiContr = GameObject.FindObjectsOfType<AIController>();
        AkSoundEngine.RegisterGameObj(gameObject);
        //Audio_GameState("StartGame");
        //Audio_PlayerState(isAlive);

    }
    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().name;
        if(AudioScene.Levels < 2)
        {
            Audio_GameState("StartGame");
        }
        else
        {
            Audio_GameState("ResumeMusic");
        }
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (currentLevelState != "Victory")
        {
            LevelCheck();
            CombatCheck();
            FishInventoryCheck();
        }
        LevelCompletionCheck();
    }
    public void Audio_StingerCue(string cue)
    {
        switch (cue)
        {
            case "EnemyAlert":
                AkSoundEngine.PostEvent("OneShot_EnemyAlert", gameObject);
               // AkSoundEngine.PostEvent("SharkHuff", gameObject);
                break;
            case "CoralCompleted":
                AkSoundEngine.PostEvent("OneShot_CoralCompleted", gameObject);
                break;
            case "FishDropOff":
                AkSoundEngine.PostEvent("NPC_DropOff", gameObject);
                break;
            case "FishEat":
                AkSoundEngine.PostEvent("FishEat", gameObject);
                    break;
            default:
                break;
        }
    }
    public void LevelCheck()
    {
        switch (currentLevelState)
        {
            case "Exploring":
                if (tempTime < time)
                {
                    AkSoundEngine.PostEvent("OneShot_SeaCreature", gameObject);
                    tempTime += Random.Range(18f, 30f);
                }
                break;
            default:
                break;
        }
    }
    public void LevelCompletionCheck()
    {
        checkPoint = GameObject.FindObjectsOfType<CheckPoint>();
        int temp = SceneManager.GetActiveScene().buildIndex;

        //corals = GameObject.FindObjectsOfType<Coral>();
        switch (temp)
        {
            case 1:
                victoryCondition = 1;
                break;
            case 2:
                victoryCondition = 2;
                break;
            case 3:
                victoryCondition = 3;
                break;
            case 4:
                victoryCondition = 3;
                break;
        }
        // Debug.Log("buildInd:" + temp + " vic:" + victoryCondition + " check:" + checkPoint.Length + " tempCor:" + tempCoral);
        if (checkPoint.Length >= tempCoral)
        {
            if (checkPoint.Length == victoryCondition)
            {
                Audio_LevelState("Victory");
            }
            else
            {
                currentLevelState = "Default";
                Audio_StingerCue("CoralCompleted");
            }
            tempCoral++;
        }


    }
    public void FishInventoryCheck()
    {
        int tempFish;
        tempFish = fishInventory.getListOfFishes().Count;
        if (tempFish > fishes)
        {
            AkSoundEngine.PostEvent("NPC_Friendly_Pickup", gameObject);
        }
        tempCoralFish2 = 0;
        for (int i = 0; i < corals.Length; i++)
        {
            tempCoralFish2 += corals[i].fishSlotsAvailable(FishColour.BLUE);
            tempCoralFish2 += corals[i].fishSlotsAvailable(FishColour.YELLOW);
            tempCoralFish2 += corals[i].fishSlotsAvailable(FishColour.RED);
        }
        if (tempCoralFish2 < tempCoralFish)
        {
            Debug.Log("2ND: Coral 2:" + tempCoralFish2 + " Coral 1:" + tempCoralFish);
            Audio_StingerCue("FishDropOff");
        }
        if (tempFish < fishes && tempCoralFish2 == tempCoralFish)
        {
            AkSoundEngine.PostEvent("FishEat", gameObject);
        }
        fishes = tempFish;
        tempCoralFish = tempCoralFish2;


    }
    private void CombatCheck()
    {
        if (aiContr.Length != 0)
        {
            for (int i = 0; i < aiContr.Length; i++)
            {
                inCombat = false;

                if (aiContr[i].StateMachine.CurrentState is EnemyChase || aiContr[i].StateMachine.CurrentState is EnemyAttack)
                {
                    if (!hasPlayedAlert)
                    {
                        AkSoundEngine.PostEvent("OneShot_EnemyAlert", aiContr[i].gameObject);
                       // Audio_StingerCue("EnemyAlert");
                        Debug.Log("Incombat: CD: " + musicStateCD + " Time: " + time);
                        Audio_LevelState("Combat");
                    }

                    musicStateCD = time + 3f;
                    inCombat = true;
                    hasPlayedAlert = true;
                    break;
                }
            }
            if (!inCombat && musicStateCD < time)
            {
                Audio_LevelState("Exploring");
                hasPlayedAlert = false;
                musicStateCD = time + 3f;
            }
        }
        else
        {
            Audio_LevelState("Exploring");
        }
    }
    public void Audio_PlayerState(bool isAlive)
    {
        if (isAlive)
        {
            AkSoundEngine.SetState("PlayerLife", "Alive");
        }
        else
        {
            AkSoundEngine.SetState("PlayerLife", "Dead");
        }
    }
    public void Audio_LevelState(string state)
    {
        switch (state)
        {
            case "Exploring":
                switch (sceneIndex)
                {
                    case "Level4":
                        AkSoundEngine.PostEvent("MusicState_Exploring2", gameObject);
                        break;
                    case "Level3":
                        AkSoundEngine.PostEvent("MusicState_Exploring3", gameObject);
                        Debug.Log("Scene is: " + sceneIndex);
                        break;
                    default:
                        AkSoundEngine.PostEvent("MusicState_Exploring", gameObject);
                  //      AkSoundEngine.SetState("Music_State", "Exploring");
                        break;
                }
                currentLevelState = "Exploring";
                break;
            case "Combat":
                //   AkSoundEngine.SetState("Music_State", "Combat");
                AkSoundEngine.PostEvent("MusicState_Combat", gameObject);
                currentLevelState = "Combat";
                break;
            case "Victory":
                AkSoundEngine.SetState("Music_State", "Victory");
                currentLevelState = "Victory";
                break;
            case "Defeat":
                AkSoundEngine.SetState("Music_State", "Defeat");
                break;
            default:
                AkSoundEngine.SetState("Music_State", "Exploring");
                break;

        }
    }
    public void Audio_GameState(string state)
    {
        Debug.Log(AudioScene.Levels);
        switch (state)
        {
            case "StartGame":
                    AkSoundEngine.PostEvent("MusicState_StartOfLevel", gameObject);
                if (sceneIndex == "Level3")
                {
                    AkSoundEngine.PostEvent("MusicState_StartOfLevel2", gameObject);
                }
                AkSoundEngine.PostEvent("Background_Ambience", gameObject);
                    AkSoundEngine.PostEvent("Background_Ambience_2", gameObject);
                break;
            case "ResumeGame":
                if (sceneIndex == "Level3")
                {
                    AkSoundEngine.PostEvent("MusicState_StartOfLevel2", gameObject);
                }
                if(sceneIndex == "Level4")
                {
                    AkSoundEngine.PostEvent("MusicState_StartOfLevel", gameObject);
                }
                break;
        }
    }

}
