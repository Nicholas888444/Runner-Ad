using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = transform.parent.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0.0f, 3.891f, player.transform.position.z - 2.79f);
    }
}
