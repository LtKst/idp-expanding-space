using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField]
    GameObject missile;
    GameObject missileInstance;

<<<<<<< HEAD
    [SerializeField]
    Transform shootPoint;

    public void Shoot()
    {
        missileInstance = Instantiate(missile);
        missileInstance.transform.SetPositionAndRotation(shootPoint.position, transform.rotation);
        missileInstance.GetComponent<Missile>().belongsTo = gameObject;
=======
    public void Shoot()
    {
        missileInstance = Instantiate(missile);
        missileInstance.transform.SetPositionAndRotation(transform.position, transform.rotation);
        missileInstance.GetComponent<Missile>().player = gameObject;
>>>>>>> ec792f55fda1041e98791741b9328b1782982ceb
    }
}
