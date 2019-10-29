using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public float speed;

    public float rightBound;

    public float leftBound;

    void Start()
    {
        leftBound = this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)) moveRight();
        else if (Input.GetKey(KeyCode.LeftArrow)) moveLeft();

        if (this.transform.position.x > rightBound)
        {
            this.transform.position = new Vector3(rightBound, this.transform.position.y, this.transform.position.z);
        }

        if (this.transform.position.x < leftBound)
        {
            this.transform.position = new Vector3(leftBound, this.transform.position.y, this.transform.position.z);
        }
    }

    public void moveRight()
    {
        if (this.transform.position.x < rightBound)
        {
            this.transform.position += speed * Vector3.right;
        }
    }

    public void moveLeft()
    {
        if (this.transform.position.x > leftBound)
        {
            this.transform.position += speed * Vector3.left;
        }
    }
}
