using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    bool isGrounded = true;
    bool flipped = false;
    bool invincible = false;
    float currentDirection;

    bool gameOver = false;

    public int health = 5;
    public int SpellsLeft = 5;
    bool Spellcasted;

    float BLINKTIMETOTAL = 3.0f;
    float BLINKDURATION = 0.2f;
    float blinkTimeCurrent = 0.0f;
    float blinkTimeCurrentmini = 0.0f;

    bool isBlinking;


    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    Transform groundCheckL;
    [SerializeField]
    Transform groundCheckR;
    float speed = 6f;
    float walkSpeed  = 4f;
    float runSpeed = 6f;
    float accel = 4f;
    float slowDown = 2f;
    float jumpSpeed = 8f;
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
        currentDirection = -1;
    }

    void FixedUpdate(){
        //float direction = Input.GetAxis("Horizontal");
        if(gameOver){
            return;
        }
        isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        isGrounded |= Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Ground"));
        isGrounded |= Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Ground"));
        //print(LayerMask.NameToLayer("Ground"));
        //print(isGrounded);

        float direction = Input.GetAxis("Horizontal");
        float currentAccel = accel *direction;
        
        if(Input.GetKey(KeyCode.L)){
            speed = runSpeed;
        }else{
            speed = walkSpeed;
        }

        animator.SetFloat("Speed", Mathf.Abs(direction));
        
        if(!(currentDirection * direction >= 0)){
            Flip();
            currentDirection = direction;
        }

        

        
        animator.SetFloat("JumpSpeed", rb.velocity.y);
        animator.SetBool("IsGrounded", isGrounded);
        float absSpeed = Mathf.Abs(rb.velocity.x);

        if(rb.velocity.y < 0 || !Input.GetKey(KeyCode.Space)){
            rb.gravityScale = 2;
        }else {
            rb.gravityScale = 1;
        }
        
        if(!isGrounded)
        {
            currentAccel /= 8;
        }
        else {
            if(absSpeed < slowDown){
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            else if(rb.velocity.x > 0){
                rb.velocity = new Vector2(rb.velocity.x - slowDown, rb.velocity.y);
            }else if (rb.velocity.x < 0){
                rb.velocity = new Vector2(rb.velocity.x + slowDown, rb.velocity.y);
            }
        }
        rb.velocity = new Vector2(rb.velocity.x + currentAccel, rb.velocity.y);
        
        absSpeed = Mathf.Abs(rb.velocity.x);
        print("before check: " + (absSpeed >= speed));
        if(absSpeed >= speed){
            if(rb.velocity.x > 0){
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }else{
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }

        print("After check: " + rb.velocity);
        

    }

    void Flip(){
        transform.Rotate(0f,180f, 0f);
        flipped = !flipped;
    }

    // Update is called once per frame
    void Update()
    {
        if(isBlinking){
            SpriteBlink();
        }
        if(health <= 0){
            sprite.enabled = false;
            isBlinking = false;
            gameOver = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rb.velocity = Vector2.zero;
            Invoke("EndGame", 2.0f);
        }
           if(Input.GetKeyDown(KeyCode.K) && SpellsLeft > 0){
            animator.SetBool("SpellCasting", true);
            Spellcasted = true;
            print(SpellsLeft);
            animator.SetBool("Pout", false);
        }else if(Input.GetKey(KeyCode.P)){
            animator.SetBool("Pout", true);
            animator.SetBool("SpellCasting", false);
        }else{
            animator.SetBool("Pout", false);
            animator.SetBool("SpellCasting", false);
        }

        if(Input.GetKey(KeyCode.Space) && isGrounded){
            rb.velocity = new Vector2(rb.velocity.x,jumpSpeed);
        }
    }

    void LateUpdate(){
        if(Spellcasted) SpellsLeft--;
        Spellcasted = false;
    }

    void EndGame(){
            SceneManager.LoadScene("GameOverScene");        
    }

    private void Recoil(){
        
        if(flipped){
            rb.position -= new Vector2(2f,0f);
        }else{
            rb.position += new Vector2(2f,0f);
        }
    }

    private void SpriteBlink(){
        blinkTimeCurrent += Time.deltaTime;
        blinkTimeCurrentmini += Time.deltaTime;
        if(blinkTimeCurrent > BLINKTIMETOTAL){
            isBlinking = false;
            sprite.enabled = true;
            invincible = false;
        }else{
            if(blinkTimeCurrentmini > BLINKDURATION){
                sprite.enabled = !sprite.enabled;
                blinkTimeCurrentmini = 0.0f;
            }
        }
    }

    public void takeDamage(){
        if(invincible){
            return;
        }
        health--;
        Recoil();
        isBlinking = true;
        blinkTimeCurrentmini = 0.0f;
        blinkTimeCurrent = 0.0f;
        invincible = true;
    }

    void OnCollisionEnter2D(Collision2D col){

        if(col.gameObject.tag.Equals("Enemy") && !invincible ){
            takeDamage();
        }

        if(col.gameObject.tag.Equals("KillZone")){
            health = 0;
        }

    }
}
