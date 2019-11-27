using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public void NextLevel()
    {
        var winner = GameObject.FindObjectOfType<WinHandler>();
        SceneManager.LoadScene($"Level {winner.levelNum + 1}");
    }

    public void PrevLevel()
    {
        var winner = GameObject.FindObjectOfType<WinHandler>();
        SceneManager.LoadScene($"Level {winner.levelNum - 1}");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
