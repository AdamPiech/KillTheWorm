using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormLiveCycle : MonoBehaviour {

    GameObject worm = null;
    private Vector3 initialPosition;

    //void Start()
    //{
    //    initialPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    //    velocity = Random.Range(0.01f, 2f);
    //}

    //void Update()
    //{
    //    if (enableMovement) transform.Translate(-initialPosition.x * Time.deltaTime * velocity, -initialPosition.y * Time.deltaTime * velocity, 0);
    //}

    public void createWorm(GameObject worm)
    {
        this.worm = worm;
        Vector3 initialPosition = new Vector3(worm.transform.position.x, worm.transform.position.y, worm.transform.position.z);
        transform.Translate(worm.transform.position.x, worm.transform.position.y + 100, worm.transform.position.z);
    }
}
