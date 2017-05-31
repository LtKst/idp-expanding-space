using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour {

    Slider slider;

    [SerializeField]
    Text volumeText;

    enum VolumeType { Master, Music, SFX }
    [SerializeField]
    VolumeType volumeType;

    SoundType[] audioManagers;

    float masterVolume = 1;
    float musicVolume = 1;
    float sfxVolume = 1;

    private void Start()
    {
        slider = GetComponent<Slider>();
        audioManagers = FindObjectsOfType(typeof(SoundType)) as SoundType[];

        switch (volumeType)
        {
            case VolumeType.Master:

                masterVolume = PlayerPrefs.GetFloat("masterVolume", 1);
                AudioListener.volume = masterVolume;
                slider.value = masterVolume;

                break;

            case VolumeType.Music:

                musicVolume = PlayerPrefs.GetFloat("musicVolume", 1);

                slider.value = musicVolume;

                for (int i = 0; i < audioManagers.Length; i++)
                {
                    if (audioManagers[i].soundType == SoundType.SoundTypeEnum.Music)
                        audioManagers[i].GetComponent<AudioSource>().volume = musicVolume;
                }

                break;

            case VolumeType.SFX:

                sfxVolume = PlayerPrefs.GetFloat("sfxVolume", 1);

                slider.value = sfxVolume;

                for (int i = 0; i < audioManagers.Length; i++)
                {
                    if (audioManagers[i].soundType == SoundType.SoundTypeEnum.SFX)
                        audioManagers[i].GetComponent<AudioSource>().volume = sfxVolume;
                }

                break;
        }
    }

    private void Update()
    {
        audioManagers = FindObjectsOfType(typeof(SoundType)) as SoundType[];

        if (!QuitManager.IsQuitting)
        {
            switch (volumeType)
            {
                case VolumeType.Master:

                    AudioListener.volume = slider.value;
                    volumeText.text = "Master Volume: " + slider.value.ToString("F2");

                    if (slider.value != PlayerPrefs.GetFloat("masterVolume"))
                        PlayerPrefs.SetFloat("masterVolume", slider.value);

                    break;

                case VolumeType.Music:

                    
                    for (int i = 0; i < audioManagers.Length; i++)
                    {
                        if (audioManagers[i].soundType == SoundType.SoundTypeEnum.Music)
                            audioManagers[i].GetComponent<AudioSource>().volume = slider.value;
                    }

                    volumeText.text = "Music Volume: " + slider.value.ToString("F2");

                    if (slider.value != PlayerPrefs.GetFloat("musicVolume"))
                        PlayerPrefs.SetFloat("musicVolume", slider.value);

                    break;

                case VolumeType.SFX:

                    for (int i = 0; i < audioManagers.Length; i++)
                    {
                        if (audioManagers[i].soundType == SoundType.SoundTypeEnum.SFX)
                            audioManagers[i].GetComponent<AudioSource>().volume = slider.value;
                    }

                    volumeText.text = "SFX Volume: " + slider.value.ToString("F2");

                    if (slider.value != PlayerPrefs.GetFloat("sfxVolume"))
                        PlayerPrefs.SetFloat("sfxVolume", slider.value);

                    break;
            }
        }
    }
}
