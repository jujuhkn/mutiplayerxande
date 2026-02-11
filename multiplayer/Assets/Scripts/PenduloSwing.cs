using UnityEngine;

public class PenduloSwing : MonoBehaviour
{
    public float angle = 45f;   // ângulo máximo
    public float speed = 2f;   // velocidade

    void Update()
    {
        float rot = Mathf.Sin(Time.time * speed) * angle;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

}
