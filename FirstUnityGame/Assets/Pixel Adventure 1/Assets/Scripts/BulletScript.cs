using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    

    //Declaratie en initialisatie van de public variables.

    public float velX = 20f; // De horizontale snelheid wordt ingesteld op 20.
    public float velY = 0f; // De verticale snelheid is 0 zodat de bullet niet naar beneden valt.
    
    //Declaratie overige variabele(n)

    Rigidbody2D rb; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //De variabele rb wordt gekoppeld aan de Rigidbody2D component
                                          //waaraan dit script gekoppeld is, dus aan de Rigidbody2D van een Bullet.
    }

    void OnBecameInvisible() //Deze functie wordt uitgevoerd als het object de viewport (het zichtbare deel van het game) verlaat.
    {
        Destroy(gameObject); //De Destroy functie vernietigt het gameObject -> de Bullet wordt verwijderd.
    }

    void OnTriggerEnter2D(Collider2D other) //Deze functie wordt uitgevoerd als de Bullet-Collider die als trigger ingesteld staat
                                            //door een andere collider getriggerd wordt.
    {
        if (other.CompareTag("Enemy"))  //Is de collider die de trigger veroorzaakte een component van een GameObject met als tag 'Enemy'.
        {                               //Deze test vermijdt dat de botsing van een Bullet met een eventueel ander object, de Bullet onnodig zou laten verdwijnen.
            Destroy(gameObject);        //Indien de Bullet een Enemy geraakt heeft (if geeft dan true), dan wordt de kogel vernietigd.
        }

        if (other.CompareTag("Tilemap"))  //Is de collider die de trigger veroorzaakte een component van een GameObject met als tag 'Tilemap'.
        {                               //Deze test vermijdt dat de botsing van een Bullet met een eventueel ander object, de Bullet onnodig zou laten verdwijnen.
            velX = velX - (velX * 2);     //Indien de Bullet de zijkant van een platform geraakt heeft (if geeft dan true), dan veranderd de kogel van richting.
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velX, velY); //De property velocity geeft de snelheid aan waarmee de kogel binnen elk frame bewogen wordt. 
                                               //Deze instructie zorgt er dus voor dat de kogel blijft voortbewegen tegen de ingestelde snelheid.
    }
}
