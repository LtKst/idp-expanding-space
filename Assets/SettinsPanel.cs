using UnityEngine;

public class SettinsPanel : MonoBehaviour {

    RectTransform rect;

    [SerializeField]
    float slideSpeed = 5;

    [SerializeField]
    Vector3 visiblePosition = new Vector3(-200, 0, 0);
    [SerializeField]
    Vector3 hiddenPosition = new Vector3(200, 0, 0);

    bool isVisible;

    private void Start()
    {
        rect = GetComponent<RectTransform>();

        if (isVisible)
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
        if (isVisible)
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
        isVisible = !isVisible;
    }
}
