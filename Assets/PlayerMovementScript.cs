using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public new Rigidbody2D rigidbody2D;
    public bool grounded = false;
    public float speed = 2.5f;
    private bool facingRight = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Get horizontal input



        // Move player based on input

        transform.Translate(new Vector2(horizontalInput * speed, 0) * Time.deltaTime);



        // Flip player if moving in opposite direction

        if (horizontalInput < 0 && facingRight)

        {

            FlipPlayer();

        }

        else if (horizontalInput > 0 && !facingRight)

        {

            FlipPlayer();

        }

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
        }
    }

    void FlipPlayer()
    {

        facingRight = !facingRight; // Toggle facing direction

        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
       if (collision.collider.CompareTag("Ground"))
        {
            grounded=false;
        } 
    }

    void Jump()
    {
        rigidbody2D.linearVelocityY = 5;

    }


}
