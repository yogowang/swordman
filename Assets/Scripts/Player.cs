using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//https://www.youtube.com/watch?v=hlO0XlqZFBo
public class Player : MonoBehaviour
{
    private float moveSpeed = 5f;
    private float rotationSpeed = 720f;
    private Transform cameraTransform;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        // Get input from the player
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow keys
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down arrow keys

        // Calculate the movement direction relative to the camera
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Keep the movement direction on the horizontal plane (ignore the y component)
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        // Combine the movement input with the camera's orientation
        Vector3 moveDirection = (forward * moveZ + right * moveX).normalized;
        var velocity=moveDirection*moveSpeed;
        animator.SetFloat("moveSpeed",velocity.magnitude);
        // If there's movement input, move and rotate the player
        if (moveDirection.magnitude >= 0.1f)
        {
            // Move the player in the direction based on input
            transform.Translate(velocity * Time.deltaTime, Space.World);
            // Calculate the target rotation based on the movement direction
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

            // Smoothly rotate the player to face the movement direction
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
