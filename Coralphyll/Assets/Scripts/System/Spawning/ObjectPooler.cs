using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public int size;
        public GameObject prefab; //Lägg scriptable-objektet ist?
        //public ObjectToSpawn prefab;
    }

    #region Singleton Quickversion
    public static ObjectPooler poolerInstance;

    private void Awake()
    {
        poolerInstance = this;
    }

    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    [SerializeField]
    private GameObject[] spawnLocations;
    private int spawnIndex = 0;
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
            //Create a queue for each Pool we have
            Queue<GameObject> objectPool = new Queue<GameObject>();

            //Add all objects from pool to queue
            for (int i = 0; i < pool.size; i++)
            {
                //GameObject objct = Instantiate(pool.prefab);
                GameObject objct = Instantiate(pool.prefab);
                objct.SetActive(false);
                objectPool.Enqueue(objct);
            }

            //Add our pool to the dictionary of pools
            poolDictionary.Add(pool.tag, objectPool);
        }
    }
    public void SpawnFromPool(string tag, int amountToSpawn)
    {
        GameObject current = spawnLocations[spawnIndex % spawnLocations.Length];
        //Choose next spawn-location in array all the time, reset when at end of array
        Vector3 pos = current.transform.position;
        spawnIndex++;
    
        Quaternion rotation = Quaternion.identity;

        //Safety check to prevent attempts of spawning pool using non-existing pool tag
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.Log("Warning: Pool with tag " + tag + " doesn't exist");
            return;
        }

        //Fetch boid-system at location
        BoidsSystem boidSystem = current.gameObject.GetComponent<BoidsSystem>();

        GameObject objctToSpawn;
        //Add fish to boidsystems list of agents
        for (int i = 0; i < amountToSpawn; i++)
        {
            //Fetch object out of queue
            objctToSpawn = poolDictionary[tag].Dequeue();

            //set boids-system owner to be boids-system at chosen location
            objctToSpawn.GetComponent<BoidsAgent>().owner = boidSystem;

            boidSystem.agents.Add(objctToSpawn);

            //activate it in scene
            objctToSpawn.SetActive(true);

            //Move to desired position
            objctToSpawn.transform.position = pos;
            objctToSpawn.transform.rotation = rotation;


            //Might not be needed, test
            IPooledObject pooledObj = objctToSpawn.GetComponent<IPooledObject>();
            if (pooledObj != null)
            {
                pooledObj.OnObjectSpawn();
            }

            //Add object back into queue so we can reuse it later
            poolDictionary[tag].Enqueue(objctToSpawn);
        }
        
        Debug.Log("Amount in list: " + boidSystem.agents.Count);

        boidSystem.IncreaseNumAgents(amountToSpawn);       
    }

    public GameObject SpawnFromPool(string tag, Vector3 pos, Quaternion rotation)
    {
         
        //Safety check to prevent attempts of spawning pool using non-existing pool tag
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.Log("Warning: Pool with tag " + tag + " doesn't exist");
            return null;
        }

        //Fetch object out of queue and activate it in scene
        GameObject objctToSpawn = poolDictionary[tag].Dequeue();
        objctToSpawn.SetActive(true);

        //Move to desired position
        objctToSpawn.transform.position = pos;
        objctToSpawn.transform.rotation = rotation;


        //Might not be needed, test
        IPooledObject pooledObj = objctToSpawn.GetComponent<IPooledObject>();
        if(pooledObj != null)
        {
            pooledObj.OnObjectSpawn();
        }

        //Add object back into queue so we can reuse it later
        poolDictionary[tag].Enqueue(objctToSpawn);

        return objctToSpawn;
    }
}

//Ev TODO: använd AddAgent-metoden istället för att manuellt lägga till fisk till boidsystemets lista, sätta owner och sedan öka på numAgents