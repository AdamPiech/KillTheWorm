using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WormScript : MonoBehaviour {

    private GameController gameController;
    public Button wormButton;
    public Sprite worm;

    private float createWormTime;

    void Update()
    {
        if(Time.time - createWormTime > 3)
        {
            killWorm();
        }
    }

    public void createWorm()
    {
        wormButton.GetComponent<Image>().sprite = worm;
        wormButton.interactable = true;
        getCreatedTime();
    }

    public void killWorm()
    {
        wormButton.GetComponent<Image>().sprite = null;
        wormButton.interactable = false;
    }

    private void getCreatedTime()
    {
        createWormTime = Time.time;
    }

}
