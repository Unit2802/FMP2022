using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
   
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        //Add death and respawning script instead of destroy
        Destroy(gameObject);
    }

}
