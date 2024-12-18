using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dodgeSpeed = 100f;
    public int dodgeStaminaUsage = 20;
    public float dodgeDistance = 1f;
    public LayerMask obstacleLayerMask;

    private float originalSpeed;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isDodging;
    
    private Vector2 dodgeStartPos;

    private Vector2 movement;
    private Vector2 lastMovement;
    private PlayerStatusManager statusManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        statusManager = GetComponent<PlayerStatusManager>();
        originalSpeed = moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((obstacleLayerMask & (1 << collision.gameObject.layer)) != 0)
        {
            isDodging = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (statusManager.stamina >= dodgeStaminaUsage)
            {
                statusManager.SubtractStamina(dodgeStaminaUsage);
                dodgeStartPos = rb.position;
                isDodging = true;
            }
        } 

        bool moving = movement.x != 0.0f || movement.y != 0.0f;

        animator.SetBool("Moving", moving);

        
        if (movement.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (movement.x > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }

    }

    void FixedUpdate()
    {
        if (isDodging)
        {
            rb.MovePosition(rb.position + lastMovement * dodgeSpeed * Time.fixedDeltaTime);
            if (Vector2.Distance(dodgeStartPos, rb.position) >= dodgeDistance)
                isDodging = false;
        }
        else if (movement != Vector2.zero) 
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            lastMovement = movement;
        }
    }
}
