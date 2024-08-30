using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSetter : MonoBehaviour
{
    private Material[] colors;
    public Material red;
    public Material orange;
    public Material yellow;
    public Material green;
    public Material blue;
    public Material indigo;
    public Material violet;
    public Material black;
    public Material white;

    public string toGet;

    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        colors = new Material[] { red, orange, yellow, green, blue, indigo, violet, white, black };
        rend = GetComponent<Renderer>();
        rend.sharedMaterial = colors[PlayerPrefs.GetInt(toGet)];
    }
}
