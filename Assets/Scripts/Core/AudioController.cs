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

    public void PlaySound(AudioSource audioSource)
    {
        audioSource.Play();
    }

    public void StopSound(AudioSource audioSource)
    {
        audioSource.Stop();
    }
}
