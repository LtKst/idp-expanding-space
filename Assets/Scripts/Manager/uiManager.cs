using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiManager : MonoBehaviour {
    
    uiPanel[] panels;

    private void Start()
    {
        panels = FindObjectsOfType(typeof(uiPanel)) as uiPanel[];
    }

    public void HideAllPanels()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].IsVisible = false;
        }
    }
}
