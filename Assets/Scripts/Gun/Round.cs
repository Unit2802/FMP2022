using UnityEngine;

public class Round : MonoBehaviour
{
    public int damage = 50;

    void OnCollisionEnter(Collision other)
    {
        HealthAndRespawn target = other.gameObject.GetComponent<HealthAndRespawn>();
        // Only attempts to inflict damage if the other game object has the 'Enemies' component
       
        if (target != null)
        {
            target.TakeDamage(damage);
            Debug.Log("Hit Player");
        }

        Destroy(gameObject);
        Debug.Log("Object hit");
    }
}