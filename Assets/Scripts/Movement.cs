using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead) return; 
        
        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
        
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, groundLayer);
        
        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            Die(); 
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Block"))
        {
            foreach (ContactPoint2D hit in collision.contacts)
            {
                if (hit.normal.y < 0.2f)
                {
                    Die();
                    return; 
                }
            }
        }
    }

    void Die()
    {
        if (isDead) return;

        isDead = true;
        Debug.Log("DEAD");

        rb.linearVelocity = Vector2.zero;
        rb.isKinematic = true;
    }
}