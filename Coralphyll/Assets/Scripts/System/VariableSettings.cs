using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableSettings : MonoBehaviour
{
    private PlayerControllerKeybinds playerControllerKeybinds;
    private Controller3DKeybinds player;

    private TrashPile trashPile;

    private void Awake()
    {
        playerControllerKeybinds = PlayerControllerKeybinds.Player;
        player = playerControllerKeybinds.gameObject.GetComponent<Controller3DKeybinds>();
        trashPile = FindObjectOfType<TrashPile>();
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
        //Need to add a variable for this in player
    }
    #endregion

    public void SetPlayerFollowTargetAmount(float value)
    {
        int inputValue = Mathf.RoundToInt(value); //Should be fine, I've set slider to only use whole numbers
        //Need to change NPCFishUtil for this
    }

    public void SetPlayerCanDropFishAnywhere(bool value)
    {
        //Need to change NPCFishUtil for this
    }
    #endregion

    #region NPCFish
    public void SetInitialSchoolAmount(int value)
    {
        //Control amount of schools at start
    }

    public void SetSchoolSizeAmount(int value)
    {
        //Control amount of fish spawning in schools at start
    }

    public void SetRespawnAmount(int value)
    {
        //Control amount of fish respawning
    }
    #endregion

    #region Coral
    public void SetRestriciveNeeds(bool value)
    {
        //Decides whether or not Coral can take more fish than it needs
    }

    public void SetTotalCoralAmount(int value)
    {
        //Start with all Corals deactivated and then just do set active on desired amount?
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

    public void SetTotalSafezoneAmount(int value)
    {
        //Start with all Safezones deactivated and then just do set active on desired amount?
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

    public void TrashPileRemovesPlayerBoost(bool value)
    {
        //Decides whether or not player can boost within trashpile
        //SetPlayerCanBoost(value); ?
    }

    public void SetTotalAmountOfTrashPiles(int value)
    {
        //Start with all trash piles deactivated and then just do set active on desired amount?
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

    public void SetTotalAmountOfSharks(int value)
    {

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
    public void SetTotalAmountOfMorays(int value)
    {

    }
    #endregion

    #endregion
}
