using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour {

    public Text totalPointsText;
    private int count;
    public Button restartButton;

    // Use this for initialization
    void Start () {
        restartButton.gameObject.SetActive(false);
        totalPointsText.text = "0";
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {
        setCountText();
	}

    public void addPoints()
    {
        Debug.Log("Punkty :D");
        count = count + 2;
    }

    public void removePoints()
    {
        Debug.Log("Martwy...");
        if(count > 0)
            count--;
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
