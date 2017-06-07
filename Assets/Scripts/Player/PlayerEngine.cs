using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEngine : MonoBehaviour {

    [SerializeField]
    AudioClip engineClip;
    AudioSource audioSource;

    float lerpSpeed = 1;

    private void Start()
    {
        audioSource = Instantiate(new GameObject("Engine")).AddComponent<AudioSource>();

        audioSource.volume = 0;
        audioSource.clip = engineClip;
        audioSource.loop = true;

        audioSource.Play();
    }

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
