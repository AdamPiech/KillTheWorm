using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour {

    public Text totalPointsText;
    private int count;
    public Button restartButton;

    void Start () {
        totalPointsText.text = "0";
        count = 0;
	}
	
	void Update () {
        setCountText();
	}

    public void addPoints()
    {
        count = count + 2;
    }

    public void removePoints()
    {
        if (count > 0)
        {
            count--;
        }
    }

    public void restartGame()
    {
        count = 0;
    }

    void setCountText()
    {
        totalPointsText.text = count.ToString();
    }
}
