using UnityEngine;

[RequireComponent(typeof(Planet))]
public class PlanetManager : MonoBehaviour
{

    Planet[] planets;

    [SerializeField]
    int planetIndex;

    [SerializeField]
    SpriteRenderer backgroundSpriteRenderer;

    private void Start()
    {
        planets = GetComponents<Planet>();

        planetIndex = Mathf.Clamp(planetIndex, 0, planets.Length - 1);

        SetPlanet();
    }

    public void NextPlanet()
    {
        planetIndex--;

        if (planetIndex < 0)
        {
            planetIndex = planets.Length - 1;
        }

        SetPlanet();
    }

    public void PreviousPlanet()
    {
        planetIndex++;

        if (planetIndex > planets.Length)
        {
            planetIndex = 0;
        }

        SetPlanet();
    }

    private void SetPlanet()
    {
        backgroundSpriteRenderer.sprite = planets[planetIndex].background;

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
