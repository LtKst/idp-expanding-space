using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField]
    GameObject missile;
    GameObject missileInstance;

    [SerializeField]
    Transform shootPoint;

    public void Shoot()
    {
        missileInstance = Instantiate(missile);
        missileInstance.transform.SetPositionAndRotation(shootPoint.position, transform.rotation);
        missileInstance.GetComponent<Missile>().belongsTo = gameObject;
    }
}
