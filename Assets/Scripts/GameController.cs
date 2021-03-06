﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private System.Random rand = new System.Random();
    public Button[] worms;

    void Start()
    {
        //killAllWorms();
    }

    void Update()
    {
        if (rand.Next(300) == 0)
        {
            InvokeRepeating("createWorm", 0, 7);
        }
    }

    void createWorm()
    {
        worms[rand.Next(16)].GetComponent<WormScript>().createWorm();
    }

    private void killAllWorms()
    {
        for (int index = 0; index < worms.Length; index++)
        {
            worms[index].GetComponent<WormScript>().killWorm();
        }
    }

}
