using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float movementSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.transform.position.x > -4)
            {
                this.transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if(this.transform.position.x < 4)
            {
                this.transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
            }
        }
    }

    public void adjustSpeed(float x)
    {
        movementSpeed = x;
    }

    public float GetSpeed()
    {
        return movementSpeed;
    }
}
