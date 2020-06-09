using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireBall : MonoBehaviour
{
    // Start is called before the first frame update
  
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
        if(!col.gameObject.tag.Equals("EditorOnly")){
            if(col.gameObject.tag.Equals("Enemy")){
                PlayerMovement player = col.gameObject.GetComponent<PlayerMovement>();
                if(player != null){
                    player.health--;
                }
            }
            print(col.gameObject.tag);
            Destroy(gameObject);
        }
    }
}
