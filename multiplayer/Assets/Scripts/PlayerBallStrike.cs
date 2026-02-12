using UnityEngine;

public class PlayerBallStrike : MonoBehaviour
{
    public KeyCode teclaTransformar;
    public Sprite spriteBola;
    public float forca = 15f;

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Sprite spriteNormal;
    private bool virouBola = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
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
            virouBola = true;

            // Impulso pra frente
            float direcao = transform.localScale.x;
            rb.AddForce(new Vector2(direcao * forca, 5f), ForceMode2D.Impulse);
        }
        else
        {
            // Volta normal
            sr.sprite = spriteNormal;
            virouBola = false;
        }
    }
}