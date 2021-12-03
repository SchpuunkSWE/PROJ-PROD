using UnityEngine;

public class TrashPileMover : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    private Transform[] targetPoints;

    private int targetIndex = 0;

    void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        Transform target = targetPoints[targetIndex];
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (transform.position == target.position) 
        {
            ChooseNextTarget();
        }
    }

    private void ChooseNextTarget()
    {
        switch (targetIndex)
        {
            case 0:
                targetIndex = 1;
                break;
            case 1:
                targetIndex = 2;
                break;
            case 2:
                targetIndex = 0;
                break;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Vector3 prevCorner = targetPoints[0].position;
        foreach (var corner in targetPoints)
        {
            Gizmos.DrawLine(prevCorner, corner.position);
            Gizmos.DrawSphere(corner.position, .2f);
            prevCorner = corner.position;
        }
        Gizmos.DrawLine(prevCorner, targetPoints[0].position);
    }
}
