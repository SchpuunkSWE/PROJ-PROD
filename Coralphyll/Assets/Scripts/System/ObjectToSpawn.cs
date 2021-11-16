using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ObjectSpawnStuff")]
public class ObjectToSpawn : ScriptableObject
{

    public GameObject[] obj;
    public Vector3[] spawnLocations;
    public float startWait;
    public int count;
    public float spawnWait;
    public float waveWait;
    //private Spawner spawner;

}
