using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    [Header("Configura��o do Pulo")]
    public float jumpForce = 10f;
    public KeyCode jumpKey = KeyCode.W;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundRadius = 0.3f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckGround();
        HandleJump();
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundRadius,
            groundLayer
        );
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}
