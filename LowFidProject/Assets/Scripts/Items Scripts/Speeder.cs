using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speeder : MonoBehaviour
{
    [SerializeField] int speederCount;

    GameObject personCollecting;
    Inventory pi;
    PlayerController pc;

    private void Start()
    {
        pc = GetComponent<PlayerController>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        personCollecting = collision.gameObject;
        if (personCollecting.tag == "Player")
        {
            pi = personCollecting.GetComponent<Inventory>();
            SpeederCount();
            pc.speedMovement = 1f; // Add 1 unit to speedMovement

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
        speederCount++; // Add to speederCount
    }
}