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
            instance = this; // ������ ������ �� ��������� �������
        }
        else if (instance == this)
        {
            // ��������� ������� ��� ���������� �� �����
            Destroy(gameObject); // ������� ������
        }

        DontDestroyOnLoad(gameObject);

    }
}
