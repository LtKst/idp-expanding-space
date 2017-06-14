using UnityEngine;

public class FrameAnimation : MonoBehaviour {

    SpriteRenderer spr;
    
    public Sprite[] frames;

    public float frameRate = 24;
    
    public bool playAutomatically;
    public bool loop;

    bool isPlaying;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();

        isPlaying = playAutomatically;
    }

    private void Update()
    {
        if (isPlaying)
        {
            int index = (int)((Time.unscaledTime * frameRate) % frames.Length);

            spr.sprite = frames[index];

            if (!loop && index == frames.Length)
            {
                isPlaying = false;
            }
        }
    }

    public void Play()
    {
        isPlaying = true;
    }

    public void Stop()
    {
        isPlaying = false;
    }

    public bool IsPlaying
    {
        get
        {
            return isPlaying;
        }
    }
}
