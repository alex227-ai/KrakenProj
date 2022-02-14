using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    //[SerializeField] float xMov = 0f;
    [SerializeField] float speedMovement = 0f;
    [SerializeField] float gravity = 0f;
    //[SerializeField] float ySpeed;
    [SerializeField] float jumpSp = 0f;

    Rigidbody rb;
    private float directionY;


    // Ground check

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask GroundLayer;

    // ground check

    //Vector3 directions;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //GetMoving();
       // GetGrounded();
      TestMoving();
    }

    void TestMoving()
    {
        float xMov = Input.GetAxis("Vertical");
        float zMov = Input.GetAxis("Horizontal");
        Vector3 directions = new Vector3(xMov * speedMovement * Time.deltaTime, 0, zMov * speedMovement * Time.deltaTime);

        // JUMP 
        if (Input.GetButtonDown("Jump"))
        {
            directionY = jumpSp;
        }

        print(gravity + " " + directionY);

        directionY -= gravity * Time.deltaTime;
        directions.y = directionY;

        // JUMP

        rb.velocity = directions;

        bool Grounded()
        {
            return Physics.CheckSphere(groundCheck.position, 0.1f, GroundLayer);
        }

        // Time.deltaTime is the problem?

    }















    void GetMoving()
    {
        // Movement code
        float xMov = Input.GetAxis("Vertical") * speedMovement * Time.deltaTime;
        float zMov = Input.GetAxis("Horizontal") * speedMovement * Time.deltaTime;
       Vector3 directions = new Vector3(xMov, 0, zMov);
       // directions = directions * speedMovement * Time.deltaTime;

      
        //transform.Translate(xMov, 0, zMov);

        directions = new Vector3(xMov, 0, zMov);
        rb.velocity = directions;



        if (Input.GetButtonDown("Jump"))
        {
            directionY = jumpSp;
            print("Jumping rn");
        }

        print(gravity + " " + directionY);

        directionY -= gravity * Time.deltaTime;
        directions.y = directionY;

        // jump code 
        rb.velocity = directions;


    }

}
