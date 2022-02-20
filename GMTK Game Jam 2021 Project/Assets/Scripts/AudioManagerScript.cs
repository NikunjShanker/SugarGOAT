using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManagerScript : MonoBehaviour
{
    public SoundScript[] sounds;

    public static AudioManagerScript instance;
    public bool mute = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(SoundScript s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }

    public void PlaySound(string name)
    {
        SoundScript s = Array.Find(sounds, sound => sound.name == name);
        if(!s.source.isPlaying)
        {
            s.source.Play();
        }
    }

    public void StopSound(string name)
    {
        SoundScript s = Array.Find(sounds, sound => sound.name == name);
        if (s.source.isPlaying)
        {
            s.source.Stop();
        }
    }

    public bool isSoundPlaying(string name)
    {
        SoundScript s = Array.Find(sounds, sound => sound.name == name);
        return s.source.isPlaying;
    }

    void Update()
    {
        if (mute)
        {
            AudioListener.volume = 0f;
        }
        else
        {
            AudioListener.volume = 1f;
        }

        if (SceneManager.GetActiveScene().name == "Main Menu Scene" || SceneManager.GetActiveScene().name == "Level Select Scene")
            PlaySound("lobbymusic");
        else
            StopSound("lobbymusic");

        if (SceneManager.GetActiveScene().name == "Level 10" && SceneManager.GetActiveScene().name != "Level Select Scene" && !isSoundPlaying("levelcomplete"))
            PlaySound("lastlevelmusic");
        else
            StopSound("lastlevelmusic");

        if (SceneManager.GetActiveScene().name != "Level 10" && SceneManager.GetActiveScene().name != "Main Menu Scene" && SceneManager.GetActiveScene().name != "Level Select Scene" && !isSoundPlaying("levelcomplete"))
            PlaySound("levelmusic");
        else
            StopSound("levelmusic");
    }
}
