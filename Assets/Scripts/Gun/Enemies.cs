using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float health;
    public GameObject deathScreen;

    private void Start()
    {
        deathScreen.SetActive(false);
    }

    void Update()
    {
        if (health <= 0)
        {
            //Death and respawn
            deathScreen.SetActive(true);
            Debug.Log("Player death");

            Respawn();
        }
    }

    // Hits the target for a certain amount of damage
    public void Hit(float damage)
    {
        health -= damage;
    }

    void Respawn()
    {

    }
}