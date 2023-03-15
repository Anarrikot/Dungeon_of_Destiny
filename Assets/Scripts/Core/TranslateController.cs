using UnityEngine;
public class TranslateController : MonoBehaviour
{
    public static TranslateController instance = null;
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
