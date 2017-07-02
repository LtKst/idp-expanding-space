using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class StarLightFlash : MonoBehaviour
{

    SpriteRenderer spr;

    [SerializeField]
    private float colorSpeed;
    [SerializeField]
    private float colorAmplitude;

    private float initialAlpha;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();

        initialAlpha = spr.color.a;
    }

    private void Update()
    {
        float a = initialAlpha + colorAmplitude * Mathf.Sin(colorSpeed * Time.time);

        spr.color = new Color(1, 1, 1, a);
    }
}
