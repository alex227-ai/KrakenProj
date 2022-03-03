using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{

    [SerializeField] Rigidbody bullet;
    [SerializeField] float bSpeed;
    [SerializeField] float xOffSet;

    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    {
        Rigidbody bulletRb;
        bulletRb = Instantiate(bullet, transform.position + new Vector3 (xOffSet, 0, 0), transform.rotation);
        bulletRb.AddForce(transform.right * bSpeed, ForceMode.Impulse);
    }
}
