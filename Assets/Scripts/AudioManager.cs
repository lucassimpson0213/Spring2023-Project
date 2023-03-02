using UnityEngine.Audio;
using System;
using UnityEngine;  

public class AudioManager : MonoBehaviour
{
    public AudioManagerSound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (AudioManagerSound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        //Play BGM
        Play("BGM");
    }

    public void Play(string name)
    {
        AudioManagerSound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("AudioManagerSound: " + name + " not found");
            return;
        }
        s.source.Play();
    }
}
