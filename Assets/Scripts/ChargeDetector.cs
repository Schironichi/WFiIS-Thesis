using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeDetector : MonoBehaviour
{
    public ParticleSystem electrons;
    public float charge = 0.0f;

    public void UpdateEmission()
    {
        var emission = electrons.emission;
        emission.rateOverTime =
            (10.5f - (charge + 5.0f)) * 10;
    }

    void Start()
    {
        AddToCharge(charge);
    }
    public void AddToCharge(float value)
    {
        if (Mathf.Abs(charge + value) > 5)
        {
            if (charge + value > 0)
            {
                charge = 5.0f;
            }
            else
            {
                charge = -5.0f;
            }
        }
        else
        {
            charge += value;
        }

        UpdateEmission();
    }
    
}
