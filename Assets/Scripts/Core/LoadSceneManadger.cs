using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManadger : MonoBehaviour
{
   public void LoadScene(int sceneID)
   {
        Main.Instance.TaskOnClick3();
        this.GetComponent<ComonWindow>().Close();
        Preloader.Instance.Load(sceneID);
        Time.timeScale = 1;
   }
    public void NextLevel()
    {
        Main.Instance.TaskOnClick3();
        this.GetComponent<ComonWindow>().Close();
        Preloader.Instance.Load(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1; 
    }
    public void ReloadScene()
    {
        Main.Instance.TaskOnClick3();
        this.GetComponent<ComonWindow>().Close();
        Preloader.Instance.Load(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
