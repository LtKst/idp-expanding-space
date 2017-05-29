using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectResize : MonoBehaviour {

    Vector2 initialSize;
    
	public void Start () {
        initialSize = new Vector2(Screen.width, Screen.height);
	}
	
	public void Update () {
		if (Screen.width != initialSize.x || Screen.height != initialSize.y)
        {
            initialSize = new Vector2(Screen.width, Screen.height);

            Object[] objects = FindObjectsOfType(typeof(GameObject));
            foreach (GameObject go in objects)
            {
                go.SendMessage("OnScreenResize", SendMessageOptions.DontRequireReceiver);
            }
        }
	}
}