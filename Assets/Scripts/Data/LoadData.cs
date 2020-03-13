using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class LoadData : MonoBehaviour
{
    // Start is called before the first frame update

    public string nextScene = "GamePlay";

    private string KEY_DATA = "unitdata";

    void Awake(){
        LoadUnitData();

        SceneManager.LoadScene(nextScene);
    }

    void LoadUnitData(){
        string s = PlayerPrefs.GetString(KEY_DATA);

        if(string.IsNullOrEmpty(s)){
            GameData.dataUnit = new DataUnit();
            return;
        }

        GameData.dataUnit = JsonConvert.DeserializeObject<DataUnit>(s);
    }

}
