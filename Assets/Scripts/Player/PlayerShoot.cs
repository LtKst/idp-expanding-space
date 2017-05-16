using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    [SerializeField]
    GameObject missile;
    GameObject missileInstance;

	public void Shoot () {
        missileInstance = Instantiate(missile);
        missileInstance.transform.SetPositionAndRotation(transform.position, transform.rotation);
	}
}
