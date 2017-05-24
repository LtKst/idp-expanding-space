using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppHelper : MonoBehaviour {

	public static void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBGL
            Application.OpenURL("http://google.com");
        #else
            Application.Quit();
        #endif
    }
}