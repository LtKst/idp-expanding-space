using UnityEngine;

public class DisableInGame : MonoBehaviour
{

    void OnStartInGame()
    {
        gameObject.SetActive(false);
    }
}
