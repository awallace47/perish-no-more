using Pathfinding;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public float attackRange = 1f;
    public float aggroRange = 5f;
    public Animator animator;
    private Path path;
    private int currentWaypoint;
    private bool reachedEndOfPath = false;

    private Seeker seeker;
    private Rigidbody2D rb;
    private EnemyAttack enemyAttack;
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").transform;
        enemyAttack = GetComponent<EnemyAttack>();
        InvokeRepeating("UpdatePath", 0f, 0.05f);
        
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {

        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        } 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceToPlayer = Vector2.Distance(rb.position, target.position);

        if (distanceToPlayer < attackRange)
        {
            enemyAttack.Attack();
        }

        if (path == null) return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            animator.SetBool("Moving", false);
            return;
        } else
        {
            reachedEndOfPath = false;
        }

        if (distanceToPlayer > aggroRange)
        {
            animator.SetBool("Moving", false);
            return;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.fixedDeltaTime;

        animator.SetBool("Moving", true);
        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (rb.velocity.x >= 0.05f)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else if (rb.velocity.x <= -0.05f) 
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
