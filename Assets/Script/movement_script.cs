//using UnityEngine;

//public class movement_script : MonoBehaviour
//{
//    public Rigidbody rb;

//    public float forwardForce;
//    public float backwardForce;
//    public float jumpForce; // height/strength of the jump
//    public bool isGrounded; // simple ground check

//    void FixedUpdate()
//    {
//        if (Input.GetKey("d"))
//        {
//            rb.AddForce(forwardForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
//        }
//        if (Input.GetKey("a"))
//        {
//            rb.AddForce(backwardForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
//        }
//        if (Input.GetKey("w"))
//        {
//            rb.AddForce(0, 0, forwardForce * Time.deltaTime, ForceMode.VelocityChange);
//        }
//        if (Input.GetKey("s"))
//        {
//            rb.AddForce(0, 0, backwardForce * Time.deltaTime, ForceMode.VelocityChange);
//        }

//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            Jump();
//        }
//    }

//    void Jump()
//    {
//        if (isGrounded)
//        {
//            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
//            isGrounded = false;
//        }
//    }

//    void OnCollisionEnter(Collision collision)
//    {
//        // When hitting the ground, allow jumping again
//        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Obstacle"))
//        {
//            isGrounded = true;
//        }


//    }
//}



using UnityEngine;

public class movement_script : MonoBehaviour
{

    [Header("--------- Force Options ---------")]
    public Rigidbody rb;

    public float forwardForce;
    public float backwardForce;
    public float sideForce;
    public float jumpForce = 5f;
    public bool isGrounded;

    public float fallMultiplier = 2.5f;   // Faster fall
    public float lowJumpMultiplier = 2f; // Short hop

    void FixedUpdate()
    {
        // Movement
        if (Input.GetKey("d"))
        {
            rb.AddForce((forwardForce + sideForce) * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce((backwardForce - sideForce) * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, backwardForce * Time.deltaTime, ForceMode.VelocityChange);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // Better jump feel
        if (rb.linearVelocity.y < 0) // Falling
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.linearVelocity.y > 0 && !Input.GetKey(KeyCode.Space)) // Short hop
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Obstacle"))
        {
            isGrounded = true;
        }
    }
}
