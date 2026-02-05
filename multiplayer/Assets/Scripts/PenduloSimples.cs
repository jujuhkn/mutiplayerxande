using UnityEngine;

public class PenduloSimples : MonoBehaviour
{

    [Header("Movimento")]
    public float velocidade = 2f;
    public float anguloMax = 60f;

    [Header("Impacto no Player")]
    public float forcaEmpurrao = 60f; // FORÇA ALTA

    void Update()
    {
        float angulo = Mathf.Sin(Time.time * velocidade) * anguloMax;
        transform.rotation = Quaternion.Euler(0, 0, angulo);
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.CompareTag("Fire") ||
            colisao.gameObject.CompareTag("Water"))
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


