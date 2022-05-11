using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAddon : MonoBehaviour
{
   

    [Header("Stats")]
    public int damage;
    public bool destroyOnHit;

    [Header("Explosive Projectile")]
    public bool isExplosive;
    public float explosionRadius;
    public float explosionForce;
    public int explosionDamage;
    public GameObject explosionEffect;

    private Rigidbody rb;

    private bool hitTarget;
    public GameObject player;

    private void Start()
    {
        // get rigidbody component
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != player)
        {
            // enemy hit
            if (collision.gameObject.GetComponent<Enemy>() != null)
            {
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();

                // deal damage to the enemy
                enemy.TakeDamage(damage);


                // destroy projectile
                if (!isExplosive && destroyOnHit)
                    Invoke(nameof(DestroyProjectile), 0.1f);
            }

            // explode projectile if it's explosive
            if (isExplosive)
            {
                Explode();
                return;
            }

            // make sure projectile sticks to surface
            rb.isKinematic = true;

            // make sure projectile moves with target
            transform.SetParent(collision.transform);
        }
    }

    private void Explode()
    {
        // spawn explosion effect (if assigned)
        if (explosionEffect != null)
            Instantiate(explosionEffect, transform.position, Quaternion.identity);

        // find all the objects that are inside the explosion range
        Collider[] objectsInRange = Physics.OverlapSphere(transform.position, explosionRadius);

        // loop through all of the found objects and apply damage and explosion force
        for (int i = 0; i < objectsInRange.Length; i++)
        {
            if (objectsInRange[i].gameObject == gameObject)
            {
                // don't break or return please, thanks
            }
            else
            {
                // check if object is enemy, if so deal explosionDamage
                if (objectsInRange[i].GetComponent<Enemy>() != null)
                    objectsInRange[i].GetComponent<Enemy>().TakeDamage(explosionDamage);

                // check if object has a rigidbody
                if (objectsInRange[i].GetComponent<Rigidbody>() != null)
                {
                    // custom explosionForce
                    Vector3 objectPos = objectsInRange[i].transform.position;

                    // calculate force direction
                    Vector3 forceDirection = (objectPos - transform.position).normalized;

                    // apply force to object in range
                    objectsInRange[i].GetComponent<Rigidbody>().AddForceAtPosition(forceDirection * explosionForce + Vector3.up * explosionForce, transform.position + new Vector3(0, -0.5f, 0), ForceMode.Impulse);

                    //Debug.Log("Kabooom " + objectsInRange[i].name);
                }
            }
        }

        // destroy projectile with 0.1 seconds delay
        Invoke(nameof(DestroyProjectile), 0.1f);
    }

    private void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }

    // just graphics stuff
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
