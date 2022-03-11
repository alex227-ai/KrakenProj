using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TMP_Text tScore; // text score

    int score;

     // Start is called before the first frame update
    void Start()
    {
        tScore = GetComponent<TMP_Text>();
        tScore.text = "0";
    } 

    public void Scoreboard(int amountToIncrease)
    {
        score += amountToIncrease;


        tScore.text = score.ToString();

    }
}
