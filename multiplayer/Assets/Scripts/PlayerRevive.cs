using UnityEngine;

public class PlayerRevive : MonoBehaviour
{
    public GameObject normalSprite;
    public GameObject bubbleSprite;

    public float floatAmplitude = 0.2f;
    public float floatFrequency = 2f;

    private Rigidbody2D rb;
    private Collider2D col;

    private Vector3 respawnPoint;
    private bool isDead = false;
    private bool isFloating = false;

    private float startY;

    public static int deadPlayers = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        respawnPoint = transform.position;

        bubbleSprite.SetActive(false);
    }

    void Update()
    {
        if (isFloating)
        {
            float newY = startY + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }

    public void Die()
    {
        if (isDead) return;

        isDead = true;
        deadPlayers++;

        if (deadPlayers >= 2)
        {
            ResetAllPlayers();
            return;
        }

        isFloating = true;

        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 0f;

        startY = respawnPoint.y;
        transform.position = respawnPoint;

        col.isTrigger = true;

        // TROCA SPRITE
        normalSprite.SetActive(false);
        bubbleSprite.SetActive(true);
    }

    public void Revive()
    {
        isDead = false;
        isFloating = false;
        deadPlayers--;

        rb.gravityScale = 1f;
        col.isTrigger = false;

        // VOLTA SPRITE NORMAL
        normalSprite.SetActive(true);
        bubbleSprite.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerRevive otherPlayer = other.GetComponent<PlayerRevive>();

        if (isFloating && otherPlayer != null && !otherPlayer.isDead)
        {
            Revive();
        }
    }

    void ResetAllPlayers()
    {
        PlayerRevive[] players = FindObjectsOfType<PlayerRevive>();

        foreach (PlayerRevive p in players)
        {
            p.isDead = false;
            p.isFloating = false;
            p.rb.gravityScale = 1f;
            p.col.isTrigger = false;
            p.transform.position = p.respawnPoint;

            p.normalSprite.SetActive(true);
            p.bubbleSprite.SetActive(false);
        }

        deadPlayers = 0;
    }
}