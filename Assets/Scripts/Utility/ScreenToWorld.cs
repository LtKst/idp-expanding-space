using UnityEngine;

public class ScreenToWorld : MonoBehaviour
{

	public static float Left
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(Vector3.zero).x;
        }
    }

    public static float Right
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0)).x;
        }
    }

    public static float Top
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height)).y;
        }
    }

    public static float Bottom
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(new Vector3(0, 0)).y;
        }
    }
}