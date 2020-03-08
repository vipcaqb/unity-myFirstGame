using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScoresUI : MonoBehaviour
{

    Status sta;
    Text txt;
    // Start is called before the first frame update
    void Start()
    {
        sta = GameObject.Find("Player").GetComponent<Status>();
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = sta.scores.ToString();
    }
}
