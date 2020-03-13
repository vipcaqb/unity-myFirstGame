using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    float tempSpeed;

    [SerializeField]
    float speed = 10f, maxSpeed = 1.5f, jumpPow = 150f;
    bool grounded = true;
    bool faceRight = true;
    int shadowRight = 1;
    bool shadowExisting = false;
    float shadowCountdown = 0f;
    float shadowExistTime = 1f;
    public bool moveRight= false,moveLeft= false;
    
    public GameObject shadow;
    public GameObject shadowSummoned;
    public Rigidbody2D r2Shadow;
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

        if(Input.GetKeyDown(KeyCode.X) && shadowCountdown <=0){
            shadowRight = (faceRight)?1:-1;
            shadowExisting = true;

            //Make player fall and move slowly
            r2.gravityScale = 0.01f;
            r2.velocity = Vector2.zero;
            tempSpeed = speed;
            speed /=10;

            Shadow();
            shadowCountdown = 2f;
        }

        if(shadowCountdown > 0 ){
            shadowCountdown-= Time.deltaTime;
        }

        // if(shadowExisting){
        //     r2Shadow.velocity = Vector3.right;
        // }

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

    public void SummonShadow(){
        if(shadowCountdown <=0f){
            shadowRight = (faceRight)?1:-1;
            shadowExisting = true;

            //Make player fall and move slowly
            r2.gravityScale = 0.01f;
            r2.velocity = Vector2.zero;
            tempSpeed = speed;
            speed /=10;

            Shadow();
            shadowCountdown = 2f;
        }
    }

    void BeforeDestroyShadow(){
        gameObject.transform.position = shadowSummoned.transform.position;
    }

    void AfterDestroyShadow(){
        shadowExisting = false;
        r2.gravityScale = 0.6f;
        speed = tempSpeed;
    }

    void Shadow(){
        Instantiate(shadow,transform.position,Quaternion.identity);
        shadowSummoned = GameObject.Find("Shadow(Clone)");
        shadowSummoned.transform.localScale = new Vector2(shadowRight,shadow.transform.localScale.y);
        r2Shadow = GameObject.Find("Shadow(Clone)").GetComponent<Rigidbody2D>();
        r2Shadow.gravityScale = 0f;
        r2Shadow.velocity = Vector3.right*shadowRight;
        StartCoroutine(MovePlayerTo());
    
    }

    IEnumerator MovePlayerTo(){
        yield return new WaitForSeconds(shadowExistTime);
        BeforeDestroyShadow();
        Destroy(shadowSummoned);
        AfterDestroyShadow();
        yield return 0; 
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
