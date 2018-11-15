using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;
    public bool isGameOver = false;


    public GameObject pauseMenuUI;
    public GameObject gameOverUI;
    public GameObject[] uiElementsToDisable;

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)
            || Input.GetKeyDown(KeyCode.Space))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }

        }
        if (isGameOver)
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
	}

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        showOtherUiElements(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        showOtherUiElements(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void showOtherUiElements(bool show)
    {
       foreach (GameObject o in uiElementsToDisable)
        {
            if (show)
            {
                o.SetActive(true);
            } else
            {
                o.SetActive(false);
            }
        }
    }
}
