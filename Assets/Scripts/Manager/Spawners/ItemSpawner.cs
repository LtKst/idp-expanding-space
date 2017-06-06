using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] items;
    GameObject instance;

    [SerializeField]
    Vector2 spawnDelayMinMax;

    float timer;

    [SerializeField]
    float spawnPointOffset = 2.5f;

    [SerializeField]
    bool spawnWithX;

    private void Start()
    {
        timer = Random.Range(spawnDelayMinMax.x, spawnDelayMinMax.y);
    }

    private void Update()
    {
        if (GameStateManager.InGame)
        {
            timer -= Time.deltaTime * 2;
        }

        if (timer <= 0 || (Input.GetKeyDown(KeyCode.X) && spawnWithX))
        {
            instance = Instantiate(items[Random.Range(0, items.Length)]);

            instance.transform.position = new Vector3(
                Random.Range(ScreenToWorld.Left + spawnPointOffset, ScreenToWorld.Right - spawnPointOffset),
                Random.Range(ScreenToWorld.Top - spawnPointOffset, ScreenToWorld.Bottom + spawnPointOffset)
            );

            timer = Random.Range(spawnDelayMinMax.x, spawnDelayMinMax.y);
        }
    }
}
