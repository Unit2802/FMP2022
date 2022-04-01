using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
   public float delay = 3f;
   

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
        if(countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        
        }
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

            //Get nearby objects
            //Add force
            //Damage

        Destroy(gameObject);
    }
}
