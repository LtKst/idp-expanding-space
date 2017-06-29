using UnityEngine;

public class SoundManager : MonoBehaviour {

    static string masterVolumePrefName = "masterVolume";
    static float masterVolume = 1;

    static string musicVolumePrefName = "musicVolume";
    static float musicVolume = 1;

    static string sfxVolumePrefName = "sfxVolume";
    static float sfxVolume = 1;

    private void Awake()
    {
        LoadVolume();
        SetVolume();
    }

    public void SetVolume()
    {
        AudioListener.volume = masterVolume;

        SoundType[] audioManagers = FindObjectsOfType(typeof(SoundType)) as SoundType[];

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

    public static void SetVolume(SoundType.SoundTypeEnum type, float volume)
    {
        SoundType[] audioManagers = FindObjectsOfType(typeof(SoundType)) as SoundType[];

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

    private static void SaveVolume()
    {
        PlayerPrefs.SetFloat(masterVolumePrefName, masterVolume);

        PlayerPrefs.SetFloat(musicVolumePrefName, musicVolume);

        PlayerPrefs.SetFloat(sfxVolumePrefName, sfxVolume);
    }

    private static void LoadVolume()
    {
        if (masterVolume != PlayerPrefs.GetFloat(masterVolumePrefName))
            masterVolume = PlayerPrefs.GetFloat(masterVolumePrefName, 1);

        if (musicVolume != PlayerPrefs.GetFloat(musicVolumePrefName))
            musicVolume = PlayerPrefs.GetFloat(musicVolumePrefName, 1);

        if (sfxVolume != PlayerPrefs.GetFloat(sfxVolumePrefName))
            sfxVolume = PlayerPrefs.GetFloat(sfxVolumePrefName, 1);
    }

    public static float MasterVolume
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

    public static float MusicVolume
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

    public static float SfxVolume
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
