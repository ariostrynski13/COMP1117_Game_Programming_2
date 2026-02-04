using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputHandler), typeof(Rigidbody2D))]
public class Player : Character
{
    //Jumping logic
    [Header("Movement Settings")]
    [SerializeField] private float jumpForce = 12f;  //Force of my jump
    [SerializeField] private LayerMask groundLayer;  //Checking to see if i'm standing on the ground layer
    [SerializeField] private Transform groundCheck;  //Position of my ground check
    [SerializeField] private float groundCheckRadius = 0.2f;   //Size of my ground check

    private Rigidbody2D rBody; //Used to apply a force to move or jump
    private PlayerInputHandler input;  //Reads the input
    private bool isGrounded;  //Holds the result of the ground check operation
    private float currentSpeedModifier = 1f;

    protected override void Awake()
    {
        base.Awake();
        //Initialize
        rBody = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInputHandler>();
        
    }

    private void Update()
    {
        //Perform my ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        Debug.Log(isGrounded);

        anim.SetFloat("xVelocity", Mathf.Abs(rBody.linearVelocity.x));
       
        //Jumping
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rBody.linearVelocity.y);

        //Handle Sprite Flipping
        if (input.MoveInput.x != 0 && !isDead)
        {
            transform.localScale = new Vector3(Mathf.Sign(input.MoveInput.x), 1, 1);
        }
    }

    void FixedUpdate()
    {
        if(IsDead)
        {
            return;
        }
        //Handle movement
        HandleMovement();
        //Handle jumping
        HandleJump();
        //Optional: Handle mario-like falling
    }

    private void HandleMovement()
    {
        //We get MoveInput from InputHandler
        //We get MoveSpeed from our parent class (Character)
        float horizonatalVelocity = input.MoveInput.x * MoveSpeed * currentSpeedModifier;

        rBody.linearVelocity = new Vector2(horizonatalVelocity, rBody.linearVelocity.y);
        currentSpeedModifier = 1f; //Reset speed modifier after applying movement
    }

    private void HandleJump()
    {
        //Only jump if the input handle's jump property is true
        if(input.JumpTriggered && isGrounded)
        {
            //Apply Jump Force
            ApplyJumpForce();
            //"Consume the Jump""
        }
    }

    private void ApplyJumpForce()
    {
        //Reset vertical velocity first to ensure consistant jump height
        rBody.linearVelocity = new Vector2(rBody.linearVelocity.x, 0);

        rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void ApplySpeedModifier(float speedModifier)
    {
               currentSpeedModifier = speedModifier;
    }

    public override void Die()
    {
        isDead = true;
        Debug.Log("Player has died!");

        //Player death logic!!
        //================================
        //Add player specific death logic
        //Set death animation
        //Trigger death UI
        //Initiate level reset logic
    }
}
