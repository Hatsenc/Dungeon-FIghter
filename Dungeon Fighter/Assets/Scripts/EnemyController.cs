using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public AudioClip HitSound;
    AudioSource ac;

    private int currentHealth;
    public int maxHealth = 100;

    void Start()
    {
        currentHealth = maxHealth;
        ac = GetComponent<AudioSource>();
        if (ac == null)
        {
            ac = gameObject.AddComponent<AudioSource>();
        }

    }

    public void SetHealth(int damage)
    {
        if (damage > 0)
        {
            if (HitSound != null && ac != null)
            {
                ac.PlayOneShot(HitSound);
            }
        }
        
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0)
            Die();

    }

    void ChangeHealth(int value)
    {
        SetHealth(maxHealth + value);
    }

    public virtual void Die()
    {
        Destroy(transform.gameObject);
    }
}

