using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speeder : MonoBehaviour
{
  //  [SerializeField] int speederCount;

    GameObject personCollecting;
    Inventory pi;
    PlayerController pc;
    Rigidbody rb;

    private void Start()
    {
        pc = GameObject.FindObjectOfType<PlayerController>();
        personCollecting = pc.gameObject;
        rb = personCollecting.GetComponent<Rigidbody>();

    }


    private void OnTriggerEnter(Collider other)
    {
        print("hit");
        personCollecting = other.gameObject;
        if (personCollecting.tag == "Player")
        {
            pi = personCollecting.GetComponent<Inventory>();
            SpeederCount();
            VelocityExtra();
          //  pc.speedMovement = 1f; // Add 1 unit to speedMovement

            /*
              Code for speedMovement +1 for a limited amount of time

            */
        }
    }

  

    void SpeederCount()
    {
        print("You got the Speeder");
        pi.SetObject(true);
        Destroy(gameObject);
        pi.MySpeeders++; // Add to My Speeder count
    }

    void VelocityExtra()
    {
       // float spMov = pc.speedMovement;
       // rb.AddForce(transform.right * 50f);
        rb.AddForce(transform.forward * 50f);

    }



    // not working


    /*  private void OnCollisionEnter(Collision collision)
   {
       personCollecting = collision.gameObject;
       if (personCollecting.tag == "Player")
       {
           pi = personCollecting.GetComponent<Inventory>();
           SpeederCount();
           pc.speedMovement = 1f; // Add 1 unit to speedMovement


             Code for speedMovement +1 for a limited amount of time


       }

   }  */
}