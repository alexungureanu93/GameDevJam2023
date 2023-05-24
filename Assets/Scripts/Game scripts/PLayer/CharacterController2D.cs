using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isJumping;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // Handle horizontal movement
        float moveX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // Handle jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        // Apply jump force
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize ground check circle
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, 0.1f);
    }

        public void Die()
    {
        Destroy(gameObject);
    }
}