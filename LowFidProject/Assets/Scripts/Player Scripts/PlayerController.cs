using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float speedMovement = 0f;
    [SerializeField] float jumpSpeed = 0f;

    Rigidbody rb;
    public Camera playerCamera; // try for inventory
    [SerializeField] LayerMask Ground;
    [SerializeField] Transform groundCheck;

    float speedTime;

    public bool isSpeeding;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetMoving();

        if (isSpeeding)
        {
            VelocityExtra();
        }
    }

    void GetMoving()
    {
        Vector3 directions = new Vector3(Input.GetAxis("Vertical") * speedMovement, rb.velocity.y, -Input.GetAxis("Horizontal") * speedMovement);
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

    void VelocityExtra()
    {
        // float spMov = pc.speedMovement;
        speedMovement = 50f;

        float slowDown = 5f; // 5 fps
        speedTime += Time.deltaTime;

        if (speedTime > slowDown)
        {
            print("slow down");
            speedTime = 0;
            isSpeeding = false;
            speedMovement = 10f; // insert speedmovement chosen in the inspector
        }

         print(speedTime);
    }
}
