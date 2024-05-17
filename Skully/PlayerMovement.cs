using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public bool isJumping;

    public Transform feetPosition;
    public float checkRadius;
    bool isGrounded;
    public LayerMask whatIsLayer;

    public bool isClimbing;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public RubyBleu br;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        Sauter();

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
    }

    void Flip(float _velocity)
    {
        if(_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    void Sauter()
    {
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, whatIsLayer);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                rb.velocity = Vector2.up * jumpForce;
            }
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if (isGrounded == true)
            {
                rb.velocity = Vector2.up * jumpForce;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(feetPosition.position, checkRadius);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ruby"))
        {
            br.rubyCount++;
            Destroy(other.gameObject);
        }
    }
}