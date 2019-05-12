using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

  
  
    public AudioSource musicSource;
     public void PlayLevel1()
     {
        SceneManager.LoadScene("TestingLevel");
     }
    public void PlayLevel2()
    {
        SceneManager.LoadScene("Familiar");
    }

    public void QuitGame()
     {
        Application.Quit();
     }

    public void PlayMusic()
    {
        if (musicSource.isPlaying)
            musicSource.Pause();
        else
            musicSource.Play();
    }
}
