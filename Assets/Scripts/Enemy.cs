using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;

    public static bool teamOneEnemy = false;
    public static bool teamTwoEnemy = false;

    
    void awake()
    {
        teamTwoEnemy = true;
    }
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
