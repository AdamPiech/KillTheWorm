using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

    public Text timerText;
    private double startTime;
    private double timer;
    bool start;
    public Button restartButton;

	// Use this for initialization
	void Start () {
        restartTimer();
        start = true;
	}
	
	// Update is called once per frame
	void Update () {
        getTime();
	}

    void getTime()
    {
        if (start)
        {
            timer = Math.Round(40 - (Time.time - startTime), 1);
            if (timer <= 0)
            {
                timerText.text = "0";
                start = false;
                restartButton.gameObject.SetActive(true);
            }
            else if((timer - (int) timer) == 0)
            {
                timerText.text = timer.ToString() + ".0";
            }
            else
                timerText.text = timer.ToString();
        }
    }

    public void restartTimer()
    {
        timerText.text = "40";
        startTime = Time.time;
        restartButton.gameObject.SetActive(false);
        start = true;
    }

}
