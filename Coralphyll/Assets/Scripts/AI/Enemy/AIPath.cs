using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
//Should make it into a linked list or smthing
public class AIPath : MonoBehaviour
{
    [SerializeField] private List<Transform> path;
    private int current = 0;
    
    public List<Transform> GetPath { get => path; }
    public Transform Next()
    {
        current += 1;
        if (current >= path.Count)
            current = 0;
        return path[current];
    }

    public Transform Current()
    {
        return path[current];
    }
 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Vector3 prevCorner = path[0].position;
        foreach (var corner in path)
        {
            Gizmos.DrawLine(prevCorner, corner.position);
            Gizmos.DrawSphere(corner.position, .2f);
            prevCorner = corner.position;
        }
        Gizmos.DrawLine(prevCorner, path[0].position);
    }
}
