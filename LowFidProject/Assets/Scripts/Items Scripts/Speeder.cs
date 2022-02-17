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

    float speedTime;

    bool isSpeeding;

    private void Start()
    {
        pc = GameObject.FindObjectOfType<PlayerController>();
        personCollecting = pc.gameObject;
        rb = personCollecting.GetComponent<Rigidbody>();

    }

    private void Update()
    {
        /*if(isSpeeding)
        {
            VelocityExtra();*/
    }


    private void OnTriggerEnter(Collider other)
    {
        print("hit");
        personCollecting = other.gameObject;
        if (personCollecting.tag == "Player")
        {
            pi = personCollecting.GetComponent<Inventory>();
            pc.isSpeeding = true;
            SpeederCount();
            //VelocityExtra();

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
        pi.MySpeeders++; // Add to My Speeder count
        Destroy(gameObject);
    }

   /* void VelocityExtra()
    {
        // float spMov = pc.speedMovement;
         pc.speedMovement = 50f;

        float slowDown = 5f;
        speedTime += Time.deltaTime;

        if (speedTime > slowDown)
        {
            print("slow down");
            speedTime = 0;
            isSpeeding = false;


        }

       // print(speedTime);
    }*/














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