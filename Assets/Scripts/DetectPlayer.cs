using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    private GameObject player;
    private GameObject scaler;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerAndCamera/Player");
        scaler = gameObject.transform.GetChild(0).GetChild(0).gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            SpawnPlatforms();
            AdjustScore();
            other.gameObject.GetComponent<PlayerScore>().IncrementGateScore();
        }
    }

    public void SpawnPlatforms()
    {
        var pare = gameObject.transform.parent.parent.parent.GetComponent<SpawnPlatforms>();
        pare.SpawnPlatform();
        pare.DeletePlatform();
    }

    public void AdjustScore()
    {
        var scoreKeep = player.GetComponent<PlayerScore>();
        var numAdjust = gameObject.GetComponent<NumberAdjustment>();

        int pScore = scoreKeep.GetPlayerScore();
        int symbol = numAdjust.GetSign();
        int num = numAdjust.GetNum();

        if(symbol == 0)
        {
            if(pScore + num > 0)
            {
                pScore = pScore + num;
            } else
            {
                pScore = 1;
            }
        } else if(symbol == 1)
        {
            if (pScore - num > 0)
            {
                pScore = pScore - num;
            }
            else
            {
                pScore = 1;
            }
        } else if(symbol == 2)
        {
            if ((pScore * num ) != 0)
            {
                pScore = pScore * num;
            }
            else
            {
                pScore = 1;
            }
        } else if(symbol == 3)
        {
            if (num != 0)
            {
                if (pScore / num != 0)
                {
                    pScore = pScore / num;
                } else
                {
                    pScore = 1;
                }
            } else
            {
                pScore = 1;
            }
        }

        scoreKeep.SetPlayerScore(pScore);

    }
}
