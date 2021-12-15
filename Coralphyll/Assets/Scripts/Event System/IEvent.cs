//Author: Pol Lozano Llorens
using UnityEngine;

public interface IEvent { }

#region DEBUG_EVENT
public struct DebugInfo
{
    public GameObject obj;
    public int verbosity;
    public string message;
}

public class DebugEvent : IEvent
{
    public DebugInfo Info { get; }
    public DebugEvent(DebugInfo info) => Info = info;
}
#endregion

#region DEATH_EVENT
public struct DeathInfo
{
    //public HitComponent hitComponent;
    public GameObject victim;
    public GameObject killer;
    //public AudioClip sound;
    //public ParticleSystem particleSystem;
}

public class DeathEvent : IEvent
{
    public DeathInfo Info { get; }
    public DeathEvent(DeathInfo info) => Info = info;
}
#endregion