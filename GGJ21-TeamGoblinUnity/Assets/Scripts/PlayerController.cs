using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveInput;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask groundLayers;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    // This is where I came in ~Boyd
    public AudioSource audioWalk;
    public AudioSource audioLand;
    bool isMoving;
    bool hitGround;
    

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, groundLayers);

        //Boyd Code
        if(isGrounded && !hitGround)
        {
            audioLand.Play();
        }


        hitGround = isGrounded;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);


        if(moveInput > 0)
        {
            rb.transform.rotation = Quaternion.Euler( 0, 0, 0);
        }
        else if(moveInput < 0)
        {
            rb.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (isGrounded == true && Input.GetKey(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity += Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity += Vector2.up * jumpForce / 9.6f;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        //To get Audio to play when walking
        if (rb.velocity.x != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (isMoving)
        {
            if (isGrounded)
            {
                if (!audioWalk.isPlaying)
                    audioWalk.Play();
            }
            else
            {
                audioWalk.Stop();
            }
        }
        else
        {
            audioWalk.Stop();
        }
    }
}