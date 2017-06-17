using UnityEngine;

[RequireComponent(typeof(PanelUI))]
public class StatsPanel : MonoBehaviour
{

    PanelUI panel;

    private void Start()
    {
        panel = GetComponent<PanelUI>();
    }

    private void OnResumed()
    {
        panel.IsVisible = true;
    }

    private void OnPaused()
    {
        panel.IsVisible = false;
    }
}