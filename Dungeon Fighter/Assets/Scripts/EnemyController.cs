using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public AudioClip HitSound;

    private int currentHealth;
    public int maxHealth = 100;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void SetHealth(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0) Die();

    }

    void ChangeHealth(int value)
    {
        SetHealth(maxHealth + value);
    }

    public virtual void Die()
    {
        Destroy(transform.gameObject);
        transform.gameObject.SetActive(false);
    }
}

