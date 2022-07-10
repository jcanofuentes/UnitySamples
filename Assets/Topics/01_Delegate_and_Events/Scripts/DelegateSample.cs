using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Topics.Delegates_And_Events
{
    public class DelegateSample : MonoBehaviour
    {
        // Delegate ref
        delegate float DelegateCalculateDistance(Vector3 v);

        void Start()
        {
            Debug.Log(this.GetType());

            // We can store different a method inside the reference
            DelegateCalculateDistance myDelegate = SquaredEuclideanDistance;
            Debug.Log("Return from SquaredEuclideanDistance: " + myDelegate.Invoke(Vector3.up * 5));

            // Or a different one...
            myDelegate = EuclideanDistance;
            Debug.Log("Return from EuclideanDistance: " + myDelegate.Invoke(Vector3.up * 5));
        }

        void Update()
        {

        }

        float SquaredEuclideanDistance(Vector3 v)
        {
            return v.x * v.x + v.y * v.y + v.z * v.z;
        }

        float EuclideanDistance(Vector3 v)
        {
            return Mathf.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);
        }

    }
}
