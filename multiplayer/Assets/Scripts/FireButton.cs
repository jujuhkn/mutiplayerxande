using UnityEngine;

public class FireButton : MonoBehaviour
{
    public LavaHazard lava;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Só o FOGO ativa
        if (other.CompareTag("FirePlayer"))
        {
            lava.isSafe = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("FirePlayer"))
        {
            lava.isSafe = false;
        }
    }
}