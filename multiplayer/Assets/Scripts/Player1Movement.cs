using UnityEngine;

public class Player1Movement : MonoBehaviour
{

    public float speed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;

    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;

    public GameObject bulletPrefab;// teste
    public Transform firePoint; //teste 


    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();


        if (Input.GetKeyDown(KeyCode.Space))// teste
        {
            Shoot();// teste
        }
    }

    void Shoot()// teste
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);// teste
    }



    void Move()
    {
        float moveInput = 0f;

        // Movimento só nas setas
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveInput = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            moveInput = 1f;
        }

        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
    }

    void Jump()
    {
        // Checa se está no chão
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundRadius,
            groundLayer
        );

        // Pulo na seta pra cima
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}