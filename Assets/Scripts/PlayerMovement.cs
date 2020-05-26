﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    float speed = 5f;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        animator.SetFloat("Speed", Mathf.Abs(speed));
        transform.position += new Vector3(speed *Input.GetAxis("Horizontal"),0f,0f) * Time.deltaTime;
        
    }
}
