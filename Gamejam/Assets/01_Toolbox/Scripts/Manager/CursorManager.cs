using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public PauseMenu script; 
    
    void Start()
    {}
    private void OnApplicationFocus(bool focus)
    {
       if(focus && !GetComponent<PauseMenu>().PauseIsActive)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
