using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;

public class KinectBodyManager : MonoBehaviour
{
    private KinectSensor _Sensor;
    private BodyFrameReader _Reader;
    private Body[] _Data = null;
    private KinectInputModule _InputModule = null;
    private List<ulong> _TrackingIds = new List<ulong>();
    public GameObject EventSystem;

    public Body[] GetData()
    {
        return _Data;
    }

    // Use this for initialization
    void Start ()
    {
        _Sensor = KinectSensor.GetDefault();

        if (_Sensor != null)
        {
            _Reader = _Sensor.BodyFrameSource.OpenReader();

            if (!_Sensor.IsOpen)
            {
                _Sensor.Open();
            }
        }

        if (EventSystem == null)
        {
            return;
        }

        _InputModule = EventSystem.GetComponent<KinectInputModule>();
        if (_InputModule == null)
        {
            return;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (_Reader != null)
        {
            var frame = _Reader.AcquireLatestFrame();
            if (frame != null)
            {
                if (_Data == null)
                {
                    _Data = new Body[_Sensor.BodyFrameSource.BodyCount];
                }

                frame.GetAndRefreshBodyData(_Data);

                InformInputModule();

                frame.Dispose();
                frame = null;
            }
        }
    }

    void InformInputModule()
    {
        Debug.Log("Informing input module");
        List<ulong> trackedIds = new List<ulong>();
        foreach (var body in _Data)
        {
            if (body == null)
            {
                continue;
            }

            if (body.IsTracked)
            {
                trackedIds.Add(body.TrackingId);
                Debug.Log("Parsing tracking id: " + body.TrackingId);
            }
        }

        // First delete untracked bodies
        //foreach (ulong trackingId in _TrackingIds)
        for (int i = _TrackingIds.Count - 1; i >= 0; i--)
        {
            ulong trackingId = _TrackingIds[i];
            if (!trackedIds.Contains(trackingId))
            {
                _TrackingIds.Remove(trackingId);
                Debug.Log("Removing tracking id: " + trackingId);
            }
        }

        foreach (var body in _Data)
        {
            if (body == null)
            {
                continue;
            }

            if (body.IsTracked)
            {
                if (!_TrackingIds.Contains(body.TrackingId))
                {
                    _TrackingIds.Add(body.TrackingId);
                    Debug.Log("Adding tracking id: " + body.TrackingId);
                }
                if (body.TrackingId == _TrackingIds[0])
                {
                    Debug.Log("Tracked body: " + body.TrackingId);
                    Debug.Log(_InputModule == null);
                    if (_InputModule != null) _InputModule.TrackBody(body);
                }
            }
        }
    }

    void OnApplicationQuit()
    {
        if (_Reader != null)
        {
            _Reader.Dispose();
            _Reader = null;
        }

        if (_Sensor != null)
        {
            if (_Sensor.IsOpen)
            {
                _Sensor.Close();
            }

            _Sensor = null;
        }
    }
}
