using UnityEngine;

public class PipeTeleport : MonoBehaviour
{
    public Transform pontoSaida; // onde o player vai aparecer

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FirePlayer") || collision.CompareTag("WaterPlayer"))
        {
            collision.transform.position = pontoSaida.position;
        }
    }
}