using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private bool isDead = false; //Een extra variabele die we zullen gebruiken om te vermijden
                                 //dat een Enemy dat geraakt wordt door een bullet binnen eenzelfde
                                 //frame meer dan 1 punt genereert. (zie verder)

    void OnTriggerEnter2D(Collider2D other) //Deze functie wordt uitgevoerd als de collider
                                            //die als trigger ingesteld staat voor een Enemy
                                            //getriggerd wordt.
    {
        if (other.CompareTag("Bullet"))  //Werd de trigger veroorzaakt door een object met de tag
        {                                //Bullet? (Controle dat de Enemy niet door iets anders
                                         //geraakt werd.)
            Destroy(gameObject);         //Indien geraakt door een Bullet -> verwijder Enemy-object.

            if (!isDead) //Als de variabele isDead op false staat wordt onderstaand stuk code uitgevoerd.
            {
                ScoreScript.scoreValue += 1; //Indien geraakt door een Bullet -> de score van de Player
                                             //wordt met 1 verhoogd.
                isDead = true;               //De variabel isDead wordt op true gezet. Dit zorgt ervoor
                                             //dat deze enemy slechts 1 punt kan genereren. Het is immers
                                             //mogelijk dat de trigger anders meerdere punten genereert.
            }
        }


    }
}