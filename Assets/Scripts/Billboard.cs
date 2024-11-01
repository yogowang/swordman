using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
     void Update()
    {
        // Make the health bar face the camera
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0); // Flip it if it's facing the wrong direction
    }
}
