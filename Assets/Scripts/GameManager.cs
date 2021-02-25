using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject[] gameOverObjects;
    PlayerController player;

    void Start()
    {
        Time.timeScale = 1;
        gameOverObjects = GameObject.FindGameObjectsWithTag("Game_Over");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        HideGameOver();
    }

    void Update()
    {
        if (Time.timeScale == 0 && !player.isAlive)
        {
            ShowGameOver();
        }
    }

    public void ShowGameOver()
    {
        foreach (GameObject item in gameOverObjects)
        {
            item.SetActive(true);
        }
    }

    public void HideGameOver()
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
