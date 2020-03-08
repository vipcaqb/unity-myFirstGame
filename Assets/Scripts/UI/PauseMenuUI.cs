using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{

    PauseMenu pMenu;

    // Start is called before the first frame update
    void Start()
    {
        pMenu = GameObject.Find("Main Camera").GetComponentInParent<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resume(){
        pMenu.paused = false;
        Debug.Log("Resume");
    }

    public void Restart(){
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        pMenu.paused = false;
    }
    public void Exit(){
        pMenu.paused = false;
        Application.LoadLevel("MainMenu");
    }
}
