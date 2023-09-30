using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Vergeet niet UnityEngine.UI te includen!
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0; //De publieke variabele
                                  //waarin de score zal
                                  //bijgehouden worden.
                                  //Deze variabele krijgt via
                                  //het EnemyScript zijn waarde.

    Text score; //Deze variabele gebruiken we om te
                //bepalen wat er op het scherm getoond
                //moet worden. (Zie beschrijving in de
                //functie Start())
    

    // Start is called before the first frame update
    void Start()
    {
        //Zorgt ervoor dat de text word gelinkt aan het in-unity text component
        score = GetComponent<Text>();

        //Dit zorgt ervoor dat elke game met een nieuwe score start.
        scoreValue = 0;
    }

   
    void Update()
    {
        //De text eigenschap van de Text component
        //kunnen we aanspreken als score.text aangezien we
        //in de functie Start() reeds de koppeling maakten
        //tussen de lokale variabele score en de Text component.
        

      
        
        if (scoreValue==10)
        {
            score.text = "Killed 'em All, Won the game    Go Trough the Trophy to quit";

           
        }

        else
        {
            score.text = $"Score:{ scoreValue},      Nog {10-scoreValue} enemies te gaan";
        }
        
    }
    void OnCollisionEnter2D(Collision2D collision)   //Zorgt ervoor dat je alleen door de finish kunt bij 10 kills
    {
        if (scoreValue == 10)
        {
            
            if (collision.gameObject.CompareTag("End"))
            {
                
                SceneManager.LoadSceneAsync(2);
            }
        }

    }

}