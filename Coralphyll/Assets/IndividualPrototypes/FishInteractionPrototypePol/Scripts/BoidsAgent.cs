using UnityEngine;
using UnityEngine.VFX;

public class BoidsAgent : MonoBehaviour
{
    public BoidsSystem owner;
    VisualEffect vfx;
    [SerializeField] private float speed = 0.001f;
    [SerializeField] private float rotationSpeed = 4.0f;

    [SerializeField] private float maxNeighbourDistance = 3.0f; //Social Distancing (Separation)
    Vector3 averageHeading = Vector3.zero; //Alignment
    Vector3 averagePosition = Vector3.zero; //Cohesion

    private void Start()
    {
        speed = Random.Range(0.5f, 1);
        vfx = GetComponentInChildren<VisualEffect>();
    }

    void Update()
    {
        //HandleInputs();

        if (owner == null) return;
        //If out of bounds move back towards center
        if (Vector3.Distance(transform.position, owner.transform.position) >= owner.Radius)
        {
            Vector3 direction = owner.transform.position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            speed = Random.Range(0.5f, 1);
        }
        else
        {
            if (Random.Range(0, 5) < 1)
                ApplyRules();
        }
        transform.Translate(0, 0, Time.deltaTime * speed); //Move fish forward
}

    void HandleInputs()
    {
        //Really bad hacked together but i need sleept
        if (Input.GetKeyDown(KeyCode.E)){
            var player = GameObject.FindGameObjectWithTag("Player");
            if (Vector3.Distance(transform.position, player.transform.position) <= 5)
            {
                var p = player.GetComponentInChildren<BoidsSystem>();

                if (owner != p)
                {
                    vfx.transform.position = transform.position;
                    vfx.Play();
                    if (owner != null)
                        owner.agents.Remove(gameObject);
                    owner = p;
                    owner.agents.Add(gameObject);
                    transform.SetParent(p.gameObject.transform);
                }
            }
        }

        //Remove parent n stuff
        if (Input.GetKeyDown(KeyCode.Q) && owner != null)
        {
            vfx.Stop();
            owner.agents.Remove(gameObject);
            owner = null;
            transform.parent = null;         
        }
    }

    //Should perhaps push away a bit from the player?
    private void ApplyRules()
    {
        GameObject[] allAgents = owner.agents.ToArray();
        Vector3 goalPosition = owner.GoalPosition;

        averageHeading = Vector3.zero;
        averagePosition = Vector3.zero;
        float averageSpeed = 0.1f;

        int groupSize = 0;
        for(int i = 0; i < allAgents.Length; i++)
        {
            if(allAgents[i] != this)
            {
                Vector3 neighbourPosition = allAgents[i].transform.position;
                float neighbourDistance = Vector3.Distance(transform.position, neighbourPosition);
                if (neighbourDistance <= maxNeighbourDistance)
                {
                    groupSize++;

                    if (neighbourDistance < 1.0f)
                        averageHeading += transform.position - neighbourPosition;

                    averagePosition += neighbourPosition;
                    averageSpeed += allAgents[i].GetComponent<BoidsAgent>().speed;
                }
            }
        }

        if(groupSize > 0) // If fish is in a group
        {
            averagePosition = (averagePosition / groupSize) + (goalPosition - transform.position); //Calculate average center
            speed = averageSpeed / groupSize; //Average speed of group

            Vector3 newDir = averagePosition + averageHeading - transform.position; //average center + avoidance vector - current position = new direction
            if(newDir != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newDir), rotationSpeed * Time.deltaTime);
            }
        }
    }  
}
