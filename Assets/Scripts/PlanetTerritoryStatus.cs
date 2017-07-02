using System;
using UnityEngine;
using UnityEngine.UI;

public class PlanetTerritoryStatus : MonoBehaviour
{

    [SerializeField]
    Image[] planetStatusRegions;

    float colorAlpha = 0.3f;

    int fightingFor = 0;

    bool allTerritoriesOwnedByOne = false;

    public void UpdatePlanetTerritory(PlayerManager winner)
    {
        if (planetStatusRegions[fightingFor].color.r == winner.PlayerColor.r)
        {
            fightingFor++;

            if (fightingFor >= planetStatusRegions.Length)
                fightingFor = 0;

            planetStatusRegions[fightingFor].color = new Color(winner.PlayerColor.r, winner.PlayerColor.g, winner.PlayerColor.b, colorAlpha);
        }
        else
        {
            planetStatusRegions[fightingFor].color = new Color(winner.PlayerColor.r, winner.PlayerColor.g, winner.PlayerColor.b, colorAlpha);
        }

        for (int i = 0; i < planetStatusRegions.Length; i++)
        {
            if (i == fightingFor)
            {
                planetStatusRegions[i].gameObject.GetComponent<ImageAlphaFlash>().Play();
            }
            else
            {
                planetStatusRegions[i].gameObject.GetComponent<ImageAlphaFlash>().Stop();
            }
        }

        int regionIndicator = 0;

        for (int i = 0; i < planetStatusRegions.Length; i++)
        {
            if (planetStatusRegions[i].color.r == winner.PlayerColor.r)
            {
                regionIndicator++;
            }
        }

        if (regionIndicator == planetStatusRegions.Length)
        {
            allTerritoriesOwnedByOne = true;
            
            winner.EndGame(winner.gameObject);

            UnityEngine.Object[] objs = FindObjectsOfType(typeof(GameObject));
            foreach (GameObject go in objs)
            {
                go.SendMessage("OnPlayerLost", SendMessageOptions.DontRequireReceiver);
            }

            winner.OtherPlayer.SetActive(false);
        }
    }

    public bool AllTerritoriesOwnedByOne
    {
        get
        {
            return allTerritoriesOwnedByOne;
        }
    }
}
