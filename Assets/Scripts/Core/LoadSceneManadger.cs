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
    public void NextLevel()
    {
        Main.instance.TaskOnClick3();
        this.GetComponent<ComonWindow>().Close();
        Preloader.instance.Load(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1; 
    }
    public void ReloadScene()
    {
        Main.instance.TaskOnClick3();
        this.GetComponent<ComonWindow>().Close();
        Preloader.instance.Load(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
