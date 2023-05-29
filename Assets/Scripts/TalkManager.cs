using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class TalkManager : MonoBehaviour
{
    /* 캐릭터 표정 Sprite */
    public Sprite player1;
    public Sprite player2;
    public Sprite player3;
    public Sprite player4;
    public Sprite player5;
    public Sprite player6;
    public Sprite player7;
    public Sprite player8;
    public Sprite player9;
    public Sprite player10;
    public Sprite player11;
    public Sprite player12;
    public Sprite player13;
    public Sprite player14;
    public Sprite player15;
    public Sprite player16;

    public Sprite ghost1;
    public Sprite ghost2;
    public Sprite ghost3;
    public Sprite ghost4;
    public Sprite ghost5;
    public Sprite ghost6;
    public Sprite ghost7;
    public Sprite ghost8;
    public Sprite ghost9;
    public Sprite ghost10;
    public Sprite ghost11;
    public Sprite ghost12;
    public Sprite ghost13;
    public Sprite ghost14;
    public Sprite ghost15;

    public Sprite ribbon1;
    public Sprite ribbon2;
    public Sprite ribbon3;
    public Sprite ribbon4;
    public Sprite ribbon5;

    public Sprite cap1;
    public Sprite cap2;
    public Sprite cap3;
    public Sprite cap4;
    public Sprite cap5;
    public Sprite cap6;
    public Sprite cap7;
    public Sprite cap8;

    public Sprite glass1;
    public Sprite glass2;
    public Sprite glass3;
    public Sprite glass4;
    public Sprite glass5;
    public Sprite glass6;
    public Sprite glass7;

    public Sprite Reaper1;
    public Sprite Reaper2;

    /* 대사 다이얼로그 저장 JSON파일 */
    JObject jObject;

    void Awake()
    {
        /* JSON파일 읽어오기*/
        var jsonTextFile = Resources.Load<TextAsset>("Dialog_WithGhost");        
        string data = jsonTextFile.ToString();        

        jObject = JObject.Parse(data);
    }    

    /* 다이얼로그 ID에 맞춰 대사 진행 */
    public string GetTalk(int id, int talkIndex)
    {        
        JArray items = (JArray)jObject["Dialog"][SaveMemory.Id-1]["Chat"];
        if (items.Count <= SaveMemory.talkIndex)
        {            
            return null;
        }
        else
        {
            return jObject["Dialog"][id-1]["Chat"][talkIndex]["talkData"].ToString();
        }
    }

    public Sprite GetImage(int id, int talkIndex)
    {
        JArray items = (JArray)jObject["Dialog"][SaveMemory.Id-1]["Chat"];
        if (items.Count <= SaveMemory.talkIndex)
        {            
            return null;
        }

        /* JSON으로 받은 변수이름의 Sprite를 반환 */
        string ImageName = jObject["Dialog"][id-1]["Chat"][talkIndex]["ImageData"].ToString();
        System.Type type = GetType();
        FieldInfo info = type.GetField(ImageName);
        if (ImageName == null || ImageName == "")
        {
            return null;
        }
        else
        {
            return (Sprite)info.GetValue(this);
        }
    }
}
