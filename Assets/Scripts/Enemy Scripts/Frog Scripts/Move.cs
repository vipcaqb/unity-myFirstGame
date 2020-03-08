using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    

    public float jumpPow = 160f, moveForce = 10f;
    bool grounded = false;
    bool isRight = false;
    public float timeDelay = 2f;
    public float playerDistance;
    public float findPlayerIn = 1.8f;

    Rigidbody2D body;
    Animator anim;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        body = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");

        StartCoroutine(Jump());
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded",grounded);
        
    }

    void FixedUpdate() {
        
    }

    void MoveBody(){
        if(grounded ){
            float bodyX = body.position.x;
            float playerX = player.transform.position.x;
            playerDistance = Mathf.Abs(bodyX-playerX);

            if(playerDistance<findPlayerIn){
                if(bodyX > playerX){
                    if(isRight) Flip(); 
                    body.AddForce(new Vector2(-moveForce,jumpPow));
                }
                else {
                    if(!isRight) Flip();
                    body.AddForce(new Vector2(moveForce,jumpPow));
                }
            }

            StartCoroutine(Jump());
        }
    }

    IEnumerator Jump(){
        yield return new WaitForSeconds(timeDelay);
        MoveBody();
        yield return 0;
    } 

    void Flip(){
        isRight=!isRight;
        Vector3 Scale = transform.localScale;
        Scale.x *=-1;
        transform.localScale = Scale;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        grounded = true;
    }

    private void OnTriggerStay2D(Collider2D other) {
        grounded = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        grounded = false;
    }
}
