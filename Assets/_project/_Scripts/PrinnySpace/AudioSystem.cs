using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : SingletonPersistent<AudioSystem>
{
    [System.Serializable]
    public class Sound
    {
        public string name;
        [HideInInspector] public AudioSource source;
        public AudioClip clip;
        public float volume;
    }

    public Sound[] sounds;
    protected override void Awake()
    {
        base.Awake();
        foreach(var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
