using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DistributionHelper
{
    const int numPoints = 500;
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

    static public Vector3[] HollowSpherical(float innerRadius = 10f, float outerRadius = 100f)
    {
        points = new Vector3[DistributionHelper.numPoints];

        int n = 0;
        while (n < numPoints)
        {
            float x = Random.Range(-outerRadius, outerRadius);
            float y = Random.Range(-outerRadius, outerRadius);
            float z = Random.Range(-outerRadius, outerRadius);
            float d = Mathf.Sqrt(x * x + y * y + z * z);
            if (d <= outerRadius && d >= innerRadius)
            {
                points[n] = new Vector3(x, y, z);
                n++;
            }
        }
        return points;
    }

    static public Vector3[] Box(float width = 100f, float height = 100f, float depth = 100f)
    {
        points = new Vector3[DistributionHelper.numPoints];

        for (int i = 0; i < numPoints; i++)
        {
            float x = Random.Range(-width / 2, width / 2);
            float y = Random.Range(-height / 2, height / 2);
            float z = Random.Range(-depth / 2, depth / 2);
            points[i] = new Vector3(x, y, z);
        }
        return points;
    }

    static public Vector3[] Disk(float radius = 100f)
    {
        points = new Vector3[DistributionHelper.numPoints];
        int n = 0;
        while (n < numPoints)
        {
            float x = Random.Range(-radius, radius);
            float y = 0;
            float z = Random.Range(-radius, radius);
            float d = Mathf.Sqrt(x * x + y * y + z * z);
            if (d <= radius )
            {
                points[n] = new Vector3(x, y, z);
                n++;
            }
        }
        return points;
    }

    static public Vector3[] Cylindrical(float radius = 100f, float height = 60f)
    {
        points = new Vector3[DistributionHelper.numPoints];
        int n = 0;
        while (n < numPoints)
        {
            float x = Random.Range(-radius, radius);
            float y = 0;
            float z = Random.Range(-radius, radius);
            float d = Mathf.Sqrt(x * x + y * y + z * z);
            if (d <= radius)
            {
                y = Random.Range(0, height);
                points[n] = new Vector3(x, y, z);
                n++;
            }
        }
        return points;
    }

    static public Vector3[] Cone(float radius = 100f, float height = 60f)
    {
        points = new Vector3[DistributionHelper.numPoints];
        int n = 0;
        while (n < numPoints)
        {
            float x = Random.Range(-radius, radius);
            float y = Random.Range(0, height);
            float z = Random.Range(-radius, radius);
            float r = 1 - y / height;
            float d = Mathf.Sqrt(x * x + z * z);
            if (d <= r)
            {
                points[n] = new Vector3(x, y, z);
                n++;
            }
        }
        return points;
    }
    /*
    static public Vector3[] Name(float innerRadius = 10f, float outerRadius = 100f)
    {
        points = new Vector3[DistributionHelper.numPoints];
        return points;
    }
    */
}