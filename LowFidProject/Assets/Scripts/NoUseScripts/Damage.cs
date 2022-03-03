using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] int health;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage(int damageAmount)
    {
        health -= damageAmount;

        if(health < 0)
        {
            Destroy(gameObject);

        }
    }
}
