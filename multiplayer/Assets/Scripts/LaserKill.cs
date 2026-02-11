using UnityEngine;

public class LaserKill : MonoBehaviour
{
    public Transform spawnFire;
    public Transform spawnWater;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // FIRE
        if (collision.CompareTag("FirePlayer"))
        {
            collision.transform.position = spawnFire.position;
        }

        // WATER
        if (collision.CompareTag("WaterPlayer"))
        {
            collision.transform.position = spawnWater.position;
        }
    }

}
