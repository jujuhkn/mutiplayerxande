using UnityEngine;

public class PlatformCoop : MonoBehaviour
{
    public Transform pointUp;
    public Transform pointDown;
    public float speed = 2f;

    public bool buttonPressed = false; // controlado pelo botão

    void Update()
    {
        if (buttonPressed)
        {
            // Desce
            transform.position = Vector2.MoveTowards(
                transform.position,
                pointDown.position,
                speed * Time.deltaTime
            );
        }
        else
        {
            // Sobe
            transform.position = Vector2.MoveTowards(
                transform.position,
                pointUp.position,
                speed * Time.deltaTime
            );
        }
    }
}
