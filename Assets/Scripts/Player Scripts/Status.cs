using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Status : MonoBehaviour
{

    EnemyHit enemyHit;

    [SerializeField]
    public int scores = 0;
    public int currentHP;
    int maxHP= 10;
    float minTimeGetDamage = 0.2f;
    

    bool canGetDamage = true;
    
    
    private void Awake() {
        currentHP = maxHP;
        canGetDamage = true;
    }

    void Start(){
        enemyHit = gameObject.GetComponent<EnemyHit>();
    }

    private void Update() {

        //Dead condition
        if(currentHP <= 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(minTimeGetDamage >0)
            minTimeGetDamage-=Time.deltaTime;
        else {
            canGetDamage = true;
            enemyHit.damaged = false;
        }
    }

    public int GetCurrentHP(){
        return currentHP;
    }

    public void damaged(int damage){
        if(canGetDamage){
            canGetDamage = false;
            minTimeGetDamage = 0.3f;
            currentHP -= damage;
            enemyHit.damaged = true;
        }
    }
}
