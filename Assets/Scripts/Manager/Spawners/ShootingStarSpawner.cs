using System.Collections;
using UnityEngine;

public class ShootingStarSpawner : MonoBehaviour
{

    [SerializeField]
    GameObject shootingStar;

    [SerializeField]
    private Vector2 spawnDurationMinMax = new Vector2(10, 20);

    private bool isWaitingForSpawn;

    private void Start()
    {
        StartCoroutine(WaitForSpawn());
    }

    IEnumerator WaitForSpawn()
    {
        yield return new WaitForSeconds(Random.Range(spawnDurationMinMax.x, spawnDurationMinMax.y));

        GameObject shootingStarInstance = Instantiate(shootingStar);

        shootingStarInstance.transform.position = new Vector3(
                Random.Range(ScreenToWorld.Left, ScreenToWorld.Right),
                Random.Range(ScreenToWorld.Top, ScreenToWorld.Bottom)
        );

        shootingStarInstance.transform.Rotate(new Vector3(0, 0, Random.Range(0, 359)));

        StartCoroutine(WaitForSpawn());
    }
}
