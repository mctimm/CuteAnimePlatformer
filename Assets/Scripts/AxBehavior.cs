using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;

    void Awake(){
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Vector2 fortyfive = transform.right * -7f;
        fortyfive.y = 7f;
        rb.velocity = fortyfive;
    }

    // void Update(){
    //     print(rb.velocity);
    //     }
       void OnTriggerEnter2D(Collider2D col){
        if(!col.gameObject.tag.Equals("EditorOnly") && !col.gameObject.tag.Equals("Player")){
            if(col.gameObject.tag.Equals("Enemy")){
                GhoulMovement enemy = col.gameObject.GetComponent<GhoulMovement>();
                if(enemy != null){
                    enemy.Death();
                }
            }
            print(col.gameObject.tag);
            Destroy(gameObject);
        }
    }
}
