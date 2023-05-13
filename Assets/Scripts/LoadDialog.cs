using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDialog : MonoBehaviour
{
    //[System.Serializable]
    //public class ChatData
    //{
    //    public int talkIndex;
    //    public string ImageData;
    //    public string talkData;
    //}

    //[System.Serializable]
    //public class IdData
    //{
    //    public int ID;        

    //    public List<ChatData> Chat = new List<ChatData>();
    //    public Dictionary<int, ChatData> MakeDict() // 오버라이딩
    //    {
    //        Dictionary<int, ChatData> dict = new Dictionary<int, ChatData>();
    //        foreach (ChatData dChat in Chat)
    //            dict.Add(dChat.talkIndex, dChat);
    //        return dict;
    //    }
    //}

    //public class DiaLogdData
    //{
    //    public List<IdData> Dialog = new List<IdData>();
    //    public Dictionary<int, IdData> MakeDict() // 오버라이딩
    //    {
    //        Dictionary<int, IdData> dict = new Dictionary<int, IdData>();
    //        foreach (IdData dlog in Dialog) 
    //            dict.Add(dlog.ID, dlog); 
    //        return dict;
    //    }
    //}
    // Start is called before the first frame update
    void Start()
    {
        //List<Chat> dialogList;
        string filePath = Application.dataPath + "/DialogData/StudyJson.json";
        string data = System.IO.File.ReadAllText(filePath);

       
        
                   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
