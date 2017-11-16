using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WormScript : MonoBehaviour {

    private GameController gameController;
    public Button wormButton;
    public Sprite worm;
    public Sprite deadWorm;
    public Sprite heap;

    private float createWormTime;

    void Start()
    {
        wormButton.GetComponent<Image>().sprite = heap;
        wormButton.interactable = false;
    }

    void Update()
    {
        if(Time.time - createWormTime > 3)
        {
            escapeWorm();
        }
    }

    public void createWorm()
    {
        wormButton.GetComponent<Image>().sprite = worm;
        wormButton.interactable = true;
        getCreatedTime();
    }

    public void escapeWorm()
    {
        wormButton.GetComponent<Image>().sprite = heap;
        wormButton.interactable = false;
    }

    public void killWorm()
    {
        wormButton.GetComponent<Image>().sprite = deadWorm;
        wormButton.interactable = false;
    }

    private void getCreatedTime()
    {
        createWormTime = Time.time;
    }

}
