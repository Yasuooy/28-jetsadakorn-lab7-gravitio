using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetAttractor : MonoBehaviour
{
    public Rigidbody rb;

    private const float G = 6.67f;

    public static List<PlanetAttractor> pAttractors;
    void AttractorFormular(PlanetAttractor other)
    {
        Rigidbody rbOther = other.rb;

        Vector3 direction = rb.position - rbOther.position;

        float distance = direction.magnitude;

        //F = G* ( m1m2)/d^2 ;
        float forceMagnitude = G*(rb.mass * rbOther.mass) / Mathf.Pow(distance, 2);

        Vector3 forceDir = direction.normalized * forceMagnitude;

        rbOther.AddForce(forceDir);

    }//AttractorFormular
    void FixedUpdate()

    {

        foreach (var attractor in pAttractors)

        {

            if (attractor != this)

            {

                AttractorFormular(attractor);

            }

        }

    }//FixedUpdate

  
private void OnEnable()

    {

        if (pAttractors == null)

        {

            pAttractors = new List<PlanetAttractor>();

        }

        pAttractors.Add(this);

    }//OnEnable
}


