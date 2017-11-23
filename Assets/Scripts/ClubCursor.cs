using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubCursor : MonoBehaviour {

    public KinectCursor KinectCursor;
    public KinectUIHandType Hand;
    private GameObject Club;
    private SpriteRenderer ClubRenderer;
    private int RotationDegree;

	// Use this for initialization
	void Start () {
        Club = transform.Find("ClubSprite").gameObject;

        ClubRenderer = Club.GetComponent<SpriteRenderer>();

        Club.SetActive(false);

        ClubRenderer.flipX = Hand == KinectUIHandType.Left ? true : false;
        RotationDegree = Hand == KinectUIHandType.Left ? 45 : -45;
    }
	
	// Update is called once per frame
	void Update () {
		if (KinectCursor == null)
        {
            return;
        }
        
        Vector3 ClubPosition = KinectCursor.GetCursorPosition(Hand);
        bool IsEnabled = KinectCursor.IsCursorEnabled(Hand);
        transform.position = ClubPosition;
        Club.SetActive(IsEnabled);
        //ClubRenderer.enabled = IsEnabled;
        if (KinectCursor.IsCursorPressed(Hand))
        {
            Club.transform.localPosition = new Vector3(0, ClubRenderer.bounds.size.y / -4, 0);
            Club.transform.rotation = Quaternion.Euler(0, 0, RotationDegree);
        }
        else
        {
            Club.transform.localPosition = Vector3.zero;
            Club.transform.rotation = Quaternion.Euler(Vector3.zero);
        }
    }
}
