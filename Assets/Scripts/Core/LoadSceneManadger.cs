using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManadger : MonoBehaviour
{
   public void LoadScene(int sceneID)
   {
        Main.instance.TaskOnClick3();
        
        this.GetComponent<ComonWindow>().Close();
        Preloader.instance.Load(sceneID);
        Time.timeScale = 1;
   }
    
}
