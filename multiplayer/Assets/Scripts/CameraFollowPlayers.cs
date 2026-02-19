using UnityEngine;

public class CameraFollowPlayers : MonoBehaviour
{
    public Transform player1;
    public Transform player2;

    public float smoothSpeed = 5f;
    public Vector3 offset;

    void LateUpdate()
    {
        if (player1 == null || player2 == null) return;

        // Calcula o meio entre os dois
        Vector3 middlePoint = (player1.position + player2.position) / 2f;

        // Posição desejada da câmera
        Vector3 desiredPosition = middlePoint + offset;

        // Suaviza o movimento
        Vector3 smoothedPosition = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        transform.position = smoothedPosition;
    }
}
