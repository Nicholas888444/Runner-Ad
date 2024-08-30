using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlashingText : MonoBehaviour
{
    private Color32 starting = new Color32(255, 0, 0, 255);
    private TextMeshProUGUI text;

    private byte opacity;
    private bool atBottom;

    // Start is called before the first frame update
    void Start()
    {
        atBottom = true;
        text = gameObject.GetComponent<TextMeshProUGUI>();
        opacity = 255;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!atBottom)
        {
            opacity--;
            SetColor();
            if(opacity == 100)
            {
                atBottom = true;
            }
        }else
        {
            opacity++;
            SetColor();
            if(opacity == 255)
            {
                atBottom = false;
            }
        }
    }

    public void SetColor()
    {
        text.color = new Color32(255, 0, 0, opacity);
    }
}
