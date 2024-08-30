using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject options;
    public GameObject colorOptions;

    public GameObject playerBody;
    private Renderer rendPlayer;
    public GameObject enemyBody;
    private Renderer rendEnemy;

    private bool mode;
    private int count;
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

    private SavePreferences saveColors;


    void Start()
    {
        saveColors = gameObject.GetComponent<SavePreferences>();
        colors = new Material[] {red, orange, yellow, green, blue, indigo, violet, white, black};
        mode = true;
        rendPlayer = playerBody.GetComponent<Renderer>();
        rendEnemy = enemyBody.GetComponent<Renderer>();
        LoadMenu();
        LoadSavedColors();
    }

    public void LoadSavedColors()
    {
        rendPlayer.sharedMaterial = colors[saveColors.LoadPlayerInt()];
        rendEnemy.sharedMaterial = colors[saveColors.LoadEnemyInt()];
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadMenu()
    {
        options.SetActive(false);
        colorOptions.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void LoadOptions()
    {
        mainMenu.SetActive(false);
        colorOptions.SetActive(false);
        options.SetActive(true);
    }

    public void LoadColors()
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        colorOptions.SetActive(true);
    }


    //Stuff for color below

    public void SetModePlayer()
    {
        mode = true;
    }

    public void SetModeEnemy()
    {
        mode = false;
    }

    public bool GetMode()
    {
        return mode;
    }

    public void SetColor()
    {
        if(mode)
        {
            rendPlayer.sharedMaterial = colors[count];
            saveColors.SavePlayerInt(count);
        } else
        {
            rendEnemy.sharedMaterial = colors[count];
            saveColors.SaveEnemyInt(count);
        }
    }

    public void sc(int col)
    {
        count = col;
    }

    public void scaleFirst()
    {
        if (mode)
        {
            //scale players and player button
        }
        else
        {

        }
    }
}
