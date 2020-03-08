using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarnItems : MonoBehaviour
{

    Status sta;
    int gemValue = 200;

    // Start is called before the first frame update

    void Start()
    {
        sta = GameObject.Find("Player").GetComponent<Status>();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Collecable"){
            sta.scores +=gemValue;
            Destroy(other.gameObject);
        }
    }
}
