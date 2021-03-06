using UnityEngine;

public class Boid : MonoBehaviour
{
    [Header("Set Dinamically")]
    public Rigidbody rigid;

    public Vector3 pos
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();

        pos = Random.insideUnitSphere * Spawner.S.spawnRadius;

        Vector3 vel = Random.onUnitSphere * Spawner.S.velocity;
        rigid.velocity = vel;

        
        Color randColor = Color.black;
        while (randColor.r + randColor.g + randColor.b < 1.0f)
        {
            randColor = new Color(Random.value, Random.value, Random.value);
        }

        Renderer[] rends = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rends )
        {
            r.material.color = randColor;
        }
        TrailRenderer tRend = GetComponent<TrailRenderer>();
        tRend.material.SetColor("_TintColor", randColor);
        
    }

    void FixedUpdate()
    {
        Vector3 vel = rigid.velocity;
        Spawner spn = Spawner.S;

        // Attraction: move towards the atractor
        Vector3 delta = Attractor.POS - pos;

        // attrated or avoiding?
        bool attracted = (delta.magnitude > spn.attractPushDist);
        Vector3 velAttract = delta.normalized * spn.velocity;

        // Apply all the velocitires
        float fdt = Time.fixedDeltaTime;
        
        if( attracted )
        {
            vel = Vector3.Lerp(vel, velAttract, spn.attractPushDist * fdt);
        }
        else
        {
            vel = Vector3.Lerp(vel, -velAttract, spn.attractPushDist * fdt);

        }

        vel = vel.normalized * spn.velocity;

        rigid.velocity = vel;
        LookAhead();
    }


    void LookAhead()
    {
        transform.LookAt(pos + rigid.velocity);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
