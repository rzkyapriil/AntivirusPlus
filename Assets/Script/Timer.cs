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

    [Header("Panel")]
    public GameObject winPanel;
    public GameObject losePanel;

    public Enemy enemy;

    void Start()
    {
        //winPanel.SetActive(false);
        //losePanel.SetActive(false);
    }

    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        
        if(hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            settimertext();
            enabled = false;

            //win Panel
            showWinPanel();
        }

        settimertext();
    }

    public void showWinPanel()
    {
        winPanel.SetActive(true);
    }

    public void showLosePanel()
    {
        losePanel.SetActive(true);
    }

    private void settimertext()
    {
        timerText.text = currentTime.ToString("00.00");
    }

    public void AddTime(float value)
    {
        currentTime += value;
    }
}
