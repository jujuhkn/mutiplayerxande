using UnityEngine;

public class LavaHazard : MonoBehaviour
{


    public Transform waterSpawnPoint;

    [HideInInspector]
    public bool isSafe = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Mata a �GUA se n�o estiver seguro
        if (other.CompareTag("WaterPlayer") && !isSafe)
        {
            RespawnWater(other.gameObject);
        }
    }

    void RespawnWater(GameObject waterPlayer)
    {
        Rigidbody2D rb = waterPlayer.GetComponent<Rigidbody2D>();

        rb.linearVelocity = Vector2.zero;
        waterPlayer.transform.position = waterSpawnPoint.position;
    }
}