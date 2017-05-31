using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    float masterVolume;
    float musicVolume;
    float sfxVolume;

    SoundType[] audioManagers;

    private void Start()
    {
        masterVolume = PlayerPrefs.GetFloat("masterVolume", 1);
        musicVolume = PlayerPrefs.GetFloat("musicVolume", 1);
        sfxVolume = PlayerPrefs.GetFloat("sfxVolume", 1);

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
    }

    public void SetVolume(SoundType.SoundTypeEnum type, float volume)
    {
        audioManagers = FindObjectsOfType(typeof(SoundType)) as SoundType[];

        switch (type)
        {
            case SoundType.SoundTypeEnum.Master:

                masterVolume = volume;
                AudioListener.volume = masterVolume;

                PlayerPrefs.SetFloat("masterVolume", masterVolume);

                break;

            case SoundType.SoundTypeEnum.Music:

                musicVolume = volume;

                for (int i = 0; i < audioManagers.Length; i++)
                {
                    if (audioManagers[i].soundType == SoundType.SoundTypeEnum.Music)
                        audioManagers[i].GetComponent<AudioSource>().volume = musicVolume;
                }

                PlayerPrefs.SetFloat("musicVolume", musicVolume);

                break;

            case SoundType.SoundTypeEnum.SFX:

                sfxVolume = volume;

                for (int i = 0; i < audioManagers.Length; i++)
                {
                    if (audioManagers[i].soundType == type)
                        audioManagers[i].GetComponent<AudioSource>().volume = sfxVolume;
                }

                PlayerPrefs.SetFloat("sfxVolume", sfxVolume);

                break;
        }
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
