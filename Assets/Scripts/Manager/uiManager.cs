using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiManager : MonoBehaviour {
    
    public static void HideAllPanels()
    {
        PanelUI[] panels = FindObjectsOfType(typeof(PanelUI)) as PanelUI[];

        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].IsVisible = false;
        }
    }

    public void HideAllPanelsWrapper()
    {
        HideAllPanels();
    }
}
