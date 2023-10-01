using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    
    public float speed = 1.5f;
    private Animator anim;
    private float dirX = 0f;
    private float dirY = 0f;
    private Rigidbody2D rb;
    private enum MovementState { Idle, Running, Jumping, Falling };
   

    //Variabele die zal geïnitialiseerd worden op de SpriteRenderer component van de Player.
    //Via deze variabele kunnen we de property flipX aanspreken die we nodig hebben om de sprite
    //te flippen op de X-as.
    private SpriteRenderer mySpriteRenderer;

    //
    public GameObject bulletToRight, bulletToLeft;
    Vector2 bulletPos;

   
        
    //Awake() wordt uitgevoerd als het GameObject gemaakt wordt.
    private void Awake()
    {
        //De variabele mySpriteRenderer 
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    //Einde toevoeging

   
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Toegevoegd om de sprite te flippen op de X-as als er op de linkse pijltoets gedrukt wordt.
            mySpriteRenderer.flipX = true;
           

            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Toegevoegd om de sprite origineel te tonen als er op de rechtse pijltoets gedrukt wordt.
            //(origineel = kijkend naar rechts)
            mySpriteRenderer.flipX = false;
            

            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * speed * 2 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * Time.deltaTime;
        }

        if (Input.GetButtonDown( "Fire1"))
        {
            Fire(); //De functie Fire wordt uitgevoerd als de Fire1 button ingedrukt wordt (dit is ingesteld op de linkse CTRL toets).
        }

        // Controleer of de speler onder een bepaalde Y-positie valt (bijv. -10).
        if (transform.position.y < -10f)
        {
            // Laad de doodsscene.
            SceneManager.LoadSceneAsync(2);
        }

        UpdateAnimationState();
    }


    public void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.Running;
        }
        else if (dirX < 0f)
        {
            state = MovementState.Running;
        }
        else
        {
            state = MovementState.Idle;
        }

        if (dirY > .1f)
        {
            state = MovementState.Jumping;
        }
        else if(rb.velocity.y <= -.1f)
        {
            state = MovementState.Falling;
        }

        anim.SetInteger("state", (int)state);
    }


    void Fire()
    {

        //De positie van de bullet wordt geïnitialiseerd op de positie van de Player. Transform.position geeft immers
        //de positie van de Player aan aangezien dit script aan het Player object gekoppeld is.
        bulletPos = transform.position;

        if (mySpriteRenderer.flipX) //Indien flipX true is, kijkt de Player naar links en moet er een Bullet geïnstantieerd worden
        {                           //die naar links gaat.
            bulletPos += new Vector2(-0.4f, +0.05f); //De positie van de Bullet wordt iets naar links en iets naar boven verschoven t.o.v. de Player.
                                                     //Dit geeft het effect dat de Bullet aan de linkerkant van de Player vertrekt ter hoogte van zijn hand.

            Instantiate(bulletToLeft, bulletPos, Quaternion.identity); //Van de prefab bulletToLeft wordt een nieuwe instantie gemaakt
        }                                                              //die getoond wordt op de positie bulletPos.
        else
        {
            bulletPos += new Vector2(+0.4f, +0.05f); //De positie van de Bullet wordt iets naar rechts en iets naar boven verschoven t.o.v. de Player.
                                                     //Dit geeft het effect dat de Bullet aan de rechterkant van de Player vertrekt ter hoogte van zijn hand.

            Instantiate(bulletToRight, bulletPos, Quaternion.identity); //Van de prefab bulletToLeft (argument 1) wordt een nieuwe instantie gemaakt
        }                                                               //die getoond wordt op de positie bulletPos (argument 2).
                                                                        //De functie Instantiate heeft meerdere overloads. Hier gebruiken we de versie met
                                                                        //3 argumenten. Het derde argument geeft de rotatie aan. We stellen dit hier in op
                                                                        //Quaternion.identity, wat betekent: geen rotatie t.o.v. de wereld waarin het object
                                                                        //zich bevindt.
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            SceneManager.LoadSceneAsync(2);
        }

        if (collision.gameObject.CompareTag("Traps"))
        {

            SceneManager.LoadSceneAsync(2);
        }
    }
}

