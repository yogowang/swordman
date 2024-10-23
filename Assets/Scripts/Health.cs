using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private int maxHealth = 100;

    // Update is called once per frame
    void Update()
    {
        // For testing purposes, we can damage or heal using key presses
        if (Input.GetKeyDown(KeyCode.D))
        {
           // Damage(10);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            //Heal(10);
        }
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException(nameof(amount), "Cannot have negative Damage");
        }

        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException(nameof(amount), "Cannot have negative healing");
        }

        health = Mathf.Min(health + amount, maxHealth);
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " is Dead!");
        Destroy(gameObject);
    }
}
