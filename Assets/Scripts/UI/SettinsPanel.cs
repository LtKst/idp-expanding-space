using UnityEngine;
using UnityEngine.UI;

public class SettinsPanel : MonoBehaviour {

    RectTransform rect;

    [SerializeField]
    float slideSpeed = 5;

    [SerializeField]
    Vector3 visiblePosition = new Vector3(-200, 0, 0);
    [SerializeField]
    Vector3 hiddenPosition = new Vector3(200, 0, 0);

    [SerializeField]
    Text showButtonText;
    [SerializeField]
    string visibleText = ">";
    [SerializeField]
    string hiddenText = "<";

    bool isVisible;

    private void Start()
    {
        rect = GetComponent<RectTransform>();

        if (isVisible)
        {
            rect.anchoredPosition = visiblePosition;

            showButtonText.text = visibleText;
        }
        else
        {
            rect.anchoredPosition = hiddenPosition;

            showButtonText.text = hiddenText;
        }
    }

    private void Update()
    {
        if (isVisible)
        {
            rect.anchoredPosition = Vector3.Lerp(rect.anchoredPosition, visiblePosition, Time.deltaTime * slideSpeed);

            showButtonText.text = visibleText;
        }
        else
        {
            rect.anchoredPosition = Vector3.Lerp(rect.anchoredPosition, hiddenPosition, Time.deltaTime * slideSpeed);

            showButtonText.text = hiddenText;
        }
    }

    public void ToggleVisible()
    {
        isVisible = !isVisible;
    }
}
