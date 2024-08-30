using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject dead;

    public void Start()
    {
        DisableDeathScreen();
    }

    public void EnableDeathScreen(int x)
    {
        dead.SetActive(true);
        dead.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You Died! \nGates Passed: " + x;
    }

    public void DisableDeathScreen()
    {
        dead.SetActive(false);
    }


    public void LoadGame()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
