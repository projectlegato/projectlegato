using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    Vector3 startLocation;
    public Vector3 endLocation;

    public float jumpSpeed;

    public float vel;

    public GameObject bulletPrefab;

    float timeForMeasure;

    Rigidbody2D rb;

    bool jumpQueued = false;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        startLocation = this.transform.position;
        rb = this.GetComponent<Rigidbody2D>();
        BeatManager.i.SubToResetEvent(ResetPlayerLoc);
        timeForMeasure = ((float)BeatManager.i.beats.Count / (float)BeatManager.i.bpm) * 60f;
        vel = Vector3.Distance(startLocation, endLocation)/timeForMeasure;
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newVelocity = rb.velocity;
        newVelocity.x = vel;
        
        if (jumpQueued)
        {
            newVelocity.y = jumpSpeed * (1f - .5f*(1f - 120f/(float)BeatManager.i.bpm)) * (BeatManager.i.subDiv ? 1f : .8f);
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

    public void ResetPlayerLoc()
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
