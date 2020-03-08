using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformScript : MonoBehaviour
{
    [SerializeField]
    float speed = 0.2f;

    float deltaPlayerPlatform;
    float right = 1;
    Vector3 temp;

    PauseMenu pMenu;

    // Start is called before the first frame update
    void Start()
    {
        temp = transform.position;
        pMenu = GameObject.Find("Main Camera").GetComponentInParent<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!pMenu.paused){
            temp.x +=speed*right;
            transform.position = temp;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Ground")){
            right*=-1;
        }
    }
    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.name=="Player"){
            Vector3 tempPosition = other.gameObject.transform.position;
            tempPosition.x += speed*right;
            other.gameObject.transform.position=tempPosition;
        }
    }
}
