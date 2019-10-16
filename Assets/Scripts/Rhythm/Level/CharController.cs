using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public Vector3 startLocation;
    public Vector3 endLocation;

    public float jumpSpeed;

    public GameObject bulletPrefab;

    float timeForMeasure;

    Rigidbody2D rb;

    bool jumpQueued = false;

    // Start is called before the first frame update
    void Start()
    {
        MetronomeController.instance.AddInstrumentToBeat(ResetLemmingLoc, 0);
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timeForMeasure = 240f/(float)MetronomeController.instance.bpm;
        Vector2 newVelocity = rb.velocity;
        newVelocity.x = (Vector3.Distance(startLocation, endLocation)/timeForMeasure);
        
        if (jumpQueued)
        {
            newVelocity.y = jumpSpeed;
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
        newBullet.transform.position = this.transform.position + (Vector3.right * .1f);
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
