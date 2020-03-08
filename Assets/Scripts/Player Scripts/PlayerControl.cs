using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    [SerializeField]
    float speed = 10f, maxSpeed = 1.5f, jumpPow = 150f;
    bool grounded = true;
    bool faceRight = true;
    public bool moveRight= false,moveLeft= false;

    Rigidbody2D r2; 
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update(){
        anim.SetBool("Grounded",grounded);
        anim.SetFloat("Speed",Mathf.Abs(r2.velocity.x));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space) &&  grounded){
            grounded = false;
            r2.AddForce((Vector2.up)*jumpPow);
        }

        r2.AddForce((Vector2.right) * speed * h);

        if(r2.velocity.x > maxSpeed){
            r2.velocity = new Vector2(maxSpeed,r2.velocity.y);
        }
        if(r2.velocity.x < -maxSpeed){
            r2.velocity = new Vector2(-maxSpeed,r2.velocity.y);
        }

        //moving by joystick
        if(moveLeft){
            if(faceRight) Flip();
            MoveLeft();
            
        }
        if(moveRight){
            if(!faceRight) Flip();
            MoveRight();
        }

        if(h > 0 && !faceRight){
            Flip();
        }
        if(h<0 && faceRight){
            Flip();
        }

        if(grounded){
            r2.velocity = new Vector2(r2.velocity.x*0.6f,r2.velocity.y);
        }
        else r2.velocity = new Vector2(r2.velocity.x*0.7f,r2.velocity.y);
    }

    void Flip(){
        faceRight = !faceRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale= scale;
    }

    public void MoveLeft(){
        r2.AddForce((Vector2.right) * speed * (-1));
    }

    public void MoveRight(){
        r2.AddForce((Vector2.right) * speed );
    }

    public void Jump(){
        if( grounded){
            grounded = false;
            r2.AddForce((Vector2.up)*jumpPow);
        }
    }

    public void KnockBack(){
        r2.AddForce(new Vector2(-100f,30f));
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Ground")){
            grounded = true;
        }
        if(other.gameObject.CompareTag("Enemy")){
            Debug.Log("Kill enemy");
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Ground")){
            grounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Ground")){
            grounded = false;
        }
    }
}
