using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public string itemName = "Some Item"; // each item must have a unique name
    public Texture itemPreview;




    // Start is called before the first frame update
    void Start()
    {
        // change item tag to Respawn to detect when we look at it

        gameObject.tag = "Respawn";
    
    }

    public void PickItem()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
