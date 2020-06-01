using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public Transform enemyPosition;
    BoxCollider2D hitbox;

    void Awake(){
        hitbox = gameObject.GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D col){
        if(col.gameObject.tag.Equals("Player")){
            Instantiate(enemy, enemyPosition.position, Quaternion.identity);
            hitbox.enabled = false;

        }
    }
}
