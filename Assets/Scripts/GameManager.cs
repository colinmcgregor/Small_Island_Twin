using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject[] gameOverObjects;
    GameObject[] pauseMenuObjects;
    PlayerController player;

    void Start()
    {
        Time.timeScale = 1;
        
        gameOverObjects = GameObject.FindGameObjectsWithTag("Game_Over");
        pauseMenuObjects = GameObject.FindGameObjectsWithTag("Pause_Menu");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        
        HidePauseMenu();
        HideGameOverMenu();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                ShowPauseMenu();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                HidePauseMenu();
            }
        }

        if (Time.timeScale == 0 && !player.isAlive)
        {
            ShowGameOverMenu();
        }
    }

    public void PlayButton()
    {
        Time.timeScale = 1;
        HidePauseMenu();
    }

    public void ShowPauseMenu()
    {
        foreach (GameObject item in pauseMenuObjects)
        {
            item.SetActive(true);
        }
    }

    public void HidePauseMenu()
    {
        foreach (GameObject item in pauseMenuObjects)
        {
            item.SetActive(false);
        }
    }

    public void ShowGameOverMenu()
    {
        foreach (GameObject item in gameOverObjects)
        {
            item.SetActive(true);
        }
    }

    public void HideGameOverMenu()
    {
        foreach (GameObject item in gameOverObjects)
        {
            item.SetActive(false);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level_01");
    }

    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
