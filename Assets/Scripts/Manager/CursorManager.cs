using UnityEngine;

public class CursorManager : MonoBehaviour
{

    [SerializeField]
    Texture2D cursorTextrue;

    private void Start()
    {
        Cursor.SetCursor(cursorTextrue, new Vector2(0, 0), CursorMode.ForceSoftware);
    }

    private void Update()
    {
        Cursor.visible = (!GameState.InGame || PauseManager.IsPaused || GameState.InEndGame);
    }
}
