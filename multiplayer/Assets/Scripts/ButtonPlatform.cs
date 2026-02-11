using UnityEngine;

public class ButtonPlatform : MonoBehaviour
{

    public PlatformCoop platform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FirePlayer") ||
            collision.CompareTag("WaterPlayer"))
        {
            platform.LockPlatform();
        }
    }
}