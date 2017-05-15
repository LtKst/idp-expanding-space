using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    [SerializeField]
    Sprite[] randomWallpaper;

	void Start () {
        var sr = GetComponent<SpriteRenderer>();

        if (sr == null)
        {
            return;
        }

        sr.sprite = randomWallpaper[Random.Range(0, randomWallpaper.Length)];

        transform.position = Vector3.zero;
        transform.localScale = new Vector3(1, 1, 1);

        var width = sr.sprite.bounds.size.x;
        var height = sr.sprite.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector3(worldScreenWidth / width, worldScreenHeight / height, 0);
    }
}
