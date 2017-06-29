using UnityEngine;

public class PlayerSkin : MonoBehaviour
{

    [SerializeField]
    Sprite[] playerSkins;
    [SerializeField]
    int skinIndex;

    SpriteRenderer spr;
    PolygonCollider2D col;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        col = GetComponent<PolygonCollider2D>();
    }

    public void NextSkin()
    {
        if (skinIndex >= playerSkins.Length - 1)
        {
            skinIndex = 0;
        }
        else
        {
            skinIndex++;
        }

        ChangeSkin();
    }

    public void PreviousSkin()
    {
        if (skinIndex <= 0)
        {
            skinIndex = playerSkins.Length - 1;
        }
        else
        {
            skinIndex--;
        }

        ChangeSkin();
    }

    void ChangeSkin()
    {
        spr.sprite = playerSkins[skinIndex];

        Destroy(col);
        col = gameObject.AddComponent<PolygonCollider2D>();
    }
}
