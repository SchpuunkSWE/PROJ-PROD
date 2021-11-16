using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<ObjectToSpawn> objs = new List<ObjectToSpawn>(); //was an array before, might need to change back

    [SerializeField]
    private ObjectToSpawn fishSchool;

    //private void Awake()
    //{
    //    GameObject spawner = GameObject.FindWithTag("Spawner");
    //    //DontDestroyOnLoad(spawner);
    //}
    private void Start()
    {
        //FindObjectsOfType<ObjectToSpawn>();

        objs.Add(fishSchool);
       
        spawn();
    }

    public void spawn()
    {
        foreach (var i in objs)
        {
            StartCoroutine(spawnObject(i)); //start coroutines of all objects in the array objs
        }
        print("kör spawn");
    }

    private IEnumerator spawnObject(ObjectToSpawn objct)
    {
        yield return new WaitForSeconds(objct.startWait);
        while (true)
        {
                for (int i = 0; i < objct.count; i++)
                {
                    //Get Random Location from objectToSpawn
                    Vector3 pos = objct.spawnLocations[Random.Range(0, objct.spawnLocations.Length)];

                    int counting = 0; //Detta används bara för test atm för att undvika en endless while-loop

                    //Check if there is already an object at the chosen location
                    while (Physics.CheckSphere(pos, 20) && counting < 3)
                    {
                        
                        //If the position is occupied, keep randomizing until a new spot is reached
                        pos = objct.spawnLocations[Random.Range(0, objct.spawnLocations.Length)];
                        counting++;
   
                        //TODO: Handle case of all spots being occupied(maybe just add a new location to list? or stop spawning new fish?)
                    }//Dubbelkolla med engis: While kmr väl köras om och om tills villkoret returnerar false?

                        //Otherwise position was vacant, spawn at position
                    
                        //Set spawnpos to random location from list
                        Vector3 spawnPosition = new Vector3(pos.x, pos.y, pos.z);
                        Quaternion spawnRotation = Quaternion.identity;

                        //This could be used if we want to randomize what school colour would be spawned
                        GameObject o = objct.obj[Random.Range(0, objct.obj.Length)];
                        Instantiate(o, spawnPosition, spawnRotation);
                        yield return new WaitForSeconds(objct.spawnWait);     
                    
                }
        
            yield return new WaitForSeconds(objct.waveWait);
            print("kör coroutine");
        }

    }

}