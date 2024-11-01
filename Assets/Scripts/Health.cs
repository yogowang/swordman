using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int health;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private HealthBar healthBar;
    // Update is called once per frame
    void Start(){
        health=maxHealth;
        healthBar.updateHealth((float)health/maxHealth);
    }
    void Update()
    {
       healthBar.updateHealth((float)health/maxHealth);
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
