using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatforms : MonoBehaviour
{
    private GameObject endingPoint;
    public GameObject platform;
    private int maximum;

    // Start is called before the first frame update
    void Start()
    {
        /*Transform child = transform.GetChild(transform.childCount - 1);
        Debug.Log("Child Count: " + transform.childCount);
        Debug.Log(child.name);*/
        endingPoint = this.gameObject.transform.GetChild(0).GetChild(1).gameObject;
    }


    public void SpawnPlatform()
    {
        Instantiate(platform, endingPoint.transform.position, Quaternion.identity).name = platform.name;
    }

    public void DeletePlatform()
    {
        Destroy(gameObject, 10.0f);
    }

    public void SetMax(int m)
    {
        maximum = m;
    }

    public int GetMax()
    {
        return maximum;
    }
}
