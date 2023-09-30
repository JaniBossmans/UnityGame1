using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EindScore : MonoBehaviour
{
    Text score;

    void Start()
    {
        score = GetComponent<Text>();

        if (ScoreScript.scoreValue==10)
        {
            score.text = $"Je Bent gewonnen!!!\nBehaalde Score: {ScoreScript.scoreValue}";
        }
        else
        {
            score.text = $"Je Bent Verloren!!!\nBehaalde Score: {ScoreScript.scoreValue}";
        }
        
    }
}
