using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRequester : MonoBehaviour
{
    public Transform CollectArea;
    public Sprite RequestedObject;
    public GameObject RequestIcon;
    public float checkRadius;
    public LayerMask ObjectLayer;
    public Color ColorOverlay;

    // Start is called before the first frame update
    void Start()
    {
        RequestIcon.GetComponent<SpriteRenderer>().sprite = RequestedObject;
        RequestIcon.GetComponent<SpriteRenderer>().color = ColorOverlay;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider2D collider2D = Physics2D.OverlapCircle(CollectArea.position, checkRadius, ObjectLayer);
        if (collider2D)
        {
            if (collider2D.gameObject.GetComponent<SpriteRenderer>().sprite == RequestedObject)
            {
                Destroy(collider2D.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
