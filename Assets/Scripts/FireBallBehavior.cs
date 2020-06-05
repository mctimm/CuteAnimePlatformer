using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sprite;
    void Awake(){
        rb = gameObject.GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        rb.velocity = transform.right * -8f;
        sprite.flipX = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(!col.gameObject.tag.Equals("EditorOnly") && !col.gameObject.tag.Equals("Player")){
            print(col.gameObject.tag);
            Destroy(gameObject);
        }
    }
}
