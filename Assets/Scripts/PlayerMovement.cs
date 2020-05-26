using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    float speed = 0;
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
        rb.velocity = Vector2.right * speed;
        animator.SetFloat("Speed", Mathf.Abs(speed));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A)){
            speed = -5f;
            sprite.flipX = false;
        }else if(Input.GetKey(KeyCode.D)){
            speed = 5f;
            sprite.flipX = true;
        }else{
            speed = 0;
        }
        
    }
}
