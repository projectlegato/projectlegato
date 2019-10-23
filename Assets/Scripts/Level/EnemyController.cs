using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    SpriteRenderer sr;
    BoxCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        col = this.GetComponent<BoxCollider2D>();
        BeatManager.i.SubToResetEvent(Reset);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bullet") 
        {
            sr.enabled = false;
            col.enabled = false;
            Destroy(other.gameObject);
        }
    }
    
    void Reset()
    {
        sr.enabled = true;
        col.enabled = true;
    }
}
