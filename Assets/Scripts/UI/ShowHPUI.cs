using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHPUI : MonoBehaviour
{
    Status staPlayer;
    Text textHP;
    // Start is called before the first frame update
    private void Awake() {
        staPlayer = GameObject.Find("Player").GetComponent<Status>();
        textHP = gameObject.GetComponent<Text>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textHP.text= staPlayer.currentHP.ToString();
    }
}
