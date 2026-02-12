using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashForce = 15f;
    public float dashDuration = 0.2f;
    public float doubleTapTime = 0.3f;

    private Rigidbody2D rb;
    private float lastTapTime;
    private bool isDashing;

    // Escolher tecla
    public bool isFirePlayer; // marca no Inspector

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDashing) return;

        // PLAYER FOGO → tecla D
        if (isFirePlayer)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                CheckDoubleTap(Vector2.right);
            }
        }
        // PLAYER ÁGUA → seta direita
        else
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                CheckDoubleTap(Vector2.right);
            }
        }
    }

    void CheckDoubleTap(Vector2 direction)
    {
        if (Time.time - lastTapTime <= doubleTapTime)
        {
            StartCoroutine(Dash(direction));
        }

        lastTapTime = Time.time;
    }

    System.Collections.IEnumerator Dash(Vector2 direction)
    {
        isDashing = true;

        rb.linearVelocity = Vector2.zero;
        rb.AddForce(direction * dashForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(dashDuration);

        rb.linearVelocity = Vector2.zero;
        isDashing = false;
    }
}