using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance;

    [SerializeField]
    private Vector3 lastCheckPointPos; //Set in inspector to the first checkpoint pos, to determine where the player starts.

    [SerializeField]
    private GameObject player; //Set in inspector

    [SerializeField]
    private GameObject sceneTransitionGate;
    
    [SerializeField]
    private int totalCoralAmount; //Set in inspector, amount of corals in scene

    private int completedCoralAmount = 0; //Amount of corals with fully completed needs

    private bool runOnce = false;

    public void SetCompletedCoralAmount()
    {
        completedCoralAmount++;
    }

    private void CheckLevelProgress()
    {
        if (completedCoralAmount >= totalCoralAmount)
        {
            LevelComplete();
        }
    }

    private void LevelComplete()
    {
        if (!runOnce)
        {
            //Open a gate to next level
            Debug.Log("Level Complete!");
            sceneTransitionGate.SetActive(true);
            Instantiate(sceneTransitionGate.GetComponent<SceneController>().GetParticles(), sceneTransitionGate.transform.position, sceneTransitionGate.transform.rotation); //Spawn particles on gate so player can see it (temp)
            runOnce = true;
        }
        
    }

    private void Update()
    {
        CheckLevelProgress();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance); //Makes the GameController survive between scenes
        }
        else
        {
            Destroy(gameObject); //Ensures that there is only one GameController per scene
        }
    }

    public Vector3 GetLastCheckPointPos()
    {
        return lastCheckPointPos;
    }
    public void SetLastCheckPointPos(Vector3 newPos)
    {
        lastCheckPointPos = newPos;
    }

    public void DepositBlueFishButton()
    {
        Debug.Log("DepositBlueFishButton pressed");

        player.GetComponent<NPCFishUtil>().TransferFish(FishColour.BLUE);
    }

    public void DepositYellowFishButton()
    {
        Debug.Log("DepositYellowFishButton pressed");

        player.GetComponent<NPCFishUtil>().TransferFish(FishColour.YELLOW);
    }

    public void DepositRedFishButton()
    {
        Debug.Log("DepositRedFishButton pressed");

        player.GetComponent<NPCFishUtil>().TransferFish(FishColour.RED);
    }
}
