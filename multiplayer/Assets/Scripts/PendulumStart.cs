using UnityEngine;

public class PendulumStart : MonoBehaviour
{

    public float startForce = 250f;

    void Start()
    {
        GetComponent<Rigidbody2D>()
            .AddForce(Vector2.right * startForce);
    }
}
