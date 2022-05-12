using UnityEngine;

public class Round : MonoBehaviour
{
    public float damage;

    void OnCollisionEnter(Collision other)
    {
        Enemies target = other.gameObject.GetComponent<Enemies>();
        // Only attempts to inflict damage if the other game object has the 'Enemies' component
       
        if (target != null)
        {
            target.Hit(damage);
            Debug.Log("Hit Player");
        }

        Destroy(gameObject);
        Debug.Log("Object hit");
    }
}