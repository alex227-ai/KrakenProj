using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Script to pickup object that can allowe you to destroy other objects

public class PickToBreak : MonoBehaviour

{
    GameObject personCollecting;
    Inventory playerInventory;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        personCollecting = collision.gameObject;
        if(personCollecting.tag == "Player")
        {
            playerInventory = personCollecting.GetComponent<Inventory>();
            PickMe();
        }
        
    }

    void PickMe()
    {
        print("You got me");
        playerInventory.SetObject(true);
        Destroy(gameObject);
    }
}
