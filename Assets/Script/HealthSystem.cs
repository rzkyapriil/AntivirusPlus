using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public TextMeshProUGUI txtHealthCount;
    public int defaultHealthCount;
    public int healthCount;

    public void Init()
    {
        healthCount = defaultHealthCount;
        txtHealthCount.text = healthCount.ToString();

    }    

    public void LoseHealth(int amount)
    {
        healthCount--;
        if (healthCount < 1)
        {
            Debug.Log("You Lost");
        }
        txtHealthCount.text = healthCount.ToString();
    } 
}
