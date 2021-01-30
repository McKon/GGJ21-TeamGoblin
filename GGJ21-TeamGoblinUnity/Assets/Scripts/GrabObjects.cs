using UnityEngine;

public class GrabObjects : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform handTransform;

    public float equipRadius;
    public GameObject EquipItem;

    public LayerMask objectLayer;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (EquipItem)
            {
                EquipItem.GetComponent<Rigidbody2D>().gravityScale = 1;
                EquipItem = null;
            }
            else
            {
                Collider2D collider2D = Physics2D.OverlapCircle(handTransform.position, equipRadius, objectLayer);
                if (collider2D && EquipItem == null)
                {
                    Debug.Log("Found Item @ " + collider2D.transform.position);
                    
                    EquipItem = collider2D.gameObject;
                }
            }
        }

        if (EquipItem)
        {
            EquipItem.GetComponent<Rigidbody2D>().gravityScale = 0;
            Vector3 vector3 = handTransform.position;
            vector3.z = 0.1f;
            EquipItem.GetComponent<Transform>().position = vector3;

        }
    }
}