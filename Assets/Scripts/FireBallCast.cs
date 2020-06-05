using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallCast : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerMovement player;
    public GameObject fireball;
    public Transform firePoint;

    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K) && player.SpellsLeft > 0){
            Shoot();
            //Invoke("Shoot", 0f);
        }
    }

    void Shoot(){
        Instantiate(fireball, firePoint.position, firePoint.rotation);
    }

    
}
