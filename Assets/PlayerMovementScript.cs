using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public bool grounded = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) == true)
        {
            rigidbody2D.linearVelocityX = 2.5f;
        }

        if (Input.GetKey(KeyCode.A) == true)
        {
            rigidbody2D.linearVelocityX = -2.5f;
        }

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
        }
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
