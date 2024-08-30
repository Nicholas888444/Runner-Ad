using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    private Animator animator;
    private int playerScore = 1;
    private GameObject scoreText;
    private TextMeshProUGUI textField;
    public DeathScreen deathScreen;
    private int gateScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        textField = gameObject.transform.GetChild(2).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        NumberAdjuster();
    }

    public void SetPlayerScore(int score)
    {
        this.playerScore = score;
        NumberAdjuster();
        if(playerScore <= 0)
        {
            //Destroy(gameObject);
            Die();
        }
    }

    public int GetPlayerScore()
    {
        return playerScore;
    }

    public void NumberAdjuster()
    {
        textField.text = "" + playerScore;
    }

    public void Die()
    {
        animator.SetBool("Fighting", false);
        animator.SetBool("Running", false);
        animator.SetTrigger("Dead");
        deathScreen.EnableDeathScreen(gateScore);
    }

    public void IncrementGateScore() {
        gateScore += 1;
    }


}
