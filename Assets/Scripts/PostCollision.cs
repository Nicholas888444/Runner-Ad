using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostCollision : MonoBehaviour
{
    private GameObject player;
    private GameObject playerAndCamera;

    private Animator animator;
    private PlayerScore ps;

    // Start is called before the first frame update
    void Start()
    {
        playerAndCamera = GameObject.Find("PlayerAndCamera");
        player = playerAndCamera.transform.GetChild(0).gameObject;
        ps = player.GetComponent<PlayerScore>();
        animator = player.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Die();
        }
    }

    public void Die()
    {
        animator.SetBool("Running", false);
        animator.SetBool("Dead", true);

        //Destroy(player, 10.0f);

        /*var moveFoward = player.GetComponent<PlayerMove>();
        moveFoward.adjustSpeed(0.0f);*/

        var movement = player.transform.GetComponent<PlayerMove>();
        movement.adjustSpeed(0.0f);
        ps.Die();
    }
}
