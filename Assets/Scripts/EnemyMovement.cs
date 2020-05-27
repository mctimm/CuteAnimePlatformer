using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    float totalMovement = 0.0f;
    float MOVEMENTCAP = 10.0f;
    int direction = 0;
    float speed = 3f;

    Rigidbody2D rb;

    void Awake(){
        rb = gameObject.GetComponent<Rigidbody2D>();
    } 
    void Start()
    {
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        if(totalMovement > MOVEMENTCAP){
            direction = -direction;
            totalMovement = 0.0f;
        }
        totalMovement = Mathf.Abs(Time.deltaTime * rb.velocity.x) ;
        rb.velocity = new Vector2(direction * speed, 0f);
    }
}
