using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreScript : MonoBehaviour
{
    [SerializeField] GameObject StoreMenu;
    [SerializeField] GameObject PauseMenu;
    private bool _menuIsActive;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!PauseMenu.activeSelf)
        {

        if(Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Tab)) 
        { 
             if(!_menuIsActive) 
             {
            Pause();
             Cursor.lockState = CursorLockMode.None;
          _menuIsActive = true;
              }
             else 
             {
             Resume();
             }
         } 
       }
    }

     public void Pause() 
    {
        StoreMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume() 
    {
        StoreMenu.SetActive(false);
        Time.timeScale = 1f;
        _menuIsActive = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
}
