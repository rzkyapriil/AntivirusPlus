using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret1 : Turret
{
    public int incomeValue;
    public float incomeInterval;
    public GameObject currecyIcon;

    protected override void Start()
    {
        StartCoroutine(Interval());
    }

    public override bool LoseHealth(int amount)
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
            turretContainer.isFull = false;
            return true;
        }
        else
        {
            animator.Play("EntrositeHurtIdle");
        }
        return false;
    }

    IEnumerator Interval()
    {
        yield return new WaitForSeconds(incomeInterval);
        IncreaseIncome();

    }   
    
    public void IncreaseIncome()
    {
        GameManager.instance.currencySystem.Gain(incomeValue);
        StartCoroutine(CoinIndication());
    }    

    IEnumerator CoinIndication()
    {
        currecyIcon.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        currecyIcon.SetActive(false);
        StartCoroutine(Interval());
    }
    
}
