using UnityEngine;

public class BulletController : MonoBehaviour
{

    float speed;

    float duration;

    // Start is called before the first frame update
    void Start()
    {
        speed = this.GetComponentInParent<CharController>().vel * 1.8f;
        this.GetComponent<Rigidbody2D>().velocity = speed * Vector2.right;
        duration = 60f / BeatManager.i.bpm;
        Invoke("Die", duration);
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
