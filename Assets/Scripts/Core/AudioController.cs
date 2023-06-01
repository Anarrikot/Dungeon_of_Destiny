using UnityEngine;

public class AudioController
{
    private static AudioController _instance;
    public static AudioController Instance 
        =>_instance ??= new AudioController();

    public AudioController()
    {
        _instance=this;
    }
}
