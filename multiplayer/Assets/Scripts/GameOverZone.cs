using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverZone : MonoBehaviour
{
    public string menuSceneName = "Menu";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WaterPlayer") ||
            collision.CompareTag("FirePlayer"))
        {
            Time.timeScale = 1f; // garante que o tempo não esteja pausado
            SceneManager.LoadScene(menuSceneName);
        }
    }
}