using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestParticle : MonoBehaviour
{
    public ParticleSystem ps;
    void Start()
    {
        Debug.Log("���� �� burstCount: " + ps.emission.burstCount);

        ParticleSystem.EmissionModule em = ps.emission;
        em.burstCount = 5;

        Debug.Log("���� �� burstCount: " + ps.emission.burstCount);


    }

}
