using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dodgeSpeed = 100f;
    public float dodgeStaminaUsage = 20.0f;

    private float originalSpeed;
    private Rigidbody2D rb;
    private Animator animator;

    private Vector2 movement;
    private StatusManager statusManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        statusManager = GetComponent<StatusManager>();
        originalSpeed = moveSpeed;
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
                moveSpeed = dodgeSpeed;
                statusManager.SubtractStamina(dodgeStaminaUsage);

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
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        moveSpeed = originalSpeed;
    }
}
