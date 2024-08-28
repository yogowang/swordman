using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// https://www.youtube.com/watch?v=c9kxUvCKhwQ
public class Jump : MonoBehaviour
{
    private Rigidbody rb;
    private float jumpForce = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
