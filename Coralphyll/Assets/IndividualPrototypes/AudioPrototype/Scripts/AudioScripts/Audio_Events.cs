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
    private string currentLevelState;
    NPCFishUtil fishInventory;
    AIController[] aiContr;
    CheckPoint[] checkPoint;
    private float time;
    private float tempTime;
    // Start is called before the first frame update
    void Awake()
    {
        AudioScene.Levels++;
        tempTime = Random.Range(5f, 6f);
        fishInventory = GetComponent<NPCFishUtil>();
        fishes = fishInventory.getListOfFishes().Count;
        Debug.Log("Fishes: " + fishInventory.getListOfFishes().Count);
        aiContr = GameObject.FindObjectsOfType<AIController>();
        AkSoundEngine.RegisterGameObj(gameObject);
        Audio_GameState("StartGame");
        Audio_PlayerState(isAlive);
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
        if (checkPoint.Length>0)
        {
            Audio_LevelState("Victory");
        }
        else
        {
            currentLevelState = "Default";
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
        fishes = tempFish;
    }
    private void CombatCheck()
    {
        if (aiContr.Length != 0)
        {


        for(int i = 0; i < aiContr.Length; i++)
        {
            inCombat = false;

            if (aiContr[i].StateMachine.CurrentState is EnemyChase || aiContr[i].StateMachine.CurrentState is EnemyAttack)
            {
                Audio_LevelState("Combat");
                    inCombat = true;

                break;
            }
        }
        if (!inCombat)
        {
            Audio_LevelState("Exploring");
        }
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
                AkSoundEngine.SetState("Music_State", "Exploring");
                currentLevelState = "Exploring";
                break;
            case "Combat":
                AkSoundEngine.SetState("Music_State", "Combat");
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
                if (AudioScene.Levels<2)
                {
                    Debug.Log(AudioScene.Levels+"Hello");
                    AkSoundEngine.PostEvent("MusicState_StartOfLevel", gameObject);
                    AkSoundEngine.PostEvent("Background_Ambience", gameObject);
                    AkSoundEngine.PostEvent("Background_Ambience_2", gameObject);
                }
        break;
        }
    }

}
