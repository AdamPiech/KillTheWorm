using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private System.Random rand = new System.Random();
    public Button[] worms;
    public GameObject[] wormSpawns;
    private bool IsRunning;

    void Start()
    {
        IsRunning = false;
        initAllWorms();
    }

    void Update()
    {
        if (!IsRunning)
        {
            return;
        }
        if (rand.Next(300) == 0)
        {
            InvokeRepeating("createWorm", 0, 7);
        }
    }

    void createWorm()
    {
        List<int> availableButtons = new List<int>();
        for (int i = 0; i < worms.Length; i++)
        {
            if (worms[i].GetComponent<WormScript>().IsHidden()) availableButtons.Add(i);
        }
        if (availableButtons.Count > 0)
        {
            availableButtons = availableButtons.OrderBy(a => rand.Next(1024)).ToList<int>();
            worms[availableButtons[0]].GetComponent<WormScript>().createWorm();
        }
    }

    private void initAllWorms()
    {
        for (int index = 0; index < worms.Length; index++)
        {
            worms[index].GetComponent<WormScript>().initSpawnPoint(wormSpawns[index]);
        }
    }

    private void desactiveAllWorms()
    {
        for (int i = 0; i < worms.Length; i++)
        {
            worms[i].GetComponent<WormScript>().DestroyWorm();
        }
    }

    public void initGame()
    {
        IsRunning = true;
    }

    public void gameOver()
    {
        IsRunning = false;
        CancelInvoke();
        desactiveAllWorms();
    }

}
