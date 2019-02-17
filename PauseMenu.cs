using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool Paused = false;

    public GameObject PauseMenuUI;
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        //sets the game timer to the standard speed of the game
        Time.timeScale = 1f;
        Paused = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        //sets game timer to stop running while in pause menu
        Time.timeScale = 0f;
        Paused = true;
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        Debug.Log("Menu Loading...");
        SceneManager.LoadScene("MainMenu");

    }

    public void QuitGame()
    {
        Debug.Log("Game Quitting...");
        Application.Quit();
    }
}
