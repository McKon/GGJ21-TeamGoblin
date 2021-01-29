using UnityEngine;

public class GrabObjects : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform handTransform;

    public float equipRadius;
    public Transform ItemEquipRegion;

    public LayerMask objectLayer;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (ItemEquipRegion)
            {
                ItemEquipRegion = null;
            }
            else
            {
                Collider2D collider2D = Physics2D.OverlapCircle(handTransform.position, equipRadius, objectLayer);
                if (collider2D && ItemEquipRegion == null)
                {
                    Debug.Log("Found Item @ " + collider2D.transform.position);
                    
                    ItemEquipRegion = collider2D.transform;
                }
            }
        }

        if (ItemEquipRegion)
        {
            ItemEquipRegion.position = handTransform.position;
        }
    }
}