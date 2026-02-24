using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour
{
    public float timeBeforeFall = 1.5f;
    public float fallDelay = 0.5f;
    public float respawnTime = 3f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector3 startPosition;

    private bool isFalling = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        startPosition = transform.position;

        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("WaterPlayer") ||
             collision.gameObject.CompareTag("FirePlayer"))
             && !isFalling)
        {
            StartCoroutine(StartFalling());
        }
    }

    IEnumerator StartFalling()
    {
        isFalling = true;

        yield return new WaitForSeconds(timeBeforeFall);

        float timer = 0f;
        while (timer < fallDelay)
        {
            sr.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            sr.color = Color.white;
            yield return new WaitForSeconds(0.1f);
            timer += 0.2f;
        }

        rb.bodyType = RigidbodyType2D.Dynamic;

        yield return new WaitForSeconds(respawnTime);

        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.linearVelocity = Vector2.zero;
        transform.position = startPosition;
        sr.color = Color.white;

        isFalling = false;
    }
}
