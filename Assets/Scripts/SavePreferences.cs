using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePreferences : MonoBehaviour
{
    //
    //private int playerColor;

    public void SavePlayerInt(int num)
    {
        PlayerPrefs.SetInt("player", num);
    }
    public int LoadPlayerInt()
    {
        return PlayerPrefs.GetInt("player");
        //int playerColor = PlayerPrefs.GetInt("player");
    }
    public void SaveEnemyInt(int num)
    {
        PlayerPrefs.SetInt("enemy", num);
    }
    public int LoadEnemyInt()
    {
        return PlayerPrefs.GetInt("enemy");
        //int playerColor = PlayerPrefs.GetInt("player");
    }

}
