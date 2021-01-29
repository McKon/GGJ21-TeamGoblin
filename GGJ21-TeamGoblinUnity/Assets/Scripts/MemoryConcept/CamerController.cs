using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerController : MonoBehaviour
{
    public Transform cameraTransform;
    public float speed;
    public float moveTreshold;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 desiredCamPos = Vector3.zero;
        desiredCamPos = Input.mousePosition;
        desiredCamPos.x -= Screen.width / 2;
        desiredCamPos.y -= Screen.height / 2;
        if (desiredCamPos.x > Screen.width  *  moveTreshold || 
            desiredCamPos.x < Screen.width  * -moveTreshold || 
            desiredCamPos.y > Screen.height *  moveTreshold || 
            desiredCamPos.y < Screen.height * -moveTreshold
        )
        {
            desiredCamPos = desiredCamPos.normalized * -speed; ;
            desiredCamPos.z = -10;
            cameraTransform.position -= desiredCamPos;
        }



        desiredCamPos = cameraTransform.position;
        desiredCamPos.z = -10;
        cameraTransform.position = desiredCamPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
