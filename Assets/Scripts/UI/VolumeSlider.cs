using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour {

    [SerializeField]
    Text volumeText;

    private void Update()
    {
        AudioListener.volume = GetComponent<Slider>().value;
        volumeText.text = "Volume: " + AudioListener.volume.ToString("F2");
    }
}
