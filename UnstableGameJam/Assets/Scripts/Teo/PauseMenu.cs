using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public string levelToLoad;
    public GameObject pauseMenuUI;

    public void Start()
    {
        print("La scene ? ?t? charg?.");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }

    }

    private void Paused()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public void loadMainMenu()
    {
        Resume();
        SceneManager.LoadScene(levelToLoad);
        //AudioManager.instance.Play("BgMusic");
        //AudioManager.instance.Stop("MenuMusic");
    }
}
