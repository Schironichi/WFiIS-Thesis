using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Charger : MonoBehaviour
{
    Vector3 oldPosition;
    float distance;
    public bool isCharging = true;
    public TextMeshPro chargeValue;

    private void OnTriggerEnter(Collider other)
    {
        oldPosition = other.transform.position;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("GoodCollider"))
        {
            distance = (other.transform.position - oldPosition).magnitude;
            if (isCharging)
                other.GetComponentInChildren<ChargeDetector>().AddToCharge(3.0f * distance);
            else
                other.GetComponentInChildren<ChargeDetector>().AddToCharge(-3.0f * distance);
            chargeValue.text = other.GetComponentInChildren<ChargeDetector>().charge.ToString(".00") + " e";
            oldPosition = other.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        chargeValue.text = "";
    }
}
