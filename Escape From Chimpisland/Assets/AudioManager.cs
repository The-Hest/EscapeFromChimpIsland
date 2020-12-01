using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance; // Singleton for only having one instance of this object

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            DontDestroyOnLoad(gameObject);

        foreach(var sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    public void Start()
    {
        //Play("");
    }

    // Update is called once per frame
    public void Play(string name)
    {
        var s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) 
            return;
        
        s.source.Play();
    }
}
