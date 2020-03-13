using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

    bool active = false;
    
    
    [SerializeField]
    GameObject enemy;
    int maxOfEnemies = 2;
    int numberOfEnemies =0;
    float summonTimeDelay = 4f;
    
    Animator anim;

    void Awake(){
        anim = gameObject.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Active",active);
        if(active && summonTimeDelay<=0 && numberOfEnemies<maxOfEnemies){
            SummonEnemy();
            summonTimeDelay = 2f;
            numberOfEnemies++;
        }
        if(summonTimeDelay>0){
            summonTimeDelay -= Time.deltaTime;
        }
    }

    void SummonEnemy(){
        Instantiate(enemy,transform.position,Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player") & !other.isTrigger){
            active=!active;
        }
    }
}
