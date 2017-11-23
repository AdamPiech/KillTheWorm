using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KinectCursor : MonoBehaviour
{
    public Sprite ClubSprite;
    public GameObject EventSystem;

    private Vector3 LeftHandPosition;
    private Vector3 RightHandPosition;
    private bool LeftHandEnabled;
    private bool RightHandEnabled;
    private bool LeftHandPressed;
    private bool RightHandPressed;

    // Use this for initialization
    void Start()
    {
        LeftHandPosition = Vector3.zero;
        RightHandPosition = Vector3.zero;
        LeftHandEnabled = false;
        RightHandEnabled = false;
        LeftHandPressed = false;
        RightHandPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem == null)
        {
            LeftHandEnabled = false;
            RightHandEnabled = false;
            return;
        }
        LeftHandPosition = Vector3.zero;
        RightHandPosition = Vector3.zero;
        StandaloneInputModule sim = EventSystem.GetComponent<StandaloneInputModule>();
        if (sim != null && sim.enabled)
        {
            LeftHandEnabled = false;
            RightHandPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RightHandPressed = Input.GetMouseButton(0);
            RightHandEnabled = true;
        }
        KinectInputModule kim = EventSystem.GetComponent<KinectInputModule>();
        if (kim != null && kim.enabled)
        {
            KinectInputData kid = kim.GetHandData(KinectUIHandType.Left);
            LeftHandPosition = kid.HandPosition;
            LeftHandPressed = kid.IsPressing;
            LeftHandEnabled = true;
            kid = kim.GetHandData(KinectUIHandType.Right);
            RightHandPosition = kid.HandPosition;
            RightHandPressed = kid.IsPressing;
            RightHandEnabled = true;
        }
        LeftHandPosition.z = 190;
        RightHandPosition.z = 190;
    }

    public Vector3 GetCursorPosition(KinectUIHandType hand)
    {
        if (hand == KinectUIHandType.Left)
        {
            return LeftHandPosition;
        }
        else if (hand == KinectUIHandType.Right)
        {
            return RightHandPosition;
        }
        else
        {
            throw new System.Exception("Invalid hand!");
        }
    }
    public bool IsCursorPressed(KinectUIHandType hand)
    {
        if (hand == KinectUIHandType.Left)
        {
            return LeftHandPressed;
        }
        else if (hand == KinectUIHandType.Right)
        {
            return RightHandPressed;
        }
        else
        {
            throw new System.Exception("Invalid hand!");
        }
    }
    public bool IsCursorEnabled(KinectUIHandType hand)
    {
        if (hand == KinectUIHandType.Left)
        {
            return LeftHandEnabled;
        }
        else if (hand == KinectUIHandType.Right)
        {
            return RightHandEnabled;
        }
        else
        {
            throw new System.Exception("Invalid hand!");
        }
    }
}