using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoward : MonoBehaviour
{
    public float movementSpeed;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if(player)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
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
