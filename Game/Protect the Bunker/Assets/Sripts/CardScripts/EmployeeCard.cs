using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeCard : CardBase
{
    private int moneyGenerating = 2;
    private int moneyGeneratingSpeed = 3;
    void Start()
    {
        StartCoroutine(MoneyPerSec());
    }

    IEnumerator MoneyPerSec()
    {
        while(true)
        {
            yield return new WaitForSeconds(moneyGeneratingSpeed);
            MoneyWallet.currentMoney += moneyGenerating;
        }
    }
}
