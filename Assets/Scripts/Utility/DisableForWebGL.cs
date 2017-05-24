using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableForWebGL : MonoBehaviour {
    
	private void Start () {
        #if UNITY_WEBGL
            gameObject.SetActive(false);
        #endif
    }
}