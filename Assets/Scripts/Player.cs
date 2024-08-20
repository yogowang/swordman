using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    private float moveSpeed = 5f;
    private float rotationSpeed = 720f;

    // Start is called before the first frame update
    void Start()
    {
       
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

        // Calculate the movement direction
        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ).normalized;

        // If there's movement input, move and rotate the player
        if (moveDirection.magnitude >= 0.1f)
        {
            // Move the player in the direction based on input
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

            // Calculate the target rotation based on the movement direction
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

            // Smoothly rotate the player to face the movement direction
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
