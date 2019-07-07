using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class NPCController : MonoBehaviour
{
    [Tooltip("time in seconds to wait before seeking a new patrol destination")]
    [SerializeField] private float patrolTime = 15f;
    
    [Tooltip("distance in scene units below which the NPC will increase speed and seek the player")]
    [SerializeField] private float aggroRange = 10f;
    
    [SerializeField] private float chaseSpeed = 8f;
    
    [SerializeField] private float patrolSpeed = 4f;
    
    [Tooltip("collection of waypoints which define a patrol area")]
    public Transform[] waypoints;

    private int waypointIndex;
    private Transform player;
    private Animator animator;
    private NavMeshAgent agent;
    
    private static readonly int Speed = Animator.StringToHash("Speed");

    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.speed = patrolSpeed;
        }
        player = GameObject.FindGameObjectWithTag("Player").transform;
        waypointIndex = Random.Range(0, waypoints.Length);
        
        InvokeRepeating(nameof(Tick), 0, 0.5f);

        if (waypoints.Length > 0)
        {
            InvokeRepeating(nameof(Patrol), Random.Range(0, patrolTime), patrolTime);
        }
    }

    private void Update()
    {
        animator.SetFloat(Speed, agent.velocity.magnitude);
    }

    private void Patrol()
    {
        // move the index to the next waypoint and loop through
        waypointIndex = waypointIndex == waypoints.Length - 1 ? 0 : waypointIndex + 1;
    }

    private void Tick()
    {
        // we assume that the NPC starts at patrol state
        agent.destination = waypoints[waypointIndex].position;
        agent.speed = patrolSpeed;

        if (player != null && Vector3.Distance(transform.position, player.position) < aggroRange)
        {
            agent.destination = player.position;
            agent.speed = chaseSpeed;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}
