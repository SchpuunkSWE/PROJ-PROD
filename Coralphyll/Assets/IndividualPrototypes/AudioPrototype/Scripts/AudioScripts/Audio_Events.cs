using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private float time;
    private float tempTime;
    // Start is called before the first frame update
    void Start()
    {
        tempTime = Random.Range(5f, 6f);
        fishInventory = GetComponent<NPCFishUtil>();
        fishes = fishInventory.getListOfFishes().Count;
        Debug.Log("Fishes: " + fishInventory.getListOfFishes().Count);
        aiContr = GameObject.FindObjectsOfType<AIController>();
        AkSoundEngine.RegisterGameObj(gameObject);
        Audio_GameState("Level1");
        Audio_PlayerState(isAlive);
    }
    private void Update()
    {
        time += Time.deltaTime;
        LevelCheck();
        CombatCheck();
        FishInventoryCheck();
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
                Debug.Log(currentLevelState + "tempTime: "+tempTime + " And time: "+time);
                if (tempTime < time)
                {
                    Debug.Log("Moan should play");
                    AkSoundEngine.PostEvent("OneShot_SeaCreature", gameObject);
                    tempTime += Random.Range(18f, 30f);
                }
                break;
            default:
                break;
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
                    inMainMenu = false;
                break;
            }
        }
        if (!inCombat && !inMainMenu)
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
                if (!inMainMenu)
                {
                    AkSoundEngine.SetState("Music_State", "Exploring");
                    currentLevelState = "Exploring";
                }
                break;
            case "Combat":
                AkSoundEngine.SetState("Music_State", "Combat");
                currentLevelState = "Combat";
                break;
            case "MainMenu":
                inMainMenu = true;
                AkSoundEngine.SetState("Music_State", "MainMenu");
                break;
            case "Victory":
                AkSoundEngine.SetState("Music_State", "Victory");
                break;
            case "Defeat":
                AkSoundEngine.SetState("Music_State", "Defeat");
                break;
            default:
                AkSoundEngine.SetState("Music_State", "Exploring");
                break;

        }
    }
    public void LeaveMainMenu()
    {
        inMainMenu = false;
    }
    public void Audio_GameState(string state)
    {
        switch (state)
        {
            case "Level1":
        AkSoundEngine.PostEvent("MusicState_Initiate", gameObject);
        AkSoundEngine.PostEvent("Background_Ambience", gameObject);
        AkSoundEngine.PostEvent("Background_Ambience_2", gameObject);
        break;
        }
    }

}
