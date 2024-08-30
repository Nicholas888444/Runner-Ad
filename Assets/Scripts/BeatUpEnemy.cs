using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatUpEnemy : MonoBehaviour
{
    private Animator animator;

    private GameObject player;
    private GameObject enemy;
    private GameObject fightDetector;

    private PlayerScore playerScore;
    private int enemyScore;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("/PlayerAndCamera/Player");
        playerScore = player.GetComponent<PlayerScore>();

        enemy = gameObject;
        enemyScore = enemy.GetComponent<CalculateMaximum>().GetScore();

        fightDetector = gameObject.transform.parent.GetChild(3).gameObject;
        animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter()
    {
        Fight();
    }

    public void Fight()
    {
        animator.SetBool("Running", false);
        animator.SetBool("Fighting", true);
        fightDetector.GetComponent<Fight>().SetMoving(false);
        DoDelayAction(3.0f);
    }

    void DoDelayAction(float delayTime)
    {
        StartCoroutine(DelayAction(delayTime));
    }

    IEnumerator DelayAction(float delayTime)
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);

        int ps = playerScore.GetPlayerScore();
        int results = ps - enemyScore;
        //playerScore.SetPlayerScore(results);
        if (results > 0)
        {
            animator.SetBool("Running", true);
            animator.SetBool("Fighting", false);
            player.GetComponent<PlayerMove>().enabled = true;

        } else {
            player.GetComponent<PlayerScore>().Die();
        }

        //Do the action after the delay time has finished.
    }
}
