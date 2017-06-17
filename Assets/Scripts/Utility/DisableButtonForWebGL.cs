using UnityEngine;

public class DisableButtonForWebGL : MonoBehaviour {
    
	private void Start () {
        #if UNITY_WEBGL
            GetComponent<Button>().interactable = false;
        #endif
    }
}