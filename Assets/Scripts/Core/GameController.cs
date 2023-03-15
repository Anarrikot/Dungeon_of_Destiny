using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this; 
        }
        else if (instance == this)
        {
            Destroy(gameObject); 
        }

        DontDestroyOnLoad(gameObject);

    }
}
