using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject levelSelect;

    public GameObject clearSaveConfirmation;

    public List<LevelButton> buttons;

    private void Start()
    {
        Application.targetFrameRate = 15;
        mainMenu.SetActive(true);
        levelSelect.SetActive(false);
        clearSaveConfirmation.SetActive(false);
    }

    public void PlayButton()
    {
        mainMenu.SetActive(false);
        levelSelect.SetActive(true);
        clearSaveConfirmation.SetActive(false);
    }

    public void Back()
    {
        mainMenu.SetActive(true);
        clearSaveConfirmation.SetActive(false);
        levelSelect.SetActive(false);
    }

    [ContextMenu("Clear User Saves")]
    public void ClearSaves()
    {
        PlayerPrefs.DeleteAll();
        foreach (var button in buttons) button.Refresh();
        Back();
    }

    public void ClearSaveButton()
    {
        mainMenu.SetActive(false);
        clearSaveConfirmation.SetActive(true);
        levelSelect.SetActive(false);
    }
}
