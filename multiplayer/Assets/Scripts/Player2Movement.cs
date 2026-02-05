using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 8f;

    private Rigidbody2D rb;

    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;

    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float move = 0f;

        // Movimento pelas letras
        if (Input.GetKey(KeyCode.A))
        {
            move = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            move = 1f;
        }

        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);
    }

    void Jump()
    {
        // Checa ch�o
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundRadius,
            groundLayer
        );

        // Pulo no W
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}
