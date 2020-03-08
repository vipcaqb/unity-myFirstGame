using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public bool paused;
    GameObject PauseUI;

    // Start is called before the first frame update

    private void Awake() {
        PauseUI = GameObject.Find("PauseMenuUI");
        paused = false;
    }

    void Start()
    {
        PauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)){
            if(!paused){
                paused = true;
            }
            else{
                paused = false;
            }
        }

        PauseUI.SetActive(paused);
        if(paused){
            Time.timeScale = 0;
        }
        else{
            Time.timeScale = 1;
        }
        
    }

    public void ChangePause(){
        paused = !paused;
    }

}
