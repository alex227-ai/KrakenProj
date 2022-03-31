using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    [SerializeField] bool findPlayer;

    private void OnTriggerEnter(Collider other)
    {
        print("Monster has killed player");
        GameUI gameUI = FindObjectOfType<GameUI>();
        gameUI.CheckGameState(GameUI.GameState.GameOver);
        Destroy(other.gameObject);
    }

    public void FindPlayer(bool Player)
    {
        findPlayer = Player;
    }
}