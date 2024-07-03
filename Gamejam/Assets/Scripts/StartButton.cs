using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
public void StartGame() {
    Loader.Load(Loader.Scene.GameScene);
   }

   public void GoToMenu() {
        SceneManager.LoadScene("MainMenu");
   }

   public void Exit() 
    {
        Application.Quit();
    }
}
