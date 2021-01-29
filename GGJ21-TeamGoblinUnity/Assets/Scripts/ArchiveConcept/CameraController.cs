using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public enum TrackingStates
    {
        trackingTransform,
        groundedTransform,
        stationary
    }
    public TrackingStates trackingStates;

    public Transform cameraTransform;
    public Transform trackingTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = Vector2.zero;
        switch (trackingStates)
        {
            case TrackingStates.trackingTransform:
                pos = trackingTransform.position;
                pos.z = -10;
                cameraTransform.position = pos;

                break;
            case TrackingStates.groundedTransform:

                pos = trackingTransform.position;
                pos.y = 1.5f;
                pos.z = -10;
                cameraTransform.position = pos;
                break;
            case TrackingStates.stationary:
                break;
            default:
                break;
        }
    }
}
