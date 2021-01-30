using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadder : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;
    private float inputHorizontal;
    private float inputVertical;
    public float distance;
    public LayerMask ladderLayer;
    private bool isClimbing;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2( inputHorizontal * speed, rb.velocity.y);

        inputVertical = Input.GetAxis("Vertical");

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, ladderLayer);

        if(hitInfo.collider != null)
        {
            if(inputVertical > 0)
            {
                isClimbing = true;
            }
        }
        else
        {
            isClimbing = false;
            rb.gravityScale = 1;
        }

        if(isClimbing == true)
        {
            inputVertical = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * speed);
            rb.gravityScale = 0;
        }
    }
}
