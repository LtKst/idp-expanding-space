using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class PowerUp : MonoBehaviour {

    [SerializeField]
    float colorTransitionSpeed = 100;

    SpriteRenderer spriteRenderer;
    Collider2D col;
    
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();

        spriteRenderer.color = new Color(255, 255, 255, 0);
        col.enabled = false;
	}
	
	void Update () {
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, new Color(255, 255, 255, 1), colorTransitionSpeed * Time.deltaTime);

        if (spriteRenderer.color.a >= 0.93)
        {
            col.enabled = true;
        }
	}
}
