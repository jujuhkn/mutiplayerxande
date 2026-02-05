using UnityEngine;

public class PenduloSimples : MonoBehaviour
{

    [Header("Movimento")]
    public float velocidade = 2f;
    public float anguloMax = 60f;

    [Header("Impacto no Player")]
    public float forcaEmpurrao = 10f;

    void Update()
    {
        float angulo = Mathf.Sin(Time.time * velocidade) * anguloMax;
        transform.rotation = Quaternion.Euler(0, 0, angulo);
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        // Verifica as duas tags
        if (colisao.gameObject.CompareTag("FirePlayer") ||
            colisao.gameObject.CompareTag("WaterPlayer"))
        {
            Rigidbody2D rbPlayer = colisao.gameObject.GetComponent<Rigidbody2D>();

            if (rbPlayer != null)
            {
                Vector2 direcao = colisao.transform.position - transform.position;
                direcao = direcao.normalized;

                rbPlayer.AddForce(direcao * forcaEmpurrao, ForceMode2D.Impulse);
            }
        }
    }
}
