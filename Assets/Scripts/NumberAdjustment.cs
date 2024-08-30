using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberAdjustment : MonoBehaviour
{

    private int rndSign;
    private int rndNum;
    private string divide = "\u00F7";
    private string multiply = "\u00D7";
    private GameObject text;

    public Material blue;
    public Material red;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.transform.GetChild(0).GetChild(0).gameObject;
        rndSign = Random.Range(0, 4);
        rndNum = Random.Range(0, 11);
        NumberAdjuster();
    }

    public void NumberAdjuster()
    {
        string show = "";
        if(rndSign == 0)
        {
            show = "+";
            GetComponent<Renderer>().material = blue;
        } else if(rndSign == 1)
        {
            show = "-";
            GetComponent<Renderer>().material = red;
        } else if (rndSign == 2)
        {
            show = multiply;
            if(rndNum != 0)
            {
                GetComponent<Renderer>().material = blue;
            } else
            {
                GetComponent<Renderer>().material = red;
            }
        } else if (rndSign == 3)
        {
            show = divide;
            GetComponent<Renderer>().material = red;
        }

        var selfie = text.GetComponent<TextMeshProUGUI>();
        selfie.text = (show + rndNum);
    }

    public int GetNum()
    {
        return rndNum;
    }

    public int GetSign()
    {
        return rndSign;
    }
}
