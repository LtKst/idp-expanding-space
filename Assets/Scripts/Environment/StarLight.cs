using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class StarLight : MonoBehaviour
{

    SpriteRenderer spr;

    [SerializeField]
    private float colorSpeed;
    [SerializeField]
    private float colorAmplitude;

    private float initialA;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();

        initialA = spr.color.a;
    }

    private void Update()
    {
        float a = initialA + colorAmplitude * Mathf.Sin(colorSpeed * Time.time);

        spr.color = new Color(1, 1, 1, a);
    }
}
