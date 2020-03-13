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
    public int maxHP= 1000;
    float minTimeGetDamage = 0.2f;
    

    bool canGetDamage = true;
    
    private void Awake() {
        currentHP = maxHP;
        canGetDamage = true;
    }

    void Start(){
        LoadData();
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

        if(Input.GetKeyDown(KeyCode.S)){
            GameData.dataUnit.Save(this);
            Debug.Log("Saved");
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

    void LoadData(){
        currentHP = GameData.dataUnit.currentHP;
        scores = GameData.dataUnit.scores;
    }

    
}
