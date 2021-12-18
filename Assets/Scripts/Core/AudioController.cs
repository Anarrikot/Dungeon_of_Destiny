using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private GameObject prefabNotification;
    public static AudioController instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this; // «адаем ссылку на экземпл€р объекта
        }
        else if (instance == this)
        {
            // Ёкземпл€р объекта уже существует на сцене
            Destroy(gameObject); // ”дал€ем объект
        }

        DontDestroyOnLoad(gameObject);

    }
}
