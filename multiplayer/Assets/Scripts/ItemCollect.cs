using UnityEngine;

public class ItemCollect : MonoBehaviour
{
    public Sprite newSprite; // sprite de bola

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FirePlayer") ||
            collision.CompareTag("WaterPlayer"))
        {
            TransformarPlayer(collision.gameObject);
            Destroy(gameObject);
        }
    }

    void TransformarPlayer(GameObject player)
    {
        // Troca sprite
        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
        sr.sprite = newSprite;

        // Opcional: mudar collider pra bola
        CircleCollider2D circle = player.GetComponent<CircleCollider2D>();

        if (circle == null)
        {
            player.AddComponent<CircleCollider2D>();
        }
    }
}
