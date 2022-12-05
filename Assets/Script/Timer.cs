using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header("Timer Settings")]
    public bool hasLimit;
    public float timerLimit;

    void Start()
    {
        
    }

    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        
        if(hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            settimertext();
            enabled = false;
        }

        settimertext();
    }

    private void settimertext()
    {
        timerText.text = currentTime.ToString("00.00");
    }
}
