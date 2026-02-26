using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{

    public void RestartScene()
    {
        Time.timeScale = 1f; // garante que o tempo volte ao normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
