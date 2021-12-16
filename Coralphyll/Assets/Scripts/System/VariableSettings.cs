using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableSettings : MonoBehaviour
{
    private PlayerControllerKeybinds playerControllerKeybinds;
    private Controller3DKeybinds player;

    private TrashPile trashPile;

    [SerializeField]
    private List<GameObject> trashPiles;

    //[SerializeField]
    private List<GameObject> corals;

    [SerializeField]
    private List<GameObject> safeZones;

    [SerializeField]
    private List<GameObject> enemySharks;

    [SerializeField]
    private List<GameObject> enemyMorays;

    [SerializeField]
    private List<GameObject> fishSchools;


    private void Awake()
    {
        playerControllerKeybinds = PlayerControllerKeybinds.Player;
        player = playerControllerKeybinds.gameObject.GetComponent<Controller3DKeybinds>();
        trashPile = FindObjectOfType<TrashPile>();
    }

    private void ActivateObjectsInList(List<GameObject> listToPopulate, int amount)
    {
        int count = 0;
        foreach (GameObject go in listToPopulate)
        {
            if(count < amount)
            {
                go.SetActive(true);
            }
            else
            {
                go.SetActive(false);
            }
            count++;
        }
    }

    #region Player
    public void SetPlayerSpeed(float value)
    {
        player.Speed = value;
    }

    public void SetPlayerMaxVelocity (float value)
    {
        player.MaxVelocityValue = value;
    }

    #region Boost
    public void SetPlayerBoostDuration(float value)
    {
        player.BoostDuration = value;
    }

    public void SetPlayerBoostCoolDown(float value)
    {
        player.BoostCooldown = value;
    }

    public void SetPlayerMaxBoostSpeed(float value)
    {
        player.MaxBoostSpeed = value;
    }

    public void SetPlayerCanBoost(bool value)
    {
        player.IsBoostReady = value;
    }
    #endregion

    public void SetPlayerFollowTargetAmount(float value)
    {
        int inputValue = Mathf.RoundToInt(value); //Should be fine, I've set slider to only use whole numbers
        player.GetComponent<NPCFishUtil>().LoopFollowTargets(inputValue);
    }

    public void SetPlayerCanDropFishAnywhere(bool value)
    {
        playerControllerKeybinds.CanDropFish = value;
    }
    #endregion

    #region NPCFish
    public void SetInitialSchoolAmount(float value)
    {
        //Control amount of schools in scene
        int inputValue = Mathf.RoundToInt(value); //Should be fine, I've set slider to only use whole numbers
        ActivateObjectsInList(fishSchools, inputValue);
    }

    public void SetSchoolSizeAmount(float value)
    {
        //Control amount of fish spawning in schools at start
        int inputValue = Mathf.RoundToInt(value); //Should be fine, I've set slider to only use whole numbers
        foreach (GameObject school in fishSchools)
        {
            ActivateObjectsInList(school.GetComponent<BoidsSystem>().agents, inputValue);
        }     
    }

    public void SetRespawnAmount(float value)
    {
        //Control amount of fish respawning
        int inputValue = Mathf.RoundToInt(value); //Should be fine, I've set slider to only use whole numbers
        FishCounter.fishCounterInstance.ExtraMargin = inputValue;
    }
    #endregion

    #region Coral
    public void SetRestriciveNeeds(bool value)
    {
        //Decides whether or not Coral can take more fish than it needs
    }

    public void SetTotalCoralAmount(float value)
    {
        int inputValue = Mathf.RoundToInt(value); //Should be fine, I've set slider to only use whole numbers
        ActivateObjectsInList(corals, inputValue);
    }

    public void SetCoralSafetyRange()
    {
        //Control size of safe area around coral
    }

    public void SetCoralIsSafezone(bool value)
    {
        //Control whether or not player is safe from enemies within coral at all
    }
    #endregion

    #region SafeZones
    public void SetSafeZoneSafetyRange()
    {
        //Control size of safe area around safezone
    }

    public void SetTotalSafezoneAmount(float value)
    {
        int inputValue = Mathf.RoundToInt(value); //Should be fine, I've set slider to only use whole numbers
        ActivateObjectsInList(safeZones, inputValue);
    }
    #endregion

    #region TrashPile
    public void SetTimeBeforeKill(float value)
    {
        trashPile.TimeAllowed = value;
    }

    public void SetTrashPileSpeed(float value)
    {
        trashPile.TrashPileSpeed = value;
    }

    public void SetTrashSlowAmount(float value)
    {
        trashPile.PlayerSlowedSpeed = value;
    }

    public void SetTotalAmountOfTrashPiles(float value)
    {
        int inputValue = Mathf.RoundToInt(value); //Should be fine, I've set slider to only use whole numbers
        ActivateObjectsInList(trashPiles, inputValue);
    }

    public void TrashPileRemovesPlayerBoost(bool value)
    {
        trashPile.TrashRemovesPlayerBoost = value;
    }


    #endregion

    #region Enemies
    public void SetAmountPerBite(int value)
    {

    }

    #region Shark
    public void SetSharkSpeed(float value)
    {

    }

    public void SetSharkSpeedPerFish(float value)
    {

    }

    public void SetSharkFOV(float value)
    {
        //Use viewAngle-variable?
    }

    public void SetSmellingRange(float value)
    {
     
    }

    public void SetEatingCooldown(float value)
    {

    }

    public void SetSharkChaseDistance(float value)
    {
        //Control how long/far the shark chases before losing player
        //Use lostTargetDistance?
    }

    public void SetCanEatPlayer(bool value)
    {
        //Control whether or not shark can eat player if player has no fishes
    }

    public void SetTotalAmountOfSharks(float value)
    {
        int inputValue = Mathf.RoundToInt(value); //Should be fine, I've set slider to only use whole numbers
        ActivateObjectsInList(enemySharks, inputValue);
    }
    #endregion

    #region Moray
    public void SetLungeSpeed(float value)
    {

    }

    public void SetMorayChaseDistance(float value)
    {
        
    }

    public void SetMorayFOV(float value)
    {
        //TBA
    }
    public void SetTotalAmountOfMorays(float value)
    {
        int inputValue = Mathf.RoundToInt(value); //Should be fine, I've set slider to only use whole numbers
        ActivateObjectsInList(enemyMorays, inputValue);
    }
    #endregion

    #endregion
}
