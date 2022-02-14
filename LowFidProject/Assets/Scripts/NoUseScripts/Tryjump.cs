using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tryjump : MonoBehaviour
{
    [SerializeField] GameObject Player;
    //[SerializeField] float xMov = 0f;
    [SerializeField] float speedMovement = 0f;
    [SerializeField] float gravity = 0f;
    //[SerializeField] float ySpeed;
    [SerializeField] float jumpSp = 0f;

    // Rigidbody rb;
    CharacterController cc;
    private float directionY;

    //private Vector3 inputVector;


    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetMoving();
    }

    void GetMoving()
    {
        Vector3 directions = new Vector3(Input.GetAxis("Vertical") * Time.deltaTime * speedMovement, 0, Input.GetAxis("Horizontal") * Time.deltaTime * speedMovement);


        if (Input.GetButtonDown("Jump"))
        {
            directionY = jumpSp;
            print("Jumping rn");
        }

        directionY -= gravity * Time.deltaTime;
        directions.y = directionY;
        cc.Move(directions);
    }

}