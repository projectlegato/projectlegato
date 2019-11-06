using UnityEngine;
using UnityEngine.UI;

public class WinHandler : MonoBehaviour
{
    public Button nextLevelButton;

    void Start()
    {
        nextLevelButton.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            print("win!");
            nextLevelButton.gameObject.SetActive(true);
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
