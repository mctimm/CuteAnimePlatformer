﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    bool isGrounded = true;

    bool gameOver = false;

    int Health = 5;

    float BLINKTIMETOTAL = 3.0f;
    float BLINKDURATION = 0.2f;
    float blinkTimeCurrent = 0.0f;
    float blinkTimeCurrentmini = 0.0f;

    bool isBlinking;


    [SerializeField]
    Transform groundCheck;
    float speed = 5f;
    float jumpSpeed = 7f;
    Animator animator;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Awake(){
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
    }

    void FixedUpdate(){
        //float direction = Input.GetAxis("Horizontal");
        if(gameOver){
            return;
        }
        isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        
        float direction = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed *direction,rb.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(direction));
        
        if(direction > 0){
            sprite.flipX = true;
        }else if (direction < 0){
            sprite.flipX = false;
        }

        if(Input.GetKey(KeyCode.Space) && isGrounded){
            rb.velocity = new Vector2(rb.velocity.x,jumpSpeed);
        }
        animator.SetFloat("JumpSpeed", rb.velocity.y);
        animator.SetBool("IsGrounded", isGrounded);
        if(Input.GetKey(KeyCode.P)){
            animator.SetBool("Pout", true);
        }else{
            animator.SetBool("Pout", false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(isBlinking){
            SpriteBlink();
        }
        if(Health <= 0){
            sprite.enabled = false;
            isBlinking = false;
            gameOver = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rb.velocity = Vector2.zero;
            Invoke("EndGame", 2.0f);
        }   
    }

    void EndGame(){
            SceneManager.LoadScene("GameOverScene");        
    }

    private void Recoil(){
        if(sprite.flipX){
            rb.position -= new Vector2(2f,0f);
        }else{
            rb.position += new Vector2(2f,0f);
        }
    }

    private void SpriteBlink(){
        blinkTimeCurrent += Time.deltaTime;
        blinkTimeCurrentmini += Time.deltaTime;
        if(blinkTimeCurrent > BLINKTIMETOTAL){
            isBlinking = false;
            sprite.enabled = true;
        }else{
            if(blinkTimeCurrentmini > BLINKDURATION){
                sprite.enabled = !sprite.enabled;
                blinkTimeCurrentmini = 0.0f;
            }
        }
    }



    void OnCollisionEnter2D(Collision2D col){

        if(col.gameObject.tag.Equals("Enemy") ){
            Health--;
            Recoil();
            isBlinking = true;
            blinkTimeCurrentmini = 0.0f;
            blinkTimeCurrent = 0.0f;
        }

    }
}
