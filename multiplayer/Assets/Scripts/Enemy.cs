using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int life = 1;
    public float speed = 2f;
    private Rigidbody2D rb;
    private bool movingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (movingRight)
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
        else
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // vira quando bate em parede
        if (collision.gameObject.CompareTag("Wall"))
        {
            movingRight = !movingRight;
            Flip();
        }
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void TakeDamage()
    {
        life--;

        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

}