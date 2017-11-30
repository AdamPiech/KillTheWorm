using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

    public Text timerText;
    private double startTime;
    private double timer;
    public bool gameIsRunning;
    public Button restartButton;
    
	void Start () {

	}
	
	void Update () {
        if (gameIsRunning)
        {
            getTime();
        }
	}

    void getTime()
    {
         timer = Math.Round(40 - (Time.time - startTime), 1);
        if (timer <= 0)
        {
            timerText.text = "0";
            gameIsRunning = false;
            gameObject.GetComponent<GameController>().gameOver();
            Invoke("SetActive", 1);
        }
        else if ((timer - (int)timer) == 0)
        {
            timerText.text = timer.ToString() + ".0";
        }
        else
        {
            timerText.text = timer.ToString();
        }
    }

    public void restartTimer()
    {
        startTime = Time.time;
        timerText.text = "40";
        gameIsRunning = true;
        restartButton.gameObject.SetActive(!gameIsRunning);
    }

    public void SetActive()
    {
        restartButton.gameObject.SetActive(!gameIsRunning);
    }

}
