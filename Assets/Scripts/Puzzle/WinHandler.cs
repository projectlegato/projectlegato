using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinHandler : MonoBehaviour
{
    public Button nextLevelButton;

    int levelNum;
    void Start()
    {
        string lvlName = SceneManager.GetActiveScene().name;
        nextLevelButton.gameObject.SetActive(false);
        levelNum = Int32.Parse(lvlName.Substring(lvlName.IndexOf(" ") + 1));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EnableNext();
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public void EnableNext()
    {
        print("win!");
        PlayerPrefs.SetInt("level", levelNum + 1);
        print($"set in playerprefs {PlayerPrefs.GetInt("level")}");
        nextLevelButton.gameObject.SetActive(true);
    }
}
