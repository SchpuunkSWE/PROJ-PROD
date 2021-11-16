using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<ObjectToSpawn> objs = new List<ObjectToSpawn>(); //was an array before, might need to change back

    [SerializeField]
    private ObjectToSpawn yellowFishSchool;

    [SerializeField]
    private ObjectToSpawn redFishSchool;

    [SerializeField]
    private ObjectToSpawn blueFishSchool;


    private void Start()
    {
        //FindObjectsOfType<ObjectToSpawn>();

        objs.Add(yellowFishSchool);
        objs.Add(redFishSchool);
        objs.Add(blueFishSchool);
       
        //spawn();
    }

    public void spawn()
    {
        foreach (var i in objs)
        {
            //StartCoroutine(spawnObject(i)); //start coroutines of all objects in the array objs
            spawnStuff(i);
        }
        print("kör spawn");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            spawn(); 
        }
    }

    //private IEnumerator spawnObject(ObjectToSpawn objct)
    //{
    //    yield return new WaitForSeconds(objct.startWait);
    //    while (true)
    //    {
    //            for (int i = 0; i < objct.count; i++)
    //            {
    //                //Get Random Location from objectToSpawn
    //                Vector3 pos = objct.spawnLocations[Random.Range(0, objct.spawnLocations.Length)];

    //                    //Set spawnpos to random location from list
    //                    Vector3 spawnPosition = new Vector3(pos.x, pos.y, pos.z);
    //                    Quaternion spawnRotation = Quaternion.identity;

    //                    //This could be used if we want to randomize what school colour would be spawned
    //                    GameObject o = objct.obj[Random.Range(0, objct.obj.Length)];

    //                    //Instantiate(o, spawnPosition, spawnRotation);
    //                    ObjectPooler.poolerInstance.SpawnFromPool(objct.tag, spawnPosition, spawnRotation);


    //                    yield return new WaitForSeconds(objct.spawnWait);     

    //            }

    //        yield return new WaitForSeconds(objct.waveWait);
    //        print("kör coroutine");
    //    }

    //}

    private void spawnStuff(ObjectToSpawn objct)
    {
        for (int i = 0; i < objct.count; i++)
        {
            //Get Random Location from objectToSpawn
            Vector3 pos = objct.spawnLocations[Random.Range(0, objct.spawnLocations.Length)];

            //Set spawnpos to random location from list
            Vector3 spawnPosition = new Vector3(pos.x, pos.y, pos.z);
            Quaternion spawnRotation = Quaternion.identity;

            //This could be useful if we want to randomize what school colour would be spawned
            GameObject o = objct.obj[Random.Range(0, objct.obj.Length)];


            //Instantiate(o, spawnPosition, spawnRotation);

            ObjectPooler.poolerInstance.SpawnFromPool(objct.tag, spawnPosition, spawnRotation);

        }
    }
}