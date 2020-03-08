using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField]
    float timeDelay = 2.0f;

    Rigidbody2D body ;
    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){

    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
            StartCoroutine(Fall());
        }
        if(other.gameObject.CompareTag("Ground")){
            Destroy(gameObject);
        }
    }

    IEnumerator Fall(){
        yield return new WaitForSeconds(timeDelay);
        body.bodyType = RigidbodyType2D.Dynamic;
        yield return 0;
    }
}
