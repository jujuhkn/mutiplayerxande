using UnityEngine;

public class PenduloSimples : MonoBehaviour
{

    public Sprite fireBallSprite;   // bola do Fire
    public Sprite waterBallSprite;  // bola do Water

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Se Fire pegou
        if (collision.CompareTag("Fire"))
        {
            MudarSprite(collision.gameObject, fireBallSprite);
            Destroy(gameObject);
        }

        // Se Water pegou
        if (collision.CompareTag("Water"))
        {
            MudarSprite(collision.gameObject, waterBallSprite);
            Destroy(gameObject);
        }
    }

    void MudarSprite(GameObject player, Sprite novaSprite)
    {
        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();

        if (sr != null)
        {
            sr.sprite = novaSprite;
        }
    }
}


