using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonsterCardBase, IFightable
{
    public void Attack()
    {

    }

    public void TakeDamage(int damage)
    {
        Mathf.Abs(damage = damage - armor);

        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
