using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Guard : BattleCardBase, IFightable
{
    private bool isAttacked;
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
