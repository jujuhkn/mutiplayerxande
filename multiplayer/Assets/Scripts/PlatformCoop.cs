using UnityEngine;

public class PlatformCoop : MonoBehaviour
{
    public Transform pointUp;
    public Transform pointDown;
    public float speed = 2f;

    private bool playerOn = false;
    private bool lockedDown = false;

    void Update()
    {
        // Se tem player em cima OU botão ativado → desce
        if (playerOn || lockedDown)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                pointDown.position,
                speed * Time.deltaTime
            );
        }
        else
        {
            // Senão sobe
            transform.position = Vector2.MoveTowards(
                transform.position,
                pointUp.position,
                speed * Time.deltaTime
            );
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fire") ||
            collision.gameObject.CompareTag("Water"))
        {
            playerOn = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!lockedDown)
        {
            playerOn = false;
        }
    }

    // Chamado pelo botão
    public void LockPlatform()
    {
        lockedDown = true;
    }
}
