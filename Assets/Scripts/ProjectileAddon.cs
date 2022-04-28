using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAddon : MonoBehaviour
{
    public int damage;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
      // check if you hit an enemy
      if(collision.gameObject.GetComponent<Enemy>() != null)
      {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            enemy.TakeDamage(damage); 

            Destroy(gameObject);
      }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
