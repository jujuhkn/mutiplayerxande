using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject instructionsPanel;

    public void OpenInstructions()
    {
        instructionsPanel.SetActive(true);
        Time.timeScale = 0f; // pausa o jogo
    }

    public void CloseInstructions()
    {
        instructionsPanel.SetActive(false);
        Time.timeScale = 1f; // volta o jogo
    }
}