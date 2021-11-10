//Author: Pol Lozano Llorens
using UnityEngine;

public class DeathListener : MonoBehaviour
{
    private void OnEnable() => EventHandler<DeathEvent>.RegisterListener(OnDeath);
    private void OnDisable() => EventHandler<DeathEvent>.UnregisterListener(OnDeath);

    void OnDeath(DeathEvent deathEvent)
    {
        GameObject victim = deathEvent.Info.victim;
        Debug.Log(victim + " died");

        //Respawn
        victim.transform.position = GameController.Instance.LastCheckPointPos;
    }
}