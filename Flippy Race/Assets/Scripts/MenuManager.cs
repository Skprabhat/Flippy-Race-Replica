using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    // Start is called before the first frame update
    public void pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void cancel()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void exit()
    {
        Application.Quit();
    }
    public void retry()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
