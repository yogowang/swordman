using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// https://www.youtube.com/watch?v=c9kxUvCKhwQ
public class Jump : MonoBehaviour
{
    private Rigidbody rb;
    private float jumpForce = 10f;
    private Animator animator;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded && Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player has landed on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;

            // Set the isJumping parameter to false when grounded
            animator.SetBool("isJump", false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Check if the player is no longer touching the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("isJump", true);
        }
    }
}
