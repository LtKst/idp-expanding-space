using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEngine : MonoBehaviour {

    [SerializeField]
    AudioSource audioSource;

    float lerpSpeed = 1;

    public void UpdateEngineSound(bool getMoveKeyDown)
    {
        if (getMoveKeyDown)
        {
            audioSource.volume = Mathf.Lerp(audioSource.volume, SoundManager.SfxVolume, Time.deltaTime * lerpSpeed);
        }
        else
        {
            audioSource.volume = Mathf.Lerp(audioSource.volume, 0, Time.deltaTime * lerpSpeed);
        }
    }
}
