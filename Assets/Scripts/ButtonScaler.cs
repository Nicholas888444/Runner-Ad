using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ButtonScaler : MonoBehaviour
{

    public Button red;
    public Button orange;
    public Button yellow;
    public Button green;
    public Button blue;
    public Button indigo;
    public Button violet;
    public Button white;
    public Button black;

    public Button enemy;
    public Button player;

    private int enemyColor;
    private int playerColor;

    private Button[] Buttons;

    private MainMenuHandler mmh;
    private SavePreferences sp;

    private Outline playerOutline;
    private Outline enemyOutline;


    // Start is called before the first frame update
    void Start()
    {
        sp = gameObject.GetComponent<SavePreferences>();
        mmh = gameObject.GetComponent<MainMenuHandler>();
        Buttons = new Button[] {red, orange, yellow, green, blue, indigo, violet, white, black};
        playerColor = sp.LoadPlayerInt();
        enemyColor = sp.LoadEnemyInt();
        playerOutline = player.gameObject.GetComponent<Outline>();
        enemyOutline = enemy.gameObject.GetComponent<Outline>();
        ScalePlayer();
        ScalePlayerButton();
    }

    public void ScaleEnemyButton()
    {
        Buttons[enemyColor].transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        UnoutlineColors();
        Buttons[enemyColor].gameObject.GetComponent<Outline>().enabled = true;
    }

    public void ScalePlayerButton()
    {
        Buttons[playerColor].transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        UnoutlineColors();
        Buttons[playerColor].gameObject.GetComponent<Outline>().enabled = true;
    }

    public void DescaleAllButtons()
    {
        for(int x = 0; x <= 8; x++)
        {
            Buttons[x].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    public void UnoutlineColors()
    {
        for (int x = 0; x <= 8; x++)
        {
            Buttons[x].gameObject.GetComponent<Outline>().enabled = false;
        }
    }

    public void ScaleEnemy()
    {
        enemy.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        enemyOutline.enabled = true;
        playerOutline.enabled = false;
    }

    public void ScalePlayer()
    {
        player.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        playerOutline.enabled = true;
        enemyOutline.enabled = false;
    }

    public void DescalePE()
    {
        player.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        enemy.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    public bool GetMode()
    {
        return mmh.GetMode();
    }

    public void Set(int col)
    {
        if(GetMode())
        {
            playerColor = col;
            ScalePlayerButton();
        } else
        {
            enemyColor = col;
            ScaleEnemyButton();
        }
    }
}
