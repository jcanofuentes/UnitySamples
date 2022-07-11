using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistributedParticles
    : MonoBehaviour
{
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        //Vector3[] points = DistributionHelper.Cube(100);
        Vector3[] points = DistributionHelper.Sphere(100);

        foreach (Vector3 v in points)
        {
            Debug.Log(v);
            Instantiate(obj, v, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
