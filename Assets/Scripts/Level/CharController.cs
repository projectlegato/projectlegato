using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public Vector3 startLocation;
    public Vector3 endLocation;

    public float jumpSpeed;

    public float vel;

    public GameObject bulletPrefab;

    float timeForMeasure;

    Rigidbody2D rb;

    bool jumpQueued = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        BeatManager.i.SubToResetEvent(ResetLemmingLoc);
        timeForMeasure = ((float)BeatManager.i.beats.Count / (float)BeatManager.i.bpm) * 60f;
        vel = Vector3.Distance(startLocation, endLocation)/timeForMeasure;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newVelocity = rb.velocity;
        newVelocity.x = vel;
        
        if (jumpQueued)
        {
            newVelocity.y = jumpSpeed * (1f - .5f*(1f - 120f/(float)BeatManager.i.bpm));
            jumpQueued = false;
        }
        rb.velocity = newVelocity;
    }
    
    public void Jump()
    {
        jumpQueued = true;
    }

    public void Shoot()
    {
        GameObject newBullet;
        newBullet = GameObject.Instantiate(bulletPrefab);
        newBullet.transform.parent = this.transform;
        newBullet.transform.position = this.transform.position + (Vector3.right * .4f);
    }

    public void ResetLemmingLoc()
    {
        this.transform.position = startLocation;
        this.rb.velocity = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            this.transform.position += Vector3.down * 10f;
        }
    }
}
