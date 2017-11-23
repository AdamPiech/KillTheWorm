using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WormScript : MonoBehaviour {

    private GameController gameController;
    public Button wormButton;

    private Text totalPointsText;

    private GameObject spawnPoint;
    private GameObject worm;
    public GameObject exampleWorm;

    public Sprite aliveWorm;
    public Sprite deadWorm;
    public Sprite heap;

    public AudioClip AudioKill;
    public AudioClip AudioPop;
    public AudioClip AudioHide;

    private float createWormTime;
    private float destroyWormTime;

    private bool wormIsLive = false;

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        totalPointsText = GameObject.Find("TextPoints").GetComponent<Text>();
        wormButton.GetComponent<Image>().sprite = heap;
        wormButton.interactable = false;
    }

    void Update()
    {
        if(Time.time - createWormTime > 3 && wormButton.interactable)
        {
            escapeWorm();
        }
        if (Time.time - createWormTime <= 1 && this.worm != null)
        {
            upMovement();
        }
        if (Time.time - destroyWormTime <= 1 && this.worm != null && !wormIsLive)
        {
            downMovement();
        }
        if (Time.time - destroyWormTime > 1 && this.worm != null && !wormIsLive)
        {
            Destroy(this.worm);
            this.worm = null;
        }
    }

    public void createWorm()
    {
        initWorm();
        this.worm.GetComponent<Image>().sprite = aliveWorm;
        wormButton.interactable = true;
        getCreatedTime();
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        if (!audio.isPlaying)
        {
            audio.enabled = true;
            audio.clip = AudioPop;
            audio.Play();
        }
    }

    public void escapeWorm()
    {
        wormButton.interactable = false;
        gameController.GetComponent<PointCounter>().removePoints();
        getDestroyTime();
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        if (!audio.isPlaying)
        {
            audio.enabled = true;
            audio.clip = AudioHide;
            audio.Play();
        }
    }

    public void killWorm()
    {
        this.worm.GetComponent<Image>().sprite = deadWorm;
        wormButton.interactable = false;
        gameController.GetComponent<PointCounter>().addPoints();
        getDestroyTime();
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        if (!audio.isPlaying)
        {
            audio.enabled = true;
            audio.clip = AudioKill;
            audio.Play();
        }
    }

    private void initWorm()
    {
        if (this.worm == null)
        {
            this.worm = Instantiate(exampleWorm, spawnPoint.transform.position, spawnPoint.transform.rotation);
            this.worm.transform.parent = this.spawnPoint.transform.parent;
            this.worm.transform.localScale = Vector3.one;
            this.worm.transform.SetSiblingIndex(this.wormButton.transform.GetSiblingIndex() - 5);
        }
    }

    private void upMovement()
    {
        this.worm.transform.Translate(0, 1.35f * Time.deltaTime, 0);
    }

    private void downMovement()
    {
        this.worm.transform.Translate(0, -1.35f * Time.deltaTime, 0);
    }

    private void getCreatedTime()
    {
        createWormTime = Time.time;
        wormIsLive = true;
    }

    private void getDestroyTime()
    {
        destroyWormTime = Time.time;
        wormIsLive = false;
    }

    public void initSpawnPoint(GameObject spawn)
    {
        this.spawnPoint = spawn;
    }
}
