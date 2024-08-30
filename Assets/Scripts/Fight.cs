using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    private GameObject enemy;
    private GameObject playerAndCamera;
    private GameObject player;
    private float movementSpeed;
    private bool moveFoward = false;

    private PlayerMove playerMove;
    private MoveFoward cameraMove;
    private Vector3 headingTo;
    private Vector3 CamTo;


    // Start is called before the first frame update
    void Start()
    {

        enemy = gameObject.transform.parent.GetChild(2).gameObject;
        playerAndCamera = GameObject.Find("/PlayerAndCamera");
        player = playerAndCamera.transform.GetChild(0).gameObject;

        playerMove = player.GetComponent<PlayerMove>();
        //cameraMove = playerAndCamera.GetComponent<MoveFoward>();
        movementSpeed = playerMove.GetSpeed();
    }

    void Update()
    {
        if (moveFoward)
        {
            //player.transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
            player.transform.Translate(headingTo * Time.deltaTime * movementSpeed/10);
            //playerAndCamera.transform.Translate(CamTo * Time.deltaTime * movementSpeed/10);
        }
    }

    void OnTriggerEnter()
    {
        CenterPlayer();
        moveFoward = true;
    }

    public void CenterPlayer()
    {
        playerMove.enabled = false;
        //cameraMove.enabled = false;


        //Points from player to enemy

        headingTo = enemy.transform.position - player.transform.position;
        //CamTo = enemy.transform.position - playerAndCamera.transform.position;
        //player.transform.Rotate(headingTo);

    }

    public void SetMoving(bool v)
    {
        moveFoward = v;
    }

}
