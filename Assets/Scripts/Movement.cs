using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;




public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public Transform groundCheckTransform;
    public float groundCheckRadius;
    public Transform sprite;

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

        isGrounded = Physics2D.OverlapCircle(groundCheckTransform.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            Vector3 rotation = sprite.rotation.eulerAngles;
            rotation.z = Mathf.Round(rotation.z / 90) * 90;
            sprite.rotation = Quaternion.Euler(rotation);

            if (Input.GetMouseButton(0))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
        }
        else
        {
            sprite.Rotate(Vector3.back * 2);
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
        
        RestartLevel();
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}