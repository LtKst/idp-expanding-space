using UnityEngine;
using UnityEngine.UI;

public class PanelUI : MonoBehaviour
{
    RectTransform rect;

    [SerializeField]
    float slideSpeed = 5;

    [SerializeField]
    Vector3 visiblePosition = new Vector3(-200, 0, 0);
    [SerializeField]
    Vector3 hiddenPosition = new Vector3(200, 0, 0);

    [SerializeField]
    bool visible;

    bool changeGameObject;

    GameObject changeOldGameObject;
    GameObject changeNewGameObject;

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
            rect.anchoredPosition = Vector3.Lerp(rect.anchoredPosition, visiblePosition, Time.unscaledDeltaTime * slideSpeed);
        }
        else
        {
            rect.anchoredPosition = Vector3.Lerp(rect.anchoredPosition, hiddenPosition, Time.unscaledDeltaTime * slideSpeed);
        }

        if (changeGameObject && Vector3.Distance(rect.anchoredPosition, hiddenPosition) <= 0.2f)
        {
            changeOldGameObject.SetActive(false);
            changeNewGameObject.SetActive(true);
        }
    }

    public void ToggleVisible()
    {
        visible = !visible;
    }

    public void ChangeAfterDisappear(GameObject oldGameObject, GameObject newGameObject)
    {
        changeOldGameObject = oldGameObject;
        changeNewGameObject = newGameObject;

        changeGameObject = true;
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
