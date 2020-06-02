using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallCast : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fireball;
    public Transform firePoint;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)){
            Shoot();
        }
    }

    void Shoot(){
        Instantiate(fireball, firePoint.position, Quaternion.identity);
    }

    
}
