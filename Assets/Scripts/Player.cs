using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveSpeed = 5f;
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

        // Move the player in the direction based on input
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
}
