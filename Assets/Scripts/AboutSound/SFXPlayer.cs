using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    public static SFXPlayer instance;
    public List<AudioSource> sfxPlayers;

    private float sfxVolume;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        SetVolume();
        DontDestroyOnLoad(gameObject);
    }

    public void SetVolume()
    {
        sfxVolume = PlayerPrefs.GetInt(SFXVolumeSetter.keyString, 30) * 0.01f;
        foreach(AudioSource sfxplayer in sfxPlayers)
        {
            sfxplayer.volume = sfxVolume;
        }
    }

    public AudioSource Play(AudioClip clip)
    {
        AudioSource nowPlayer = null;

        foreach (AudioSource sfxplayer in sfxPlayers)
        {
            if (!sfxplayer.isPlaying)
            {
                nowPlayer = sfxplayer;
                break;
            }
        }

        if (nowPlayer == null)
        {
            nowPlayer = AddNewPlayer();
        }

        nowPlayer.clip = clip;
        nowPlayer.Play();

        return nowPlayer;
    }

    public void StopAllSFX()
    {
        foreach(var sfxplayer in sfxPlayers)
        {
            sfxplayer.loop = false;
            sfxplayer.Stop();
        }
    }

    private AudioSource AddNewPlayer()
    {
        AudioSource newPlayer;
        newPlayer = gameObject.AddComponent<AudioSource>();
        newPlayer.playOnAwake = false;
        newPlayer.volume = sfxVolume;

        sfxPlayers.Add(newPlayer);
        return newPlayer;
    }

}
