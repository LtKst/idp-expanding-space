using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject asteroid;
    GameObject instance;

    [SerializeField]
    Vector2 spawnDelayMinMax;

    float timer;

    [SerializeField]
    float spawnPointOffset = 50;

    [SerializeField]
    bool spawnWithX;

    private void Start()
    {
        timer = Random.Range(spawnDelayMinMax.x, spawnDelayMinMax.y);
    }

    private void Update()
    {
        if (GameState.InGame)
        {
            timer -= Time.deltaTime * 2;
        }

        if (timer <= 0 || (Input.GetKeyDown(KeyCode.X) && spawnWithX))
        {
            instance = Instantiate(asteroid);

            bool fromTop = Utility.Random.RandomBool();

            if (fromTop)
            {
                instance.transform.position = new Vector3(
                    Random.Range(ScreenToWorld.Left - spawnPointOffset, ScreenToWorld.Right + spawnPointOffset),
                    Random.Range(ScreenToWorld.Top - spawnPointOffset, ScreenToWorld.Bottom + spawnPointOffset)
                );
            }
            else
            {
                instance.transform.position = new Vector3(
                    Random.Range(ScreenToWorld.Left - spawnPointOffset, ScreenToWorld.Right + spawnPointOffset),
                    Random.Range(ScreenToWorld.Top + spawnPointOffset, ScreenToWorld.Bottom - spawnPointOffset)
                );
            }

            timer = Random.Range(spawnDelayMinMax.x, spawnDelayMinMax.y);
        }
    }
}
