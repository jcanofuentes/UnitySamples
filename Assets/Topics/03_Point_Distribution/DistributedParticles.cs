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
        //Vector3[] points = DistributionHelper.Sphere(100);
        //Vector3[] points = DistributionHelper.HollowSpherical(60,100);
        //Vector3[] points = DistributionHelper.Box(100, 100,100);
        //Vector3[] points = DistributionHelper.Disk( 100);
        Vector3[] points = DistributionHelper.Cylindrical( 100, 60);
        //Vector3[] points = DistributionHelper.Cone( 1000, 10);

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
