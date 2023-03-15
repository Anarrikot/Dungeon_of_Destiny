using UnityEngine;

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
