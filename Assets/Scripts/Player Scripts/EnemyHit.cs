using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public float jetForce = 30f;
    public bool damaged = false;

    Rigidbody2D body ;
    Status status;
    Animator anim;
    PlayerControl pControl;
    // Start is called before the first frame update
    void Awake(){
        pControl = gameObject.GetComponent<PlayerControl>();
    }

    void Start()
    {
        body= gameObject.GetComponent<Rigidbody2D>();
        status = gameObject.GetComponent<Status>();
        anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Damaged",damaged);
    }
    
    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.CompareTag("Enemy")){
            pControl.KnockBack();
            status.damaged(2);
        }
    }

}
