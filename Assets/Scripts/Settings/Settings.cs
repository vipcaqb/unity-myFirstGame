using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{



    public void Back(){
        Application.LoadLevel("MainMenu");
    }

    public void MakeGameBeauty(){
        Destroy(GameObject.Find("cuong"));
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
