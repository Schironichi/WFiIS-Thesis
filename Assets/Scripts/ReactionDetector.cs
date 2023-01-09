using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionDetector : MonoBehaviour
{
    public List<GameObject> gameObjects;
    public Collider reactiveObject;
    public float strengthModifier = 0.002f;
    public float directionModifier = 10f;
    private float value, distance, totalCharge;
    private Vector3 heading, relativePosition;

    private void AddForces(Collider other)
    {
        heading = transform.position - other.transform.position;
        relativePosition = transform.InverseTransformDirection(heading);
        distance = relativePosition.magnitude;
        value = 1f / heading.sqrMagnitude * strengthModifier;
        if (other == reactiveObject)
        {
            if (distance < 0.08)
            {
                totalCharge = reactiveObject.GetComponentInChildren<ChargeDetector>().charge + gameObject.GetComponent<ChargeDetector>().charge;
                reactiveObject.GetComponentInChildren<ChargeDetector>().charge = totalCharge / 2;
                gameObject.GetComponent<ChargeDetector>().charge = totalCharge / 2;
                reactiveObject.GetComponentInChildren<ChargeDetector>().UpdateEmission();
                gameObject.GetComponent<ChargeDetector>().UpdateEmission();
            }
            foreach (var gameObject in gameObjects)
            {
                if (gameObject.GetComponent<ChargeDetector>())

                gameObject.GetComponent<ParticleSystemForceField>().directionX = -gameObject.GetComponent<ChargeDetector>().charge * directionModifier * value * relativePosition.x / distance;
                gameObject.GetComponent<ParticleSystemForceField>().directionY = -gameObject.GetComponent<ChargeDetector>().charge * directionModifier * value * relativePosition.y / distance;
                gameObject.GetComponent<ParticleSystemForceField>().directionZ = -gameObject.GetComponent<ChargeDetector>().charge * directionModifier * value * relativePosition.z / distance;

                gameObject.GetComponentInParent<Rigidbody>().AddForce(
                    -gameObject.GetComponent<ChargeDetector>().charge * strengthModifier * relativePosition.x / distance,
                    -gameObject.GetComponent<ChargeDetector>().charge * strengthModifier * relativePosition.y / distance,
                    -gameObject.GetComponent<ChargeDetector>().charge * strengthModifier * relativePosition.z / distance
                    );
            }

        }
    }

    private void RemoveForces(Collider other)
    {
        if (other == reactiveObject)
        {
            foreach (var gameObject in gameObjects)
            {
                gameObject.GetComponent<ParticleSystemForceField>().directionX = 0f;
                gameObject.GetComponent<ParticleSystemForceField>().directionY = 0f;
                gameObject.GetComponent<ParticleSystemForceField>().directionZ = 0f;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other == reactiveObject)
        {
            foreach (var gameObject in gameObjects)
            {
                if (this.GetComponent<ChargeDetector>().charge == 0 && gameObject.GetComponent<ChargeDetector>().charge == 0)
                {
                    RemoveForces(other);
                }
                else
                {
                    AddForces(other);
                }
            }         
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == reactiveObject)
        {
            foreach (var gameObject in gameObjects)
            {
                gameObject.GetComponent<ParticleSystemForceField>().directionX = 0f;
                gameObject.GetComponent<ParticleSystemForceField>().directionY = 0f;
                gameObject.GetComponent<ParticleSystemForceField>().directionZ = 0f;
            }
        }
    }
}