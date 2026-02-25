using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string FinalScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WaterPlayer") ||
            collision.CompareTag("FirePlayer"))
        {
            SceneManager.LoadScene(FinalScene);
        }
    }

}
