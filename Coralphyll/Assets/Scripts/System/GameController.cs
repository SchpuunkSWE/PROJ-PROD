using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameController>();
            }
            return instance;
        }
    }

    [SerializeField]
    private Vector3 lastCheckPointPos; //Set in inspector to player start position in level, to determine respawn position if no checkpoint has been reached
    public Vector3 LastCheckPointPos => lastCheckPointPos;

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

    public void PickUpBlueFishBtn()
    {
        Debug.Log("PickUpBlueFishBtn pressed");
        player.GetComponent<NPCFishUtil>().FindAndPickUpFish(FishColour.BLUE);
    }
    public void PickUpYellowFishBtn()
    {
        player.GetComponent<NPCFishUtil>().FindAndPickUpFish(FishColour.YELLOW);
    }

    public void PickUpRedFishBtn()
    {
        player.GetComponent<NPCFishUtil>().FindAndPickUpFish(FishColour.RED);
    }
}
