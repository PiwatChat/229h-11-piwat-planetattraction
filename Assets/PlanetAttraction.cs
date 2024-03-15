using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlanetAttraction : MonoBehaviour
{
    public Rigidbody rb;

    private const float G = 6.6f;
    public static List<PlanetAttraction> planetAttraction;

    void AttractorFormular( PlanetAttraction other )
    {
        Rigidbody rbOther = other.rb;

        Vector3 direction = rb.position - rbOther.position;

        float distance = direction.magnitude;


        float forceMagnitude = G * (rb.mass * rbOther.mass) / MathF.Pow(distance, 2);

        Vector3 forceDir = direction.normalized * forceMagnitude;
        
        rbOther.AddForce(forceDir);

    }
    void FixedUpdate()
    {
        foreach (var attraction in planetAttraction )
        {
            if (attraction != this)
            {
                AttractorFormular(attraction);
            }
        }
    }

    private void OnEnable()
    {
        if (planetAttraction == null)
        {
            planetAttraction = new List<PlanetAttraction>();
        }
        
        planetAttraction.Add(this);
    }
}