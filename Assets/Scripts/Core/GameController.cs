using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameObject prefabNotification;
    public static GameController instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this; // Задаем ссылку на экземпляр объекта
        }
        else if (instance == this)
        {
            // Экземпляр объекта уже существует на сцене
            Destroy(gameObject); // Удаляем объект
        }

        DontDestroyOnLoad(gameObject);

    }
}
