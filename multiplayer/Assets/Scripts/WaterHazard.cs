using UnityEngine;

public class WaterHazard : MonoBehaviour
{
    public Transform fireSpawnPoint;

    [HideInInspector]
    public bool isSafe = false; // controlado pelo botão

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FirePlayer") && !isSafe)
        {
            RespawnFire(other.gameObject);
        }
    }

    void RespawnFire(GameObject firePlayer)
    {
        Rigidbody2D rb = firePlayer.GetComponent<Rigidbody2D>();

        rb.linearVelocity = Vector2.zero;
        firePlayer.transform.position = fireSpawnPoint.position;
    }
}
