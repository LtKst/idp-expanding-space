using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyParticleSystem : MonoBehaviour {

    ParticleSystem ps;

    private void Start()
    {
        if (GetComponent<ParticleSystem>())
            ps = GetComponent<ParticleSystem>();
        else
            Destroy(GetComponent<AutoDestroyParticleSystem>());
    }

    private void Update()
    {
        if (!ps.IsAlive())
            Destroy(gameObject);
    }
}
