using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    float speed = 0.2f;

    float right = 1;
    Vector3 temp;
    // Start is called before the first frame update
    void Start()
    {
        temp = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        temp.x +=speed*right;
        transform.position=temp;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Ground")){
            right*=-1;
        }
    }
}
