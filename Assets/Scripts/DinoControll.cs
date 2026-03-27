using UnityEngine;

public class DinoController : MonoBehaviour
{
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private CapsuleCollider2D col; 
    private Animator anim;

    private bool isGrounded = true;
    private bool isSliding = false;

    private Vector2 originalSize;    
    //private Vector2 originalOffset; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();  
        anim = GetComponent<Animator>();

        originalSize = col.size;
        //originalOffset = col.offset;

        anim.SetBool("isRunning", true);
    }

    public void Jump()
    {
        if (!isGrounded || isSliding) return;

        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        isGrounded = false;

        anim.SetTrigger("Jump");
        anim.SetBool("isGrounded", false);
    }

    public void SlideStart()
    {
        if (isSliding || !isGrounded) return;
        isSliding = true;

        col.size = new Vector2(originalSize.x, originalSize.y * 0.5f);
        //col.offset = new Vector2(originalOffset.x, originalOffset.y - originalSize.y * 0.25f);

        anim.SetBool("isSliding", true);
    }

    public void SlideEnd()
    {
        isSliding = false;

        col.size = originalSize;
        //col.offset = originalOffset;

        anim.SetBool("isSliding", false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("isGrounded", true);
        }
    }
}