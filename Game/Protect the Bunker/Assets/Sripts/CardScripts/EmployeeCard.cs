using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeCard : CardBase
{
    private int moneyGenerating = 2;
    void Start()
    {
        StartCoroutine(MoneyPerSec());
    }

    IEnumerator MoneyPerSec()
    {
        while(true)
        {
            yield return new WaitForSeconds(3);
            MoneyWallet.currentMoney += moneyGenerating;
        }
    }
}
