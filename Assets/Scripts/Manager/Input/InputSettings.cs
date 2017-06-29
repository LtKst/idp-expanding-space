using System;
using System.Collections;
using UnityEngine;

public class InputSettings : MonoBehaviour
{

    string keyDown;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StopWaitingForKey();
        }
    }

    public void WaitForKey()
    {
        StartCoroutine(WaitForKeyPress());
    }

    public void StopWaitingForKey()
    {
        StopCoroutine(WaitForKeyPress());
    }

    private IEnumerator WaitForKeyPress()
    {
        while (!Input.anyKeyDown)
        {
            Debug.Log("waiting");

            yield return null;
        }

        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(kcode))
            {
                keyDown = "Key: " + kcode;
            }
        }

        Debug.Log(keyDown);
    }
}
