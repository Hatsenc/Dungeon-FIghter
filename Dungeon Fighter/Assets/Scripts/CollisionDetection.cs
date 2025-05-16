using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public WeaponController wc;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && wc.IsAttacking)
        {
            Debug.Log("Hit: " + other.name);
            other.GetComponent<Animator>().SetTrigger("Hit");
            wc.DealDamage(other.gameObject);

        }

    }
}
