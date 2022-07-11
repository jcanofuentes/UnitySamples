using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DistributionHelper
{
    const int numPoints = 300;
    public static Vector3[] points;

    static public Vector3[] Cube(float side = 100f)
    {
        points = new Vector3[DistributionHelper.numPoints];
        for (int i = 0; i < numPoints; i++)
        {
            float x = Random.Range(-side / 2, side / 2);
            float y = Random.Range(-side / 2, side / 2);
            float z = Random.Range(-side / 2, side / 2);
            points[i] = new Vector3(x, y, z);
        }
        return points;
    }

    static public Vector3[] Sphere(float radius = 100f)
    {
        points = new Vector3[DistributionHelper.numPoints];
        int n = 0;
        while (n < numPoints)
        {
            float x = Random.Range(-radius, radius);
            float y = Random.Range(-radius, radius);
            float z = Random.Range(-radius, radius);
            float d = Mathf.Sqrt(x * x + y * y + z * z);

            if (d <= radius)
            {
                points[n] = new Vector3(x, y, z);
                n++;

            }
        }
        return points;
    }
}