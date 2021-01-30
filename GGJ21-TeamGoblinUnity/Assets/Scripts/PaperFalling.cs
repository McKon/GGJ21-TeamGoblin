using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperFalling : MonoBehaviour
{
    public LayerMask groundLayers;
    public float checkRadius;
    public float gravity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 vector3 = this.transform.position;

        vector3.y -= gravity;
        vector3.x += Mathf.Sin(vector3.y)/10;
        this.transform.position = vector3;

        if( Physics2D.OverlapCircle(this.transform.position, checkRadius, groundLayers) )
        {
            Destroy(this.gameObject);
        }
    }
}
