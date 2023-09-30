using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public static Text Highscore;                                                    

    void Start()
    {
        Highscore = GetComponent<Text>();                                                // Hier wordt de Text-component van het huidige GameObject opgehaald.
        Highscore.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();    // De tekst van de Highscore wordt hier geïnitialiseerd met de waarde die is opgeslagen uit PlayerPrefs.

        if (ScoreScript.scoreValue > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", ScoreScript.scoreValue);                        // Als de huidige score hoger is dan de opgeslagen highscore, wordt deze geüpdatet in PlayerPrefs.
            Highscore.text = "High Score: " + ScoreScript.scoreValue.ToString();           //Dit toont het 

        }
    }

    
}
