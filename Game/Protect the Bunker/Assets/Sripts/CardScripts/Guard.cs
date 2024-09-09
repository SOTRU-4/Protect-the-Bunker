using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Guard : CardBase
{
    [SerializeField] TextMeshPro healthText;
    [SerializeField] TextMeshPro armorText;
    [SerializeField] TextMeshPro attackText;

    private int healthPoints = 10;
    private int armorPoints = 4;
    private int attackDamage = 2;

    void Update()
    {
        healthText.text = healthPoints.ToString();
        armorText.text = armorPoints.ToString();
        attackText.text = attackDamage.ToString();
    }


}
