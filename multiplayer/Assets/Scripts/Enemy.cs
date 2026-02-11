using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject itemDrop; // prefab do item

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Se player encostar, enemy morre
        if (collision.gameObject.CompareTag("Fire") ||
            collision.gameObject.CompareTag("Water"))
        {
            Die();
        }
    }

    void Die()
    {
        // Spawnar item
        Instantiate(itemDrop, transform.position, Quaternion.identity);

        // Destruir enemy
        Destroy(gameObject);
    }
}