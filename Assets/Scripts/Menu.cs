using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject levelSelect;

    private void Start()
    {
        mainMenu.SetActive(true);
        levelSelect.SetActive(false);
    }

    public void PlayButton()
    {
        mainMenu.SetActive(false);
        levelSelect.SetActive(true);
    }

    public void Back()
    {
        mainMenu.SetActive(true);
        levelSelect.SetActive(false);
    }
}
