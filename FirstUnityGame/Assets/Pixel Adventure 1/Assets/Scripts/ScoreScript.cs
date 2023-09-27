using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Vergeet niet UnityEngine.UI te includen!

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0; //De publieke variabele
                                  //waarin de score zal
                                  //bijgehouden worden.
                                  //Deze variabele krijgt via
                                  //het AlienScript zijn waarde.

    Text score; //Deze variabele gebruiken we om te
                //bepalen wat er op het scherm getoond
                //moet worden. (Zie beschrijving in de
                //functie Start())

    // Start is called before the first frame update
    void Start()
    {
        //De Text component van het ScoreText gameObject
        //wordt aan de lokale variabele score gekoppeld.
        //In de Update functie gebruiken we deze variabele
        //om de Text eigenschap van de Text component aan
        //te spreken.
        score = GetComponent<Text>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //De text eigenschap van de Text component
        //kunnen we aanspreken als score.text aangezien we
        //in de functie Start() reeds de koppeling maakten
        //tussen de lokale variabele score en de Text component.
        //Wat wordt er getoond?
        //Letterlijk de tekst "Score: " met daarna de inhoud
        //van de variabele scoreValue.

        score.text = "Enemies Killed: " + scoreValue;

        if (scoreValue==10)
        {
            score.text = "Enemies Killed: " + scoreValue + "  Killed 'em All";
        }
        
        
    }
}