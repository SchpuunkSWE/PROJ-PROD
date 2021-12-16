//Author: Pol Lozano Llorens
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathListener : MonoBehaviour
{
    private void OnEnable() => EventHandler<DeathEvent>.RegisterListener(OnDeath);
    private void OnDisable() => EventHandler<DeathEvent>.UnregisterListener(OnDeath);

    void OnDeath(DeathEvent deathEvent)
    {
        GameObject victim = deathEvent.Info.victim;
        Logger.LoggerInstance.CreateTextFile("#PlayerDied, " + Time.timeSinceLevelLoad + " seconds, " + "#TimeUntilPlayerDied");
        Debug.Log(victim + " died");
        AkSoundEngine.PostEvent("Char_Death", GameObject.FindGameObjectWithTag("MainCamera"));
        //Respawn
        StartCoroutine(Death(victim));
    }

    private IEnumerator Death(GameObject victim)
    {
        GameObject ogMesh = victim.transform.GetChild(3).GetChild(1).gameObject;
        GameObject shellMesh = victim.transform.GetChild(3).GetChild(2).gameObject;
        GameObject deathPoof = victim.transform.GetChild(6).gameObject;

        victim.GetComponent<PlayerControllerKeybinds>().canMove = false;

        deathPoof.SetActive(true);
        shellMesh.SetActive(true);
        ogMesh.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        ogMesh.transform.parent.GetComponent<Animator>().SetBool("dead", true);
        yield return new WaitForSeconds(3.0f);
        victim.transform.position = GameController.Instance.LastCheckPointPos;
        ogMesh.transform.parent.GetComponent<Animator>().SetBool("dead", false);
        deathPoof.SetActive(false);
        ogMesh.SetActive(true);
        shellMesh.SetActive(false);

        victim.GetComponent<PlayerControllerKeybinds>().canMove = true;
    } 
}