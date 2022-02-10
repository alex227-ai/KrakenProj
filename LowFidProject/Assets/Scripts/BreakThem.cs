using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Script to break objects and or doors
public class BreakThem : MonoBehaviour
{
    [SerializeField] bool canBreak;
    
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
        if (canBreak)
        {
            BreakMe();
        }
    }

    void BreakMe()
    {
        print("You break me");
        Destroy(gameObject);
    }
}
