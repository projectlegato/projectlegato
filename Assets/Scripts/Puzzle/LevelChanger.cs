using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public void NextLevel(string nextLevelName)
    {
        SceneManager.LoadScene(nextLevelName);
    }

    public void PrevLevel(string prevLevelName)
    {
        SceneManager.LoadScene(prevLevelName);
    }
}
