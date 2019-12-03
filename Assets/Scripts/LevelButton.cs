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
        GetComponent<Button>().interactable = PlayerPrefs.GetInt("level", 1) >= lvl;
        text.text = $"{lvl}";
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene($"Level {lvl}");
    }

    public void Refresh()
    {
        GetComponent<Button>().interactable = PlayerPrefs.GetInt("level", 1) >= lvl;
        text.text = $"{lvl}";
    }
}
