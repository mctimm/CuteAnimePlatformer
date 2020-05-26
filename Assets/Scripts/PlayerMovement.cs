using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    float speed = 5f;
    float jumpSpeed;
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
        float direction = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed *direction,0f);
        if(Input.GetKeyDown("Space")){
            rb.velocity = new Vector2(rb.velocity.x,jumpSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        
        animator.SetFloat("Speed", Mathf.Abs(direction));
        
        if(direction > 0){
            sprite.flipX = true;
        }else if (direction < 0){
            sprite.flipX = false;
        }
        
    }
}
