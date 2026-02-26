using UnityEngine;

using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject instructionsPanel;

    public void OpenInstructions()
    {
        instructionsPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseInstructions()
    {
        instructionsPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // garante que o tempo volte
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
