using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    [SerializeField]
    GameObject asteroid;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q))
        {
            for (int i = 0; i < 4; i++)
            {
                GameObject miniAsteroid = Instantiate(asteroid);
                miniAsteroid.transform.localScale = transform.localScale / 2;
            }

            Destroy(gameObject);
        }
	}
}
