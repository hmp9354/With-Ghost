using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class EventManager : MonoBehaviour
{
    /* 아이템 조사 Sprite */
    public GameObject scanObject;
    public Image past;         // 빙의 그림    

    public Sprite roomDoor;
    public Sprite coffee;
    public Sprite memo;
    public Sprite piano1;       // 피아노 옆에 새가 있음
    public Sprite piano2;       // 피아노 위에 새가 있음
    public Sprite piano3;       // 피아노 안에 새가 있음
    public Sprite birdCage;
    public Sprite eraserShooting;
    public Sprite windowCracked;
    public Sprite eraserUp;
    public Sprite eraserDown;
    public Sprite picture;
    public Sprite album1;
    public Sprite album2;
    public Sprite album3;


    /* NPC */
    public GameObject player;
    public GameObject Ghost;
    public GameObject GhostRibbon;
    public GameObject GhostGlasses;
    public GameObject GhostCap;
    public GameObject Reaper;

    public GameObject GhostFace;
    public GameObject flower;
    public GameObject flowerSmile;
    public GameObject flowerSad;


    /* 캐릭터 이동 관련 변수*/
    GameObject moveObject;
    GameObject moveObject2;

    bool moveGhostUp = false;
    bool moveGhostDown = false;
    bool moveGhostRight = false;
    bool moveGhostLeft = false;

    // 이동해야 하는 좌표 및 이동 속도
    float y;
    float x;
    float speed;


    /* 대화창 */
    Sprite ImageData;
    JObject jObject;

    public TalkManager Tmanager;

    GameObject talkUI;
    public GameObject talkUIUP;
    public GameObject talkUIDown;

    Text talkText;
    public Text talkTextUp;
    public Text talkTextDown;

    Image talkImage;
    public Image talkImageUp;
    public Image talkImageDown;

    // 선택창
    public GameObject select;
    public GameObject selectBox1;
    public GameObject selectBox2;
    public GameObject selectText1;
    public GameObject selectText2;
    bool selected = false;


    /* 이벤트 분기 */
    bool sawPiano = false;
    bool ribbon = false;
    bool ImageControll = false;
    bool black = false;


    /* 엔딩 관련 변수 */
    public SaveMemory SM;
    public GameObject Black;
    public GameObject Ending;


    /* scanObj에 따른 대사 및 행동*/
    public void Action(GameObject scanObj)
    {
        if (!SaveMemory.talking && !SaveMemory.showing)
        {
            if (scanObj.name == "fakeDoor")
            {
                SaveMemory.talking = true;
                SaveMemory.talkIndex = 0;
                SaveMemory.Id = 5;
                Talk(5);
            }

            if (scanObj.name == "realDoor" || (scanObj.name == "Ghost"))
            {
                SaveMemory.talking = true;
                SaveMemory.talkIndex = 0;
                SaveMemory.Id = 6;
                Talk(6);
            }

            if (scanObj.name == "roomDoor")
            {
                SaveMemory.talking = true;
                SaveMemory.talkIndex = 0;
                if (SaveMemory.roomDoor == 0)
                {
                    SaveMemory.Id = 8;
                    SaveMemory.roomDoor = 1;
                }
                else if (SaveMemory.roomDoor == 1)
                {
                    SaveMemory.Id = 11;
                }
                else if (SaveMemory.roomDoor == 2)
                {
                    SaveMemory.roomDoor = 3;
                    GameObject.Find("roomDoor").SetActive(false);
                    SaveMemory.Id = 13;
                }
                Talk(SaveMemory.Id);
            }

            if (scanObj.name == "pen" && SaveMemory.roomDoor == 1)
            {
                SaveMemory.talking = true;
                SaveMemory.talkIndex = 0;
                SaveMemory.Id = 12;
                SaveMemory.roomDoor = 2;
                scanObj.SetActive(false);
                Talk(12);
            }

            if (scanObj.name == "HouseDoor")
            {
                SaveMemory.talking = true;
                SaveMemory.talkIndex = 0;
                if (SaveMemory.findKey == 0)
                {
                    SaveMemory.Id = 14;
                    SaveMemory.findKey++;
                }
                else if (SaveMemory.findKey >= 6)
                {
                    SaveMemory.Id = 21;
                }
                else
                {
                    SaveMemory.Id = 15;
                }
                Talk(SaveMemory.Id);
            }

            if (scanObj.name == "coffee")
            {
                SaveMemory.talkIndex = 0;
                if (SaveMemory.findKey >= 1)
                {
                    SaveMemory.Id = 16;
                    past.sprite = coffee;
                    showImage();
                    if (SaveMemory.findKey == 1) { SaveMemory.findKey++; }
                }
            }

            if (scanObj.name == "memo")
            {
                SaveMemory.talkIndex = 0;
                if (SaveMemory.findKey >= 2)
                {
                    SaveMemory.Id = 17;
                    past.sprite = memo;
                    showImage();
                    if (SaveMemory.findKey == 2) { SaveMemory.findKey++; }
                }
            }

            if (scanObj.name == "Piano")
            {
                SaveMemory.talkIndex = 0;
                if (SaveMemory.findKey >= 5)
                {
                    SaveMemory.Id = 20;
                    past.sprite = piano2;
                    showImage();
                    if (SaveMemory.findKey == 5) { SaveMemory.findKey++; }
                }
                else if (SaveMemory.findKey >= 3 && SaveMemory.findKey < 5)
                {
                    SaveMemory.Id = 18;
                    past.sprite = piano1;
                    showImage();
                    if (SaveMemory.findKey == 3) { SaveMemory.findKey++; }
                }
            }

            if (scanObj.name == "birdCage")
            {
                SaveMemory.talkIndex = 0;
                if (SaveMemory.findKey >= 4)
                {
                    SaveMemory.Id = 19;
                    past.sprite = birdCage;
                    showImage();
                    if (SaveMemory.findKey == 4) { SaveMemory.findKey++; }
                }
            }

            if (scanObj.name == "windowCracked")
            {
                SaveMemory.talkIndex = 0;

                if (!SaveMemory.lookWindow)
                {
                    SaveMemory.Id = 24;
                    SaveMemory.lookWindow = true;
                }
                else if (!SaveMemory.findEraserUp)
                {
                    SaveMemory.Id = 26;
                    SaveMemory.findEraser++;
                    SaveMemory.findEraserUp = true;
                }
                Talk(SaveMemory.Id);
            }

            if (scanObj.name == "hideEraser")
            {
                SaveMemory.talkIndex = 0;

                if (!SaveMemory.findEraserDown)
                {
                    SaveMemory.Id = 29;
                    Talk(SaveMemory.Id);
                    SaveMemory.findEraserDown = true;
                }
            }

            if (scanObj.name == "GhostRibbon")
            {
                SaveMemory.talkIndex = 0;

                if (SaveMemory.RibbonGB)
                {
                    SaveMemory.Id = 33;
                }
                else if (SaveMemory.findEraserDown && SaveMemory.findEraserUp)
                {
                    SaveMemory.Id = 32;
                    SaveMemory.RibbonGB = true;
                }
                else
                {
                    SaveMemory.Id = 34;
                }
                Talk(SaveMemory.Id);
            }

            if (scanObj.name == "missingBook")                                       // 책갈피 발견
            {
                if (!SaveMemory.findBook)
                {
                    SaveMemory.talkIndex = 0;
                    SaveMemory.Id = 44;
                    SaveMemory.findBook = true;
                    Talk(SaveMemory.Id);
                }
            }

            if (scanObj.name == "missingMemory")                                   // 단체사진 조사
            {
                if (!SaveMemory.findPicture)
                {
                    SaveMemory.talkIndex = 0;
                    SaveMemory.Id = 45;
                    SaveMemory.findPicture = true;
                    Talk(SaveMemory.Id);
                }
            }

            if (scanObj.name == "flowerSmile")
            {
                flowerSmile.SetActive(false);
                SaveMemory.badEnding = true;
            }

            if (scanObj.name == "hellDoor")
            {
                SaveMemory.talkIndex = 0;
                SaveMemory.talking = true;
                if (SaveMemory.badEnding)
                {
                    player.SetActive(false);
                    flowerSad.SetActive(true);

                    SaveMemory.Id = 49;
                }
                if (SaveMemory.halfHappy)
                {
                    SaveMemory.Id = 61;
                }
                Talk(SaveMemory.Id);
            }

            if (scanObj.name == "reaper")
            {
                if (SaveMemory.trueEnding)
                {
                    SaveMemory.Id = 62;
                }
                else if (SaveMemory.halfHappy)
                {
                    SaveMemory.Id = 60;
                }
                SaveMemory.talking = true;
                SaveMemory.talkIndex = 0;
                Talk(SaveMemory.Id);
            }
        }
    }

    void Talk(int id)
    {        
        string talkData = Tmanager.GetTalk(id, SaveMemory.talkIndex);
        Sprite ImageData = Tmanager.GetImage(id, SaveMemory.talkIndex);

        /* 플레이어 위치에 따라 대화창의 위치 결정 */
        if (player.transform.position.y > -1.6)
        {
            talkUI = talkUIUP;
            talkText = talkTextUp;
            talkImage = talkImageUp;
        }
        else
        {
            talkUI = talkUIDown;
            talkText = talkTextDown;
            talkImage = talkImageDown;
        }

        talkUI.SetActive(true);

        Debug.Log("Tal함수 실행, Talk의 id"+id);
        Debug.Log("Tal함수 실행, Talk의 indx" + SaveMemory.talkIndex);

        /* 대화 종료 후 이벤트 발생 */
        if (talkData == null)
        {
            id = SaveMemory.Id;
            Debug.Log(SaveMemory.Id);
            Debug.Log(id);
            SaveMemory.talking = false;

            talkUI.SetActive(false);
            talkUIDown.SetActive(false);
            SaveMemory.talkIndex = 0;
            if (id == 1)                     // 주인공 일어나게 하기
            {
                player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                SaveMemory.Id++;
                SaveMemory.gameStart = true;
            }
            else if (id == 2)                    // 귀신이 바위에 빙의
            {
                Ghost.SetActive(false);
                GhostFace.SetActive(true);
                SaveMemory.talking = true;
                SaveMemory.talkIndex = 0;
                Talk(3);
                SaveMemory.Id++;
            }
            else if (id == 3)                     // 귀신이 바위에서 나옴
            {
                Ghost.SetActive(true);
                GhostFace.SetActive(false);
                SaveMemory.talking = true;
                SaveMemory.talkIndex = 0;
                Talk(4);
                SaveMemory.Id++;
            }
            else if (id == 4)                        // 귀신이 진짜 문을 알려줌
            {
                Ghost.transform.position = new Vector3(2, 1, 0);
            }

            // 집 입장
            else if (id == 6)
            {
                Ghost.SetActive(false);
                SaveMemory.talking = true;
                SaveMemory.talkIndex = 0;
                SaveMemory.enterHouse = true;
                SceneManager.LoadScene("House");

            }
            // 귀신이 방을 나감
            else if (id == 7)
            {
                speed = 0.02f;
                y = 0.8f;
                moveObject = Ghost;
                moveGhostUp = true;
            }
            else if (id == 8)                // 주인공이 문을 열지 못해서 귀신이 문 여는 것을 시도함.
            {
                speed = 0.02f;
                moveObject = Ghost;
                moveGhostRight = true;
                x = -2.3f;
                moveGhostDown = true;
                y = 0;
            }
            else if (id == 9)                // 귀신이 문고리에 빙의
            {
                SaveMemory.Id = 10;
                past.sprite = roomDoor;
                showImage();
            }
            else if (id == 21)
            {
                SaveMemory.talking = true;
                SaveMemory.talkIndex = 0;
                SaveMemory.enterSchool1 = true;
                SceneManager.LoadScene("School1");
            }
            else if (SaveMemory.Id == 22)
            {
                speed = 0.1f;
                moveObject = GhostRibbon;
                moveGhostDown = true;
                y = -1.3f;
                ribbon = true;
            }
            else if (SaveMemory.Id == 23)
            {
                speed = 0.1f;
                moveObject = GhostRibbon;
                moveGhostDown = true;
                moveGhostRight = true;
                x = 4f;
                y = -3f;
            }
            else if (SaveMemory.Id == 24)
            {
                SaveMemory.Id = 25;
                past.sprite = eraserShooting;     // 지우개가 튕겨나가는 모습
                showImage();
            }
            else if (SaveMemory.Id == 26)
            {
                SaveMemory.Id = 27;
                past.sprite = eraserUp;     // 햄버거 모양 지우개 모습
                showImage();
            }
            else if (SaveMemory.Id == 27)
            {
                SaveMemory.talking = true;
                if (!SaveMemory.findEraserDown)
                {
                    SaveMemory.Id++;
                    SaveMemory.talkIndex = 0;
                }
                else
                {
                    SaveMemory.talkIndex = 0;
                    SaveMemory.Id = 31;
                }
                Talk(SaveMemory.Id);
            }

            else if (SaveMemory.Id == 29)
            {
                past.sprite = eraserDown;     // 햄버거 모양 지우개 밑에 모습
                SaveMemory.Id = 30;
                showImage();
            }
            else if (SaveMemory.Id == 30 && SaveMemory.findEraserUp)
            {
                speed = 0.02f;
                x = 0.05f;
                SaveMemory.talking = true;
                SaveMemory.Id = 31;
                SaveMemory.talkIndex = 0;
                Talk(SaveMemory.Id);
                moveGhostLeft = true;
            }
            // 미니게임씬 생략
            else if (SaveMemory.Id == 37)
            {
                SaveMemory.Id = 40;
                SaveMemory.talkIndex = 0;
                SaveMemory.talking = true;
                Talk(SaveMemory.Id);
                //SaveMemory.MiniGame = true;
            }
            else if (SaveMemory.Id == 38)
            {
                SaveMemory.Id = 40;
                SaveMemory.talkIndex = 0;
                SaveMemory.talking = true;
                Talk(SaveMemory.Id);
            }
            else if (SaveMemory.Id == 40)
            {
                SaveMemory.selecting = true;
                select.SetActive(true);
            }
            else if (SaveMemory.Id == 43)                           // 3층 귀신과 함께 3층에 올라옴
            {
                moveObject = GhostGlasses;
                speed = 0.02f;
                x = -7f;
                moveGhostLeft = true;
            }
            else if (SaveMemory.Id == 45)                           // 6학년 단체 사진을 발견
            {
                past.sprite = picture;
                SaveMemory.Id = 46;
                showImage();
            }
            else if (SaveMemory.Id == 46)                           
            {
                moveObject = Ghost;
                speed = 0.02f;
                x = -5.7f;
                y = -3.4f;
                moveGhostLeft = true;
                moveGhostDown = true;
            }
            else if (SaveMemory.Id == 47)                           // 귀신이 꽃에 빙의
            {
                moveObject = Ghost;
                speed = 0.02f;
                x = -2.11f;
                y = 0.06f;
                moveGhostUp = true;
                moveGhostRight = true;
            }
            else if (SaveMemory.Id == 49)                           // 귀신이 문에 들어가지 못 함.
            {
                SceneManager.LoadScene("BadEnding");
            }
            else if (SaveMemory.Id == 50)                           // 귀신이 문에 들어가지 못 함.
            {
                SaveMemory.Id = 51;
                SaveMemory.talkIndex = 0;
                SaveMemory.talking = true;
                Talk(SaveMemory.Id);
            }
            else if (SaveMemory.Id == 51)                           // 귀신이 문에 들어가지 못 함.
            {
                Black.SetActive(true);
            }
            else if (SaveMemory.Id == 52)                            // 저승사자 이동 후 귀신이 말검 아직 구현 안함.
            {
                SaveMemory.Id = 53;
                SaveMemory.talkIndex = 0;
                SaveMemory.talking = true;
                Talk(SaveMemory.Id);
            }

            /* 노멀엔딩 진엔딩 선택 분기 */
            else if (SaveMemory.Id == 53)
            {
                SaveMemory.selecting = true;
                select.SetActive(true);

                selectText1.GetComponent<Text>().text = "1. 너랑 같이 갈 생각이야.";
                selectText2.GetComponent<Text>().text = "2. 여기에 남아있을래";
            }

            else if (SaveMemory.Id == 55)
            {
                select.SetActive(true);

                SaveMemory.selecting = true;
                selectText1.GetComponent<Text>().text = "1. 그래도 너랑 같이 갈래";
                selectText2.GetComponent<Text>().text = "2. 알았어, 여기에 남아있을게.";
            }

            else if (SaveMemory.Id == 57)
            {
                moveObject = Ghost;
                x = -0.7f;
                y = 0f;
                moveGhostRight = true;
                moveGhostUp = true;
            }
            else if (SaveMemory.Id == 58 || SaveMemory.Id == 59)
            {
                moveObject = Ghost;
                x = -0.7f;
                y = 0f;
                moveGhostRight = true;
                moveGhostUp = true;
            }

            else if (SaveMemory.Id == 60)
            {
                moveObject = Ghost;
                moveObject2 = Reaper;
                x = 0;
                y = 1.16f;
                moveGhostRight = true;
                moveGhostUp = true;
            }
            else if (SaveMemory.Id == 61)
            {
                SceneManager.LoadScene("HalfHappy");
            }

            else if (SaveMemory.Id == 62)
            {
                moveObject = Ghost;
                moveObject2 = Reaper;
                x = 0;
                y = 1.16f;
                moveGhostRight = true;
                moveGhostUp = true;
            }
            else if (SaveMemory.Id == 63)
            {
                Black.SetActive(true);
            }

            else if (SaveMemory.Id == 64)
            {
                SaveMemory.Id = 65;
                SceneManager.LoadScene("TrueEnding");
            }
            else if (SaveMemory.Id == 65)
            {
                SaveMemory.Id = 66;
                SaveMemory.talkIndex = 0;
                SaveMemory.talking = true;
                Talk(SaveMemory.Id);
            }
            else if (SaveMemory.Id == 66)
            {
                Black.SetActive(true);
            }
            return;
        }

        talkText.text = talkData;
        talkImage.sprite = ImageData;
        SaveMemory.talking = true;
    }

    void showImage()
    {
        Color tmp = past.color;
        tmp.a = 1;
        past.color = tmp;
        SaveMemory.showing = true;
    }

    /* 선택창 현재 선택지 표시 */
    void Choice()
    {
        if (selectBox1.activeSelf == true)
        {
            selectBox1.SetActive(false);
            selectBox2.SetActive(true);
        }
        else
        {
            selectBox1.SetActive(true);
            selectBox2.SetActive(false);
        }
    }

    /* 귀신 만나는 이벤트 */
    public void meetGhost()
    {
        Debug.Log("meetGhost함수실행");
        Ghost.transform.position = new Vector3(0, player.transform.position.y, 0);
        Ghost.SetActive(true);
        SaveMemory.talkIndex=0;
        SaveMemory.talking = true;        
        Talk(SaveMemory.Id);
        SaveMemory.talkIndex++;
    }

    void Awake()
    {
        /* JSON파일 읽어오기*/
        string filePath = Application.dataPath + "/DialogData/Dialog_WithGhost.json";
        string data = System.IO.File.ReadAllText(filePath);

        jObject = JObject.Parse(data);

        /* 이벤트 분기에 따라 스토리 진행 */        
        if (SaveMemory.trueEnding)
        {
            SaveMemory.Id = 65;
            SaveMemory.talkIndex = 0;
            Talk(SaveMemory.Id);
            SaveMemory.talkIndex = 1;
        }
        else if (SaveMemory.halfHappy)
        {
            SaveMemory.Id = 63;
            SaveMemory.talkIndex = 0;
            Talk(SaveMemory.Id);
            SaveMemory.talkIndex = 1;
        }
        else if (SaveMemory.badEnding)
        {
            SaveMemory.Id = 50;
            SaveMemory.talkIndex = 0;
            Talk(SaveMemory.Id);
            SaveMemory.talkIndex = 1;
        }

        else if (SaveMemory.schoolRoop)
        {
            //SaveMemory.Id = 32;     // 나중에 바꿔야 하는 값
            if (SaveMemory.findPicture)
            {
                Reaper.SetActive(true);
                speed = 0.02f;
                y = 0f;
                moveObject = Reaper;
                moveGhostDown = true;
                SaveMemory.Id = 52;
            }
            else
            {
                SaveMemory.Id = 47;
                SaveMemory.talkIndex = 0;
                Talk(SaveMemory.Id);
                SaveMemory.talkIndex = 1;
            }
        }
        else if (SaveMemory.enterSchool3)
        {
            SaveMemory.Id = 43;
            SaveMemory.talkIndex = 0;
            Talk(SaveMemory.Id);
            SaveMemory.talkIndex = 1;
        }
        else if (SaveMemory.enterSchool2)
        {
            SaveMemory.Id = 35;
            SaveMemory.talkIndex = 0;
            Talk(SaveMemory.Id);
            SaveMemory.talkIndex = 1;
        }
        else if (SaveMemory.enterSchool1)
        {
            SaveMemory.Id = 22;
            SaveMemory.talkIndex = 0;
            Talk(SaveMemory.Id);
            SaveMemory.talkIndex = 1;
        }
        else if (SaveMemory.enterHouse)
        {
            SaveMemory.Id = 7;
            SaveMemory.talkIndex = 0;
            Talk(SaveMemory.Id);
            SaveMemory.talkIndex = 1;
        }
        else if (!SaveMemory.gameStart)
        {
            SaveMemory.talking = true;
            SaveMemory.Id = 1;
            SaveMemory.talkIndex = 0;
            Talk(SaveMemory.Id);
            SaveMemory.talkIndex = 1;
        }

        if (SaveMemory.roomDoor == 3 && !SaveMemory.enterSchool1)
        {
            GameObject.Find("roomDoor").SetActive(false);
        }
    }

    void Update()
    {
        if (SaveMemory.MiniGameEnd)
        {
            SaveMemory.MiniGameEnd = false;
            SaveMemory.talkIndex = 0;
            SaveMemory.talking = true;
            Talk(SaveMemory.Id);
            SaveMemory.talkIndex++;
        }

        /* NPC이동 */
        if (moveGhostUp)
        {
            moveObject.transform.Translate(0, speed, 0);
            if (moveObject2 != null)
            {
                moveObject2.transform.Translate(0, speed, 0);
            }

            if (moveObject.transform.position.y >= y)
            {
                if (SaveMemory.Id == 60 || SaveMemory.Id == 62)
                {
                    Ghost.SetActive(false);
                    Reaper.SetActive(false);

                    if (SaveMemory.Id == 62)
                    {
                        SaveMemory.talkIndex = 0;
                        SaveMemory.talking = true;
                        SaveMemory.Id = 64;
                        Talk(SaveMemory.Id);
                        SaveMemory.talkIndex++;
                    }
                }
                moveGhostUp = false;
            }
        }
        if (moveGhostDown)
        {
            moveObject.transform.Translate(0, -speed, 0);
            if (moveObject2 != null)
            {
                moveObject2.transform.Translate(0, -speed, 0);
            }
            if (moveObject.transform.position.y <= y)
            {
                if (SaveMemory.Id == 36)
                {                    
                    SaveMemory.talkIndex = 0;
                    SaveMemory.talking = true;
                    Talk(SaveMemory.Id);
                    SaveMemory.talkIndex++;
                    SaveMemory.Id = 37;
                }
                if (SaveMemory.Id == 52)
                {
                    SaveMemory.talkIndex = 0;
                    SaveMemory.talking = true;
                    Talk(SaveMemory.Id);
                    SaveMemory.talkIndex++;
                }
                moveGhostDown = false;
            }
        }
        if (moveGhostRight)
        {
            moveObject.transform.Translate(speed, 0, 0);
            if (SaveMemory.Id != 60 && SaveMemory.Id != 62 && moveObject2 != null)
            {
                moveObject2.transform.Translate(speed, 0, 0);
            }
            if (moveObject.transform.position.x >= x)
            {
                if (SaveMemory.Id == 47)
                {
                    Ghost.SetActive(false);
                    flower.SetActive(false);
                    flowerSmile.SetActive(true);
                    SaveMemory.talkIndex = 0;
                    SaveMemory.talking = true;
                    SaveMemory.Id = 48;
                    Talk(SaveMemory.Id);
                    SaveMemory.talkIndex++;
                }
                moveGhostRight = false;
            }
        }
        if (moveGhostLeft)
        {
            moveObject.transform.Translate(-speed, 0, 0);
            if (moveObject2 != null)
            {
                moveObject2.transform.Translate(-speed, 0, 0);
            }
            if (moveObject.transform.position.x <= x)
            {
                moveGhostLeft = false;
            }
        }

        /* 이벤트 발생에 따른 스토리 진행 */
        if (SaveMemory.roomDoor == 1 && Ghost.transform.position == new Vector3(-2.3f, 0, 0))
        {
            SaveMemory.Id = 9;
            SaveMemory.talkIndex = 0;
            Talk(SaveMemory.Id);
            SaveMemory.talkIndex++;
        }
        if (ribbon)
        {
            SaveMemory.Id = 23;
            SaveMemory.talkIndex = 0;
            Talk(SaveMemory.Id);
            SaveMemory.talkIndex++;
            ribbon = false;
        }

        if (SaveMemory.enterSchool2 && !SaveMemory.enterSchool3 && !SaveMemory.schoolRoop && !SaveMemory.metTrouble && player.transform.position.x >= -4.2)
        {
            SaveMemory.Id = 36;
            SaveMemory.talkIndex = 0;
            Talk(SaveMemory.Id);
            SaveMemory.talkIndex++;

            y = -1.2f;
            speed = 0.02f;
            moveObject = GhostCap;
            moveObject2 = GhostGlasses;

            moveGhostDown = true;
            SaveMemory.metTrouble = true;
        }

        /* Z키를 눌러 대화 진행 */
        if (SaveMemory.talking)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Talk(SaveMemory.Id);
                SaveMemory.talkIndex++;                
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (ImageControll)
            {
                ImageControll = false;
                SaveMemory.showing = false;
                Color tmp = past.color;
                tmp.a = 0.0f;
                past.color = tmp;

                if (SaveMemory.Id == 29)
                {
                    SaveMemory.Id = 30;
                    SaveMemory.talkIndex = 0;
                }
                SaveMemory.talking = true;
                if (SaveMemory.Id == 20 && !sawPiano)
                {
                    sawPiano = true;
                    past.sprite = piano3;
                    SaveMemory.talking = false;
                    showImage();
                }
                else if (SaveMemory.Id == 25 && !sawPiano)
                {
                    sawPiano = true;
                    past.sprite = windowCracked;
                    SaveMemory.talking = false;
                    showImage();
                }
                else // 144이면서 sawPiano가 아니면 대화창 실행
                {
                    Talk(SaveMemory.Id);
                    SaveMemory.talkIndex++;
                }

            }
            else if (selected)
            {
                selected = false;
                SaveMemory.selecting = false;
                SaveMemory.talking = true;
                if (selectBox1.activeSelf == true)
                {
                    if (SaveMemory.Id == 53)
                    {
                        SaveMemory.Id = 55;
                    }
                    else if (SaveMemory.Id == 55)
                    {
                        SaveMemory.halfHappy = true;
                        SaveMemory.Id = 57;
                    }
                    else
                    {
                        SaveMemory.Id = 42;
                    }
                }
                else
                {
                    if (SaveMemory.Id == 53)
                    {
                        SaveMemory.Id = 59;
                        SaveMemory.trueEnding = true;
                    }
                    else if (SaveMemory.Id == 55)
                    {
                        SaveMemory.Id = 58;
                        SaveMemory.trueEnding = true;
                    }
                    else
                    {
                        SaveMemory.Id = 41;
                        SaveMemory.dontGo3 = true;
                    }
                }
                select.SetActive(false);
                Talk(SaveMemory.Id);
                SaveMemory.talkIndex++;
            }
            else if (black)
            {
                Ending.SetActive(true);
                if (SaveMemory.trueEnding)
                {
                    Ending.GetComponent<Text>().text = "True Ending";
                }
                else if (SaveMemory.halfHappy)
                {
                    Ending.GetComponent<Text>().text = "Happy Ending?";
                }
                else if (SaveMemory.badEnding)
                {
                    Ending.GetComponent<Text>().text = "Bad Ending...";
                }

            }
        }

        if (SaveMemory.showing)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                ImageControll = true;
            }

        }
        if (SaveMemory.selecting)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                selected = true;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                Choice();
            }
        }

        if (Black.activeSelf == true)
        {
            black = true;
        }
    }     
}