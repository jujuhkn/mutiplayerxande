using UnityEngine;

public class PlayerBallForm : MonoBehaviour
{
    public KeyCode teclaTransformar;
    public Sprite spriteBola;

    private SpriteRenderer sr;
    private Rigidbody2D rb;

    private BoxCollider2D boxCol;
    private CircleCollider2D circleCol;

    private Sprite spriteNormal;
    private bool virouBola = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        boxCol = GetComponent<BoxCollider2D>();
        circleCol = GetComponent<CircleCollider2D>();

        spriteNormal = sr.sprite;
    }

    void Update()
    {
        if (Input.GetKeyDown(teclaTransformar))
        {
            Transformar();
        }
    }

    void Transformar()
    {
        if (!virouBola)
        {
            // Vira bola
            sr.sprite = spriteBola;

            boxCol.enabled = false;
            circleCol.enabled = true;

            virouBola = true;
        }
        else
        {
            // Volta normal
            sr.sprite = spriteNormal;

            boxCol.enabled = true;
            circleCol.enabled = false;

            virouBola = false;
        }
    }
}