using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KinectCursor : MonoBehaviour
{
    public Sprite ClubSprite;
    public GameObject EventSystem;
    private GameObject leftHand;
    private GameObject rightHand;

    // Use this for initialization
    void Start ()
    {
        GameObject leftHand = new GameObject("Left Hand Cursor");

        //Attach a SpriteRenender to the newly created gameobject
        SpriteRenderer rend = leftHand.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;

        //Assign the sprite to the SpriteRenender
        rend.sprite = ClubSprite;

        leftHand.transform.position = Vector2.zero;

        leftHand.transform.localScale = new Vector3(1f, 1f, 1f);

        leftHand.SetActive(true);

        rend.flipX = true;

        this.leftHand = leftHand;

        GameObject rightHand = new GameObject("Right Hand Cursor");

        //Attach a SpriteRenender to the newly created gameobject
        SpriteRenderer rend2 = rightHand.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;

        //Assign the sprite to the SpriteRenender
        rend2.sprite = ClubSprite;

        rightHand.transform.position = Vector2.zero;

        rightHand.transform.localScale = new Vector3(1f, 1f, 1f);

        rightHand.SetActive(true);

        this.rightHand = rightHand;
    }
	
	// Update is called once per frame
	void Update () {
        if (EventSystem == null)
        {
            return;
        }
        Vector3 LeftHandPosition = Vector3.zero;
        Vector3 RightHandPosition = Vector3.zero;
        StandaloneInputModule sim = EventSystem.GetComponent<StandaloneInputModule>();
        if (sim != null && sim.enabled)
        {
            LeftHandPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rightHand.SetActive(false);
        }
        KinectInputModule kim = EventSystem.GetComponent<KinectInputModule>();
        if (kim != null && kim.enabled)
        {
            KinectInputData kid = kim.GetHandData(KinectUIHandType.Left);
            LeftHandPosition = kid.HandPosition;
            rightHand.SetActive(true);
            kid = kim.GetHandData(KinectUIHandType.Right);
            RightHandPosition = kid.HandPosition;
        }
        LeftHandPosition.z = 190;
        RightHandPosition.z = 190;
        leftHand.transform.position = LeftHandPosition;
        rightHand.transform.position = RightHandPosition;
        //leftHand.transform.position.z = 1;
    }
}
