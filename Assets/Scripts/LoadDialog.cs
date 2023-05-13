using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class LoadDialog : MonoBehaviour
{    
    void Start()
    {        
        string filePath = Application.dataPath + "/DialogData/Dialog_WithGhost.json";
        string data = System.IO.File.ReadAllText(filePath);

        JObject jObject = JObject.Parse(data);
        Debug.Log(jObject["Dialog"][1]["Chat"][1]["talkData"]);
                   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
