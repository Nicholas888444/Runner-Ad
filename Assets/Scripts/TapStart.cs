using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapStart : MonoBehaviour
{
    private Animator animator;
    //animator.SetBool(animationname, t/f);

    public GameObject player;
    public GameObject playerAndCam;

    private TapStart tps;

    //private MoveFoward mf;
    private PlayerMove pm;

    // Start is called before the first frame update
    void Start()
    {
        animator = player.GetComponent<Animator>();
        //mf = playerAndCam.GetComponent<MoveFoward>();
        pm = player.GetComponent<PlayerMove>();
        tps = GetComponent<TapStart>();

        DisableMove();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            EnableMove();
        }
    }

    public void DisableMove()
    {
        //mf.enabled = false;
        pm.enabled = false;
    }

    public void EnableMove()
    {
        //mf.enabled = true;
        pm.enabled = true;

        tps.enabled = false;
        Run();
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void Run()
    {
        animator.SetBool("Idling", false);
        animator.SetBool("Running", true);
    }
}
