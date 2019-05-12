using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

  bool uiMusicEnabled;
  
    public AudioSource[] generalMusic;
    public AudioSource uiMusic;
    bool uiMusicEnabler=true;
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

    public void EnableMusic()
    {
        for (int i = 0; i < generalMusic.Length; i++)
        {
            if (generalMusic[i].isPlaying)
                generalMusic[i].Pause();
            else
                generalMusic[i].Play();
        }
    }

    public void SetFullcreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void UImusic()
    {
        if (uiMusicEnabler==true)
        {
            uiMusic.Play();
        }
    }
    public void UImusicEnabler()
    {
        if (GameObject.Find("Game UI Music").GetComponent<Toggle>().isOn == true)
        {
            uiMusicEnabler = true;
        }
      else  if (GameObject.Find("Game UI Music").GetComponent<Toggle>().isOn == false)
        {
            uiMusicEnabler = false;
        }
    }
    void Update()
    {
        print(uiMusicEnabler);
    }
}
