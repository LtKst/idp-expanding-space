using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour {

    Slider slider;
    SoundManager soundManager;

    [SerializeField]
    SoundType.SoundTypeEnum volumeType;

    private void Start()
    {
        slider = GetComponent<Slider>();
        soundManager = GameObject.FindWithTag("Manager").GetComponent<SoundManager>();

        switch (volumeType)
        {
            case SoundType.SoundTypeEnum.Master:
                slider.value = soundManager.MasterVolume;
                break;

            case SoundType.SoundTypeEnum.Music:
                slider.value = soundManager.MusicVolume;
                break;

            case SoundType.SoundTypeEnum.SFX:
                slider.value = soundManager.SfxVolume;
                break;
        }
    }

    private void Update()
    {
        if (!QuitManager.IsQuitting)
        {
            soundManager.SetVolume(volumeType, slider.value);
        }
    }
}
