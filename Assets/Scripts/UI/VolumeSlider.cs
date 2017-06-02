using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour {

    Slider slider;

    [SerializeField]
    SoundType.SoundTypeEnum volumeType;

    private void Start()
    {
        slider = GetComponent<Slider>();

        switch (volumeType)
        {
            case SoundType.SoundTypeEnum.Master:
                slider.value = SoundManager.MasterVolume;
                break;

            case SoundType.SoundTypeEnum.Music:
                slider.value = SoundManager.MusicVolume;
                break;

            case SoundType.SoundTypeEnum.SFX:
                slider.value = SoundManager.SfxVolume;
                break;
        }
    }

    private void Update()
    {
        if (!QuitManager.IsQuitting)
        {
            SoundManager.SetVolume(volumeType, slider.value);
        }
    }
}
