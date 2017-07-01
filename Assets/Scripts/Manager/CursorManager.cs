using UnityEngine;

public class CursorManager : MonoBehaviour
{

    [SerializeField]
    Texture2D cursorTextrue;
    [SerializeField]
    Vector2 hotspot = Vector2.zero;

    private void Start()
    {
        Cursor.SetCursor(cursorTextrue, hotspot, CursorMode.ForceSoftware);
    }

    private void Update()
    {
        Cursor.visible = (!GameState.InGame || PauseManager.IsPaused || GameState.InEndGame);
    }
}
