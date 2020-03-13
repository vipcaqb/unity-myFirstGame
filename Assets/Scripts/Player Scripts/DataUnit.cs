using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class DataUnit
{
    public int currentHP;
    public int scores; 

    public string DATA_KEY = "unitdata";

    public DataUnit(){
        currentHP = 100;
        scores = 0;
    }

    public void Save(Status sta){
        currentHP = sta.currentHP;
        scores = sta.scores;

        string s = JsonConvert.SerializeObject(this);

        PlayerPrefs.SetString(DATA_KEY,s);
    }
}
