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

    private void Start()
    {
        slider = GetComponent<Slider>();
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

                    break;

                case VolumeType.Music:

                    
                    for (int i = 0; i < audioManagers.Length; i++)
                    {
                        if (audioManagers[i].soundType == SoundType.SoundTypeEnum.Music)
                            audioManagers[i].GetComponent<AudioSource>().volume = slider.value;
                    }

                    volumeText.text = "Music Volume: " + slider.value.ToString("F2");

                    break;

                case VolumeType.SFX:

                    for (int i = 0; i < audioManagers.Length; i++)
                    {
                        if (audioManagers[i].soundType == SoundType.SoundTypeEnum.SFX)
                            audioManagers[i].GetComponent<AudioSource>().volume = slider.value;
                    }

                    volumeText.text = "SFX Volume: " + slider.value.ToString("F2");

                    break;
            }
        }
    }
}
