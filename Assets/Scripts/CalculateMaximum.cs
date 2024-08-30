using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CalculateMaximum : MonoBehaviour
{
    private GameObject player;
    private GameObject gates;
    private GameObject left;
    private GameObject right;

    private int maximum;
    private int maxLeft;
    private int maxRight;

    private GameObject enemyText;
    private bool max;

    // Start is called before the first frame update
    void Start()
    {
        max = true;
        enemyText = gameObject.transform.GetChild(2).GetChild(0).gameObject;
        player = GameObject.Find("PlayerAndCamera/Player");
        gates = transform.parent.GetChild(1).GetChild(1).gameObject;
        left = gates.transform.GetChild(0).gameObject;
        right = gates.transform.GetChild(1).gameObject;
        CalculateMax();
        ShowMax();
    }
    
    void Update()
    {
        if(max)
        {
            CalculateMax();
            ShowMax();
            max = false;
        }
    }

    public void CalculateMax()
    {
        var playerTotal = player.transform.GetComponent<PlayerScore>();

        var leftSide = left.GetComponent<NumberAdjustment>();
        var rightSide = right.GetComponent<NumberAdjustment>();

        int currentTotal = playerTotal.GetPlayerScore();

        int symbolLeft = leftSide.GetSign();
        int numberLeft = leftSide.GetNum();

        int symbolRight = rightSide.GetSign();
        int numberRight = rightSide.GetNum();

        maxLeft = SymbolVerification(symbolLeft, currentTotal, numberLeft);
        maxRight = SymbolVerification(symbolRight, currentTotal, numberRight);

        if(maxLeft > maxRight)
        {
            maximum = maxLeft - 1;
        } else
        {
            maximum = maxRight - 1;
        }
    }

    public int SymbolVerification(int symbol, int num1, int num2)
    {
        if (symbol == 0)
        {
            return (Add(num1, num2));
        }
        else if (symbol == 1)
        {
            return (Subtract(num1, num2));
        }
        else if (symbol == 2)
        {
            return (Multiply(num1, num2));
        }
        else if (symbol == 3)
        {
            return (Divide(num1, num2));
        } else
        {
            return 0;
        }
    }

    public int Add(int num1, int num2)
    {
        if (num1 + num2 <= 0)
        {
            return 1;
        }
        else
        {
            return num1 + num2;
        }
    }

    public int Subtract(int num1, int num2)
    {
        if (num1 - num2 <= 0)
        {
            return 1;
        }
        else
        {
            return num1 - num2;
        }
    }

    public int Multiply(int num1, int num2)
    {
        if(num1 * num2 <= 0)
        {
            return 1;
        } else
        {
            return num1 * num2;
        }
    }

    public int Divide(int num1, int num2)
    {
        if(num2 == 0)
        {
            return 1;
        } else
        {
            return (num1 / num2);
        }
    }

    public void ShowMax()
    {
        var mtext = enemyText.GetComponent<TextMeshProUGUI>();
        mtext.text = "" + maximum;
    }

    public int GetScore()
    {
        return maximum;
    }
}
