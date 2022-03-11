using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float destroyBullTimer = 5f;

    private void Start()
    {
        Invoke("DestroyBullet", destroyBullTimer);
    }

    private void OnTriggerEnter(Collider collision)
    {
        //print(collision.gameObject.name);

        HealthSystem damageGameObject = collision.gameObject.GetComponent<HealthSystem>();

        if (damageGameObject != null)
        {
            damageGameObject.DealDamage(damage);
            Destroy(gameObject);
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
