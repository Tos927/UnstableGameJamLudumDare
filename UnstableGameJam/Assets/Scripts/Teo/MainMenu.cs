using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;

    public AudioSource audioSource;
    public AudioClip pressed;

    public GameObject settingsWindow;

    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
        audioSource.PlayOneShot(pressed);
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
