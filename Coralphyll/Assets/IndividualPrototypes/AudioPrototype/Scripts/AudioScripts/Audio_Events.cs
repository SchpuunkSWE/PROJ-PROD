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
    AIController[] aiContr;
    // Start is called before the first frame update
    void Start()
    {
        aiContr = GameObject.FindObjectsOfType<AIController>();
        AkSoundEngine.RegisterGameObj(gameObject);
        Audio_GameState("Level1");
        Audio_PlayerState(isAlive);
    }
    private void Update()
    {
        CombatCheck();
    }
    public void Audio_StingerCue(string cue)
    {
        switch (cue)
        {
            default:
                break;
        }
    }
    private void CombatCheck()
    {
        for(int i = 0; i < aiContr.Length; i++)
        {
            inCombat = false;

            if (aiContr[i].StateMachine.CurrentState is EnemyChase)
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
                break;
            case "Combat":
                AkSoundEngine.SetState("Music_State", "Combat");
                break;
            case "MainMenu":
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
    public void Audio_GameState(string state)
    {
        switch (state)
        {
            case "Level1":
        AkSoundEngine.PostEvent("MusicState_Initiate", gameObject);
        AkSoundEngine.PostEvent("Background_Ambience", gameObject);
        break;
        }
    }

}
