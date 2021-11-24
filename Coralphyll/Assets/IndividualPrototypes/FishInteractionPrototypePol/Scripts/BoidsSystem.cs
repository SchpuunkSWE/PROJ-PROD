using System.Collections.Generic;
using UnityEngine;

public class BoidsSystem : MonoBehaviour, IPooledObject //Molly Change
{
    [SerializeField] private GameObject agentPrefab;
    [SerializeField] private int numAgents = 10;
    [SerializeField] private float radius = 2;
    [SerializeField] private bool randomGoal;
    [SerializeField] private bool isOnCoral;

    private bool noAgentsLeft = false;

    public Vector3 GoalPosition { get; private set; }
    public List<GameObject> agents = new List<GameObject>();

    public float Radius { get => radius; set => radius = value; }


    //Molly Change
    public string tag;
    //End Molly Change

    private void Start()
    {
        for (int i = 0; i < numAgents; i++)
        {
            Vector3 pos = transform.position + Random.insideUnitSphere * radius;
            var newAgent = Instantiate(agentPrefab, pos, Quaternion.identity, transform);
            newAgent.GetComponent<BoidsAgent>().owner = this;
            agents.Add(newAgent);
        }
        isOnCoral = transform.parent.GetComponentInChildren<Coral>() != null;
    }

    //Object pooling for instantiating fish during runtime?
    private void Update()
    { 
        //Maybe if stationary boids should have small variation in goal i could add this instead of center of system
        if (randomGoal)
        {
            if (Random.Range(0, 10000) < 50)
            {
                GoalPosition = transform.position + Random.insideUnitSphere;
            }
        }
        else
        {
            GoalPosition = transform.position;
        }

        CheckAgentsAmount();

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Radius);
        Gizmos.DrawCube(GoalPosition, Vector3.one * 0.1f);
    }

    public void RemoveAgent(GameObject agent)
    {
        Debug.Log("Remove fish");
        agents.Remove(agent);
    }

    public void AddAgent(GameObject agent)
    {
        Debug.Log("Add fish");
        agents.Add(agent);
        agent.GetComponent<BoidsAgent>().owner = this;
    }


    //Molly change
    public void CheckAgentsAmount()
    {
        if(agents.Count > numAgents && !isOnCoral)
        {
            agents.Clear();

            for (int i = 0; i < numAgents; i++)
            {
                Vector3 pos = transform.position + Random.insideUnitSphere * radius;
                var newAgent = Instantiate(agentPrefab, pos, Quaternion.identity, transform);
                newAgent.GetComponent<BoidsAgent>().owner = this;
                agents.Add(newAgent);
            }
        }
    }

    public void SetNumAgents(int num)
    {
        numAgents = num;
    }

    public void OnObjectSpawn()
    {

    }
    //End Molly Change
}
