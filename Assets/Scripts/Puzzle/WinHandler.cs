using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinHandler : MonoBehaviour
{
    public AudioSource youWin;
    public Button nextLevelButton;

    public int levelNum;

    public Color target;

    public bool isLast = false;

    bool done = false;
    void Start()
    {
        done = false;
        string lvlName = SceneManager.GetActiveScene().name;
        levelNum = Int32.Parse(lvlName.Substring(lvlName.IndexOf(" ") + 1));
        if (!isLast && PlayerPrefs.GetInt("level", 1) <= levelNum)
        {
            nextLevelButton.gameObject.SetActive(false);
        }
        else
        {
            nextLevelButton.gameObject.SetActive(true);
        }
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
        // print("win!");
        if (done) return;
        PlayerPrefs.SetInt("level", levelNum + 1);
        // print($"set in playerprefs {PlayerPrefs.GetInt("level")}");
        youWin.Play();
        StartCoroutine(FlashyWin());
    }

    private IEnumerator FlashyWin()
    {
        Vector3 targetScale = Vector3.one * 2f;
        Vector3 startScale = nextLevelButton.transform.localScale;
        float t = 0f;
        float duration = .2f;

        nextLevelButton.gameObject.SetActive(true);
        Color orig = nextLevelButton.GetComponent<Image>().color;
        // print($"target color {target}");
        nextLevelButton.GetComponent<Image>().color = target;
        while (t < duration)
        {
            t += Time.deltaTime;
            nextLevelButton.transform.localScale = Vector3.Lerp(startScale, targetScale, t / duration);
            yield return null;
        }

        t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            nextLevelButton.transform.localScale = Vector3.Lerp(targetScale, startScale, t / duration);
            yield return null;
        }
        nextLevelButton.GetComponent<Image>().color = orig;
        done = true;
        yield break;
    }
}
