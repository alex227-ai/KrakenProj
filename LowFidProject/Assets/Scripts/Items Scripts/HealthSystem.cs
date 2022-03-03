using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] int health = 10;

    Score scoreBoard;
    [SerializeField] int hitsPoints = 1;

    void Start()
    {
        scoreBoard = FindObjectOfType<Score>();
    }
    public void DealDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health < 0)
        {
            Destroy(gameObject);
            scoreBoard.Scoreboard(hitsPoints);
        }
    }
}
