using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private StateMachine stateMachine;

    [SerializeField] private State[] states;
    [HideInInspector] public MeshRenderer Renderer;
    [HideInInspector] public Animator Animator;

    [SerializeField] private AIPath path;

    public Transform AttackPoint;
    public GameObject Player { get; set; }
    public LayerMask VisionMask { get; set; }
    public AIPath Path { get => path; set => path = value; }

    public float Speed;

    private void Awake()
    {
        Renderer = GetComponent<MeshRenderer>();
        Animator = GetComponent<Animator>();
        Player = PlayerControllerKeybinds.Player.gameObject; //Get from player
        stateMachine = new StateMachine(this, states);
    }

    public void Update() => stateMachine?.HandleUpdate();
    public void FixedUpdate() => stateMachine?.HandleFixedUpdate();
    public void OnAnimationStarted() => stateMachine?.OnAnimationStarted();
    public void OnAnimationEnded() => stateMachine?.OnAnimationEnded();

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        /*if (!Application.isPlaying || Agent == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Agent.velocity);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Agent.desiredVelocity);

        Gizmos.color = Color.magenta;
        var path = Agent.path;
        Vector3 prevCorner = transform.position;
        foreach (var corner in path.corners)
        {
            Gizmos.DrawLine(prevCorner, corner);
            Gizmos.DrawSphere(corner, .2f);
            prevCorner = corner;
        }*/
    }
#endif
}
