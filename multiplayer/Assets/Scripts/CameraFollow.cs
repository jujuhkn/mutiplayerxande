using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player1;
    public Transform player2;

    public float smoothSpeed = 5f;
    public Vector3 offset;

    void LateUpdate()
    {
        if (player1 == null && player2 == null)
            return;

        Vector3 centerPoint = GetCenterPoint();
        Vector3 desiredPosition = centerPoint + offset;

        Vector3 smoothedPosition = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        transform.position = new Vector3(
            smoothedPosition.x,
            smoothedPosition.y,
            transform.position.z
        );
    }

    Vector3 GetCenterPoint()
    {
        if (player1 == null)
            return player2.position;

        if (player2 == null)
            return player1.position;

        return (player1.position + player2.position) / 2f;
    }
}
