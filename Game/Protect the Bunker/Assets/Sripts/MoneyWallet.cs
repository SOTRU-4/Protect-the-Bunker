using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyWallet : MonoBehaviour
{
    public static int currentMoney;
    [SerializeField] TextMeshProUGUI moneyText;
    private void Start()
    {
        currentMoney = 0;
    }
    void Update()
    {
        moneyText.text = currentMoney.ToString();
    }
}
