using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject Sword;
    public bool CanAttack = true;
    public float AttackCooldown = 0.75f;
    public AudioClip SwordAttackSound;
    public bool IsAttacking = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CanAttack)
            {
                SwordAttack();
            }
        }
    }

    public void SwordAttack()
    {
        IsAttacking = true;
        CanAttack = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordAttackSound);

        StartCoroutine(ResetAttackCooldown());
    }

    public int damageAmount = 25;
    public void DealDamage(GameObject enemy)
    {
        EnemyController ec = enemy.GetComponent<EnemyController>();
        if (ec != null)
        {
            ec.SetHealth(damageAmount);
        }
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(AttackCooldown);
        IsAttacking = false;
        CanAttack = true;
    }
}
