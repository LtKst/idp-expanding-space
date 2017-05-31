using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    float masterVolume;
    float musicVolume;
    float sfxVolume;

    SoundType[] audioManagers;

    private void Awake()
    {
        LoadVolume();
        SetVolume();
    }

    public void SetVolume()
    {
        AudioListener.volume = masterVolume;

        audioManagers = FindObjectsOfType(typeof(SoundType)) as SoundType[];

        for (int i = 0; i < audioManagers.Length; i++)
        {
            if (audioManagers[i].soundType == SoundType.SoundTypeEnum.Music)
                audioManagers[i].GetComponent<AudioSource>().volume = musicVolume;
        }

        for (int i = 0; i < audioManagers.Length; i++)
        {
            if (audioManagers[i].soundType == SoundType.SoundTypeEnum.SFX)
                audioManagers[i].GetComponent<AudioSource>().volume = sfxVolume;
        }

        SaveVolume();
    }

    public void SetVolume(SoundType.SoundTypeEnum type, float volume)
    {
        audioManagers = FindObjectsOfType(typeof(SoundType)) as SoundType[];

        switch (type)
        {
            case SoundType.SoundTypeEnum.Master:

                masterVolume = volume;
                AudioListener.volume = masterVolume;

                break;

            case SoundType.SoundTypeEnum.Music:

                musicVolume = volume;

                for (int i = 0; i < audioManagers.Length; i++)
                {
                    if (audioManagers[i].soundType == SoundType.SoundTypeEnum.Music)
                        audioManagers[i].GetComponent<AudioSource>().volume = musicVolume;
                }

                break;

            case SoundType.SoundTypeEnum.SFX:

                sfxVolume = volume;

                for (int i = 0; i < audioManagers.Length; i++)
                {
                    if (audioManagers[i].soundType == type)
                        audioManagers[i].GetComponent<AudioSource>().volume = sfxVolume;
                }

                break;
        }

        SaveVolume();
    }

    private void SaveVolume()
    {
        PlayerPrefs.SetFloat("masterVolume", masterVolume);
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.SetFloat("sfxVolume", sfxVolume);
    }

    private void LoadVolume()
    {
        if (masterVolume != PlayerPrefs.GetFloat("masterVolume"))
            masterVolume = PlayerPrefs.GetFloat("masterVolume", 1);

        if (musicVolume != PlayerPrefs.GetFloat("musicVolume "))
            musicVolume = PlayerPrefs.GetFloat("musicVolume", 1);

        if (sfxVolume != PlayerPrefs.GetFloat("sfxVolume"))
            sfxVolume = PlayerPrefs.GetFloat("sfxVolume", 1);
    }

    public float MasterVolume
    {
        get
        {
            return masterVolume;
        }
        set
        {
            masterVolume = value;
        }
    }

    public float MusicVolume
    {
        get
        {
            return musicVolume;
        }
        set
        {
            musicVolume = value;
        }
    }

    public float SfxVolume
    {
        get
        {
            return sfxVolume;
        }
        set
        {
            sfxVolume = value;
        }
    }
}
