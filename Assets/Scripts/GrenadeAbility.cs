using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GrenadeAbility : Ability
{
    public float delay = 3f;

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

        //Get nearby objects
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
