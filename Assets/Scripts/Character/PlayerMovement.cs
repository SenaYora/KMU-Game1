using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerCollisions coll;
    [HideInInspector]
    public Rigidbody2D rb;
    private Animator anim;

    [Space]
    [Header("Stats")]
    public float speed = 10;
    public float jumpForce = 50;
    public float slideSpeed = 2;
    public float wallJumpLerp = 10;

    [Space]
    [Header("Booleans")]
    public bool canMove;
    public bool isHoldingJump;
    public bool wallJumped;
    public bool wallSlide;

    [Space]
    [Header("Jump Control")]
    public float minJumpMultiplicator;
    public float maxJumpMultiplicator;
    public float maxHoldingJumpTime;
    public float holdingJumpTime;
    public float wallJumpXMultiplicator;
    public float wallJumpYMultiplicator;

    [Space]

    public int side = 1;

    void Start()
    {
        coll = GetComponent<PlayerCollisions>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float xRaw = Input.GetAxisRaw("Horizontal");
        Vector2 dir = new Vector2(wallJumped ? xRaw : x, 0);

        Walk(dir);
        anim.SetFloat("vSpeed", rb.velocity.y);
        anim.SetBool("isGrounded", coll.onGround);

        // If on ground, enable jump
        if (coll.onGround)
        {
            wallJumped = false;
            GetComponent<PlayerJump>().enabled = true;
        }

        // If on wall and not on ground, start wallSlide
        if (coll.onWall && !coll.onGround && xRaw * side > 0.5f)
        {
            wallJumped = false;
            wallSlide = true;
            WallSlide();
        }

        // Disable wallSlide if on ground or not on wall
        if (!coll.onWall || coll.onGround)
        {
            wallSlide = false;
            anim.SetBool("isWallsliding", false);
        }

        // If Jumping, jump if on ground, wallJump if on wall
        if (Input.GetButtonDown("Jump"))
        {
            if (coll.onGround)
            {
                holdingJumpTime = maxHoldingJumpTime;
                Jump(Vector2.up);
            }
            if (coll.onWall && !coll.onGround)
            {
                holdingJumpTime = maxHoldingJumpTime;
                WallJump();
            }
        }

        // If Holding Jump key and not wallSliding then jump again
        if (isHoldingJump && !wallSlide)
        {
            Jump(Vector2.up);
        }

        if (Input.GetButtonUp("Jump"))
        {
            isHoldingJump = false;
        }

        if (wallSlide)
            return;

        if (xRaw > 0 && canMove)
        {
            side = 1;
        }
        if (xRaw < 0 && canMove)
        {
            side = -1;
        }
        Flip();
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;

        if (side * localScale.x < 0)
            localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void WallJump()
    {
        StopCoroutine(DisableMovement(0));
        StartCoroutine(DisableMovement(.1f));

        Vector2 wallDir = side > 0 ? Vector2.left : Vector2.right;

        wallJumped = true;
        side *= -1;
        Jump(Vector2.up * wallJumpYMultiplicator + wallDir * wallJumpXMultiplicator, true);
    }

    private void WallSlide()
    {
        if (!canMove)
            return;

        anim.SetBool("isWallsliding", true);
        rb.velocity = new Vector2(rb.velocity.x, -slideSpeed);
    }

    private void Walk(Vector2 dir)
    {
        anim.SetBool("isWalking", false);
        if (!canMove)
            return;

        if (coll.onGround)
        {
            anim.SetBool("isWalking", dir.x * speed != 0);
            anim.SetBool("isJumping", false);
            rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = Vector2.Lerp(rb.velocity, (new Vector2(dir.x * speed, rb.velocity.y)), wallJumpLerp * Time.deltaTime);
        }
    }

    private void Jump(Vector2 dir, bool isWalljump = false)
    {
        anim.SetBool("isJumping", true);
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpForce * GetPercentJumpMultiplicator();

        if (Input.GetButton("Jump") && !isWalljump)
        {
            holdingJumpTime -= Time.deltaTime;
            if (holdingJumpTime < 0)
            {
                isHoldingJump = false;
            }
            else
            {
                isHoldingJump = true;

            }
        }
    }

    IEnumerator DisableMovement(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;
    }

    void RigidbodyDrag(float x)
    {
        rb.drag = x;
    }

    private float GetPercentJumpMultiplicator()
    {
        float percentHoldingJumpTime = 1.0f - holdingJumpTime / maxHoldingJumpTime;
        float diff = maxJumpMultiplicator - minJumpMultiplicator;
        float diffPercent = percentHoldingJumpTime * diff;

        return minJumpMultiplicator + diffPercent;
    }
}
