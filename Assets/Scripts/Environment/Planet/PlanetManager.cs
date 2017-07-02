using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Planet))]
public class PlanetManager : MonoBehaviour
{

    Planet[] planets;

    [SerializeField]
    int planetIndex;

    [SerializeField]
    bool randomPlanetIndex;

    [SerializeField]
    SpriteRenderer backgroundSpriteRenderer;

    [SerializeField]
    Image[] planetPreviews;

    private void Start()
    {
        planets = GetComponents<Planet>();

        if (randomPlanetIndex)
        {
            planetIndex = Random.Range(0, planets.Length);
        }

        planetIndex = Mathf.Clamp(planetIndex, 0, planets.Length - 1);

        SetPlanet();
    }

    public void PreviousPlanet()
    {
        planetIndex--;

        if (planetIndex < 0)
        {
            planetIndex = planets.Length - 1;
        }

        SetPlanet();
    }

    public void NextPlanet()
    {
        planetIndex++;

        if (planetIndex > planets.Length - 1)
        {
            planetIndex = 0;
        }

        SetPlanet();
    }

    private void SetPlanet()
    {
        backgroundSpriteRenderer.sprite = planets[planetIndex].background;

        for (int i = 0; i < planetPreviews.Length; i++)
        {
            planetPreviews[i].sprite = planets[planetIndex].planet.GetComponent<SpriteRenderer>().sprite;
        }

        for (int i = 0; i < planets.Length; i++)
        {
            if (i != planetIndex)
            {
                planets[i].planet.SetActive(false);
            }
            else
            {
                planets[i].planet.SetActive(true);
            }
        }
    }
}
