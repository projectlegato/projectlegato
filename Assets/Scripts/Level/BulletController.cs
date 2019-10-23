using UnityEngine;

public class BulletController : MonoBehaviour
{

    float speed = 20f;

    float duration;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = speed * Vector2.right;
        duration = 60f / BeatManager.i.bpm;
        Invoke("Die", .5f * duration);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "KillWall") 
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
