using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GrenadeAbility : Ability
{
    public float delay = 3f;
    public float radius = 5f;
    public float force = 700f;

    public GameObject grenade;

    public GameObject explosionEffect;

    float countdown;
    bool hasExploded = false;

    void Start()
    {
        countdown = delay;
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        
    }

    void Explode()
    {
        Instantiate(explosionEffect, grenade.transform.position, grenade.transform.rotation );

        Collider[] colliders = Physics.OverlapSphere(grenade.transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, grenade.transform.position, radius);
            }
        }
        //Add force
        //Damage effect

        Destroy(grenade);
    }

    public override void Activate(GameObject parent)
    {
        if(countdown <= 0 && !hasExploded)
        {
            hasExploded = true;
            Explode();
        }
    }


}
