using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    public GameObject GameOverPanel;
    public GameObject PausePanel;
    public GameObject WinPanel;

    public void TogglePause()
    {
        if (!WinPanel.activeInHierarchy && !GameOverPanel.activeInHierarchy)
        {
            if (PausePanel.activeInHierarchy)
            {
                PausePanel.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                PausePanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void Die()
    {
        if (!WinPanel.activeInHierarchy && !PausePanel.activeInHierarchy)
        {
            GameOverPanel.SetActive(true);
        }
    }

    public void Win()
    {
        if (!PausePanel.activeInHierarchy && !GameOverPanel.activeInHierarchy)
        {
            WinPanel.SetActive(true);
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
