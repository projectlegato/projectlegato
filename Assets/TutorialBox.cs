using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBox : MonoBehaviour
{
    List<SpriteRenderer> gameSprites;
    private void Start()
    {
        BeatManager.i.PauseToggle();
        gameSprites = new List<SpriteRenderer>(BeatManager.i.GetComponentsInChildren<SpriteRenderer>());
        // foreach (var row in PuzzleManager.i.GetComponentsInChildren<PuzzleRow>())
        // {
        //     gameSprites.AddRange(row.GetComponentsInChildren<SpriteRenderer>());
        // }
        print($"grid length {gameSprites.Count}");
        foreach (var s in gameSprites) s.enabled = false;
        PuzzleManager.i.gameObject.SetActive(false);
    }
    public void CloseBox()
    {
        this.gameObject.SetActive(false);
        foreach (var s in gameSprites) s.enabled = true;
        PuzzleManager.i.gameObject.SetActive(true);
        BeatManager.i.PauseToggle();
    }
}
