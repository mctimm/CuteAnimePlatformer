using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject weapon;
    

    void OnTriggerEnter2D(Collider2D col){
        print(col.gameObject.tag);
        if(col.gameObject.tag.Equals("Player")){
            col.gameObject.GetComponent<FireBallCast>().ChangeWeapon(weapon);
            col.gameObject.GetComponent<PlayerMovement>().SpellsLeft = 5;
            Destroy(gameObject);
        }
    }
}
