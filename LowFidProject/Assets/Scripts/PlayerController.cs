using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speedMovement = 0f;
    [SerializeField] float jumpSpeed = 0f;

    Rigidbody rb;
    [SerializeField] LayerMask Ground;
    [SerializeField] Transform groundCheck;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetMoving();
    }

    void GetMoving()
    {
        Vector3 directions = new Vector3(Input.GetAxis("Vertical") * speedMovement, rb.velocity.y, Input.GetAxis("Horizontal") * speedMovement);
        rb.velocity = directions;

        if (Input.GetButtonDown("Jump") && Grounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
        }

        bool Grounded()
        {
            return Physics.CheckSphere(groundCheck.position, 0.1f, Ground);
        }
    }
}
