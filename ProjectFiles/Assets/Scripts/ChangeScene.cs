using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject pauseMenuScreen;

    public void PlayButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void PauseButton()
    {
        Time.timeScale = 0; 
        pauseMenuScreen.SetActive(true); 
        //AudioListener.pause = true; 
    }

    public void ResumeButton()
    {
        Time.timeScale = 1; 
        pauseMenuScreen.SetActive(false);
       // AudioListener.pause = false;
    }
}
