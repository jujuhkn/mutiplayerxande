using UnityEngine;

public class DeathZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerRevive player = other.GetComponent<PlayerRevive>();

        if (player != null)
        {
            player.Die();
        }
    }
}
