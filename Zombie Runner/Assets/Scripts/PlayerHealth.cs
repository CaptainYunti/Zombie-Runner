using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] float health = 100f;

    DeathHandler deathHandler;

    private void Start()
    {
        deathHandler = FindObjectOfType<DeathHandler>();
    }
    public void TakeDamage(float damage)
    {
        Debug.Log("Sounds of chocking on a dick");
        health -= damage;
        Debug.Log("Punkty: " + health); Debug.Log("Punkty: " + health);

        if (health <= 0)
        {
            Debug.Log("You're dead, pussy");
            deathHandler.HandleDeath();
        }
    }
}
