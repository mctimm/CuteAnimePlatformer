using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBehavior : EnemyBasics
{
    // Start is called before the first frame update
    Animator animator;
    bool dead = false;

    public GameObject fireBall;

    public Transform firePoint;

    float timeCurrent;

    bool casting = false;
    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isCasting", casting);
        casting = false;
        timeCurrent += Time.deltaTime;
        if(timeCurrent > 5){
            Cast();
            timeCurrent = 0;
        }
    }

    void Cast(){
        casting = true;
        Invoke("InstantiateFire", 0.5f);
    }

    private void InstantiateFire(){
        Instantiate(fireBall, firePoint.position, firePoint.rotation);
    }


    public override void Death(){
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        animator.SetBool("Dead", true);
        Destroy(gameObject, 0.5f);
        dead = true;
    }
}
