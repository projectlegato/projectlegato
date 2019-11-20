using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelButton : MonoBehaviour
{
    public int lvl;

    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("level", 1) < lvl)
        {
            GetComponent<Button>().interactable = false;
        }
        else
        {
            GetComponent<Button>().interactable = true;
        }
        text.text = $"{lvl}";
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene($"Level {lvl}");
    }
}
