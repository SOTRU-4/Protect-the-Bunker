using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MonsterCardBase : MonoBehaviour
{
    public int health;
    public int armor;
    public int damage;

    [SerializeField] TextMeshPro healthText;
    [SerializeField] TextMeshPro armorText;
    [SerializeField] TextMeshPro attackText;

    private void Update()
    {
        healthText.text = health.ToString();
        armorText.text = armor.ToString();
        attackText.text = damage.ToString();
    }
}
