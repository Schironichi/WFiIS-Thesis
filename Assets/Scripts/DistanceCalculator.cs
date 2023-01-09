using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{
    public float distance;
    public Transform object1, object2;
    void FixedUpdate()
    {
        distance = Vector3.Distance(object1.transform.position, object2.transform.position);
    }
}
