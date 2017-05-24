using UnityEngine;
using UnityEngine.UI;

public class uiPanel : MonoBehaviour {

    RectTransform rect;

    [SerializeField]
    float slideSpeed = 5;

    [SerializeField]
    Vector3 visiblePosition = new Vector3(-200, 0, 0);
    [SerializeField]
    Vector3 hiddenPosition = new Vector3(200, 0, 0);

    [SerializeField]
    bool visible;

    private void Start()
    {
        rect = GetComponent<RectTransform>();

        if (visible)
        {
            rect.anchoredPosition = visiblePosition;
        }
        else
        {
            rect.anchoredPosition = hiddenPosition;
        }
    }

    private void Update()
    {
        if (visible)
        {
            rect.anchoredPosition = Vector3.Lerp(rect.anchoredPosition, visiblePosition, Time.deltaTime * slideSpeed);
        }
        else
        {
            rect.anchoredPosition = Vector3.Lerp(rect.anchoredPosition, hiddenPosition, Time.deltaTime * slideSpeed);
        }
    }

    public void ToggleVisible()
    {
        visible = !visible;
    }

    public bool IsVisible
    {
        get
        {
            return visible;
        }
        set
        {
            visible = value;
        }
    }
}
