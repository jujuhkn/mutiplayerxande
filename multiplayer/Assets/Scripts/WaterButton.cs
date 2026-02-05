using UnityEngine;

public class WaterButton : MonoBehaviour
{
    public WaterHazard water; // referência da água

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Só a ÁGUA ativa
        if (other.CompareTag("WaterPlayer"))
        {
            water.isSafe = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("WaterPlayer"))
        {
            water.isSafe = false;
        }
    }
}
