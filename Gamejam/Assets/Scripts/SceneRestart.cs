using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRestart : MonoBehaviour
{

   

    // Start is called before the first frame update
   public void RestartScene()
{
   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}

   public void GoToScene()
   {
      //SceneManager.LoadScene(SceneManager.);
   }
}
