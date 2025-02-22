using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public bool PauseIsActive ;

    void Start()
    {
        PauseIsActive = false;
    }
    
    void Update() 
    {
       if(Input.GetKeyDown(KeyCode.Escape)) 
       { 
            if(!PauseIsActive) 
            {
            Pause();
            Cursor.lockState = CursorLockMode.None;
        PauseIsActive = true;
            }
            else 
            {
            Resume();
            }
       } 
      
    }

    public void Pause() 
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume() 
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseIsActive = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Exit() 
    {
        Application.Quit();
    }
    public void TimeStop()
    {
        Time.timeScale = 0f;
    }
    public void TimeContinue()
    {
        Time.timeScale = 1f;
    }
}