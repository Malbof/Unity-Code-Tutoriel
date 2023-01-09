using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private bool IsJumping ;
    private bool isGrounded;

    public Transform GroundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;


    private void Update()
    {
        

        //movement of the player on the horizental axes
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;

        //condition of the jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            IsJumping = true;
        }


        //Fonction used to flip the direction of the player animation
        Flip(rb.velocity.x);

        //Used for the character animation (Math fonction is used because the speed to the back is negative
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
    }

    void FixedUpdate()
    {
        // Check is the player is on the floot to permit to jump
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, collisionLayers);

        //Fonction of the Player to move
        MovePlayer(horizontalMovement);

    }

    //Fonction of the player movement and his parameter
    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        //setting the force of the jump of the player
        if(IsJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            IsJumping = false;
        }
    }

    //This method is used to flix the direction that the player is looking depending of the velocity ( positive to the right side, negatif for the left side)
    void Flip(float _velocity)
    {
        if(_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }else if(_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GroundCheck.position, groundCheckRadius);
    }
}