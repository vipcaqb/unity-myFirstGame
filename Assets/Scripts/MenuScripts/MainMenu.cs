using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public void PlayGame(){
        Application.LoadLevel("GamePlay");
    }

    public void Settings(){
        Application.LoadLevel("Settings");
    }

    public void Exit(){
        Debug.Log("It's exit");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
