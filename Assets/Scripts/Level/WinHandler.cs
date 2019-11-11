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
            EnableNext();
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public void EnableNext()
    {
        print("win!");
        nextLevelButton.gameObject.SetActive(true);
    }
}
