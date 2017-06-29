using UnityEngine;
using UnityEngine.UI;

public class DisableButtonForWebGL : MonoBehaviour {
    
	private void Start () {
        #if UNITY_WEBGL
            GetComponent<Button>().interactable = false;
        #endif
    }
}