using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameAnimation : MonoBehaviour {

    [SerializeField]
    Sprite[] frames;
    [SerializeField]
    float fps = 24;

    Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        int index = (int)((Time.time * fps) % frames.Length);

        image.sprite = frames[index];
        
    }
}
