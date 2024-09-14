using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; 
    public float rotateSpeed = 120.0f; 
    public float jumpForce = 5.0f; 
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump")) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
    }

    private void FixedUpdate() {
        float moveVertical = Input.GetAxis("Vertical"); 
        Vector3 movement = speed * moveVertical * transform.forward * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
        float turn = Input.GetAxis("Horizontal") * rotateSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
