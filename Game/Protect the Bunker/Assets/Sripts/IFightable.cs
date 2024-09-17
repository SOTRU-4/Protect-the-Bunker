using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFightable
{
    void Attack();

    void TakeDamage(int damage);
}
