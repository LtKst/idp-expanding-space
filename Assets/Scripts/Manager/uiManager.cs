using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiManager : MonoBehaviour {
    
    PanelUI[] panels;

    private void Start()
    {
        panels = FindObjectsOfType(typeof(PanelUI)) as PanelUI[];
    }

    public void HideAllPanels()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].IsVisible = false;
        }
    }
}
