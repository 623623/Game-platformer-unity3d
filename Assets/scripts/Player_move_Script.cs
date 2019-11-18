using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_move_Script : MonoBehaviour
{

    Rigidbody2D rb;
    SpriteRenderer sp;
    Animator anim;
    public float speed;
    public float jumpVector = 1.0f;
    float moveInput;

    public float isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int jewels;
    private AudioSource eGem;
    public Text jewelsText;



    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        

    }



    private void FixedUpdate()
    {
        //код кнопок лево и право+анимации
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            
            anim.Play("Run_Rogue");
            sp.flipX = false;
        }

        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            
            anim.Play("Run_Rogue");
            sp.flipX = true;
        }
        else
        {
            anim.Play("Idle_Rogue");

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpVector;
            anim.Play("Jump_Rogue");

        }
        //код бега игрока
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        


    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "jewel")
        {
            Destroy(col.gameObject);
            jewels++;
            jewelsText.text = "Jewels " + jewels;



        }



    }


}


