using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
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
    Dictionary<int, Sprite[]> ImageData;

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
                    SaveMemory.Id = 15;
                }
                else
                {
                    SaveMemory.Id = 1400;
                }
                Talk(SaveMemory.Id);
            }

            if (scanObj.name == "coffee")
            {
                SaveMemory.talkIndex = 0;
                if (SaveMemory.findKey >= 1)
                {
                    SaveMemory.Id = 140;
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
                    SaveMemory.Id = 141;
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
                    SaveMemory.Id = 144;
                    past.sprite = piano2;
                    showImage();
                    if (SaveMemory.findKey == 5) { SaveMemory.findKey++; }
                }
                else if (SaveMemory.findKey >= 3 && SaveMemory.findKey < 5)
                {
                    SaveMemory.Id = 142;
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
                    SaveMemory.Id = 143;
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
                    SaveMemory.Id = 18;
                    SaveMemory.lookWindow = true;
                }
                else if (!SaveMemory.findEraserUp)
                {
                    SaveMemory.Id = 181;
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
                    SaveMemory.Id = 19;
                    Talk(SaveMemory.Id);
                    SaveMemory.findEraserDown = true;
                }
            }

            if (scanObj.name == "GhostRibbon")
            {
                SaveMemory.talkIndex = 0;

                if (SaveMemory.RibbonGB)
                {
                    SaveMemory.Id = 200;
                }
                else if (SaveMemory.findEraserDown && SaveMemory.findEraserUp)
                {
                    SaveMemory.Id = 20;
                    SaveMemory.RibbonGB = true;
                }
                else
                {
                    SaveMemory.Id = 201;
                }
                Talk(SaveMemory.Id);
            }

            if (scanObj.name == "missingBook")                                       // 책갈피 발견
            {
                if (!SaveMemory.findBook)
                {
                    SaveMemory.talkIndex = 0;
                    SaveMemory.Id = 30;
                    SaveMemory.findBook = true;
                    Talk(SaveMemory.Id);
                }
            }

            if (scanObj.name == "missingMemory")                                   // 단체사진 조사
            {
                if (!SaveMemory.findPicture)
                {
                    SaveMemory.talkIndex = 0;
                    SaveMemory.Id = 31;
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

                    SaveMemory.Id = 321;
                }
                if (SaveMemory.halfHappy)
                {
                    SaveMemory.Id = 3500;
                }
                Talk(SaveMemory.Id);
            }

            if (scanObj.name == "reaper")
            {
                if (SaveMemory.trueEnding)
                {
                    SaveMemory.Id = 351;
                }
                else if (SaveMemory.halfHappy)
                {
                    SaveMemory.Id = 350;
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
        Sprite ImageData = GetTalk(id, SaveMemory.talkIndex);

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


        /* 대화 종료 후 이벤트 발생 */
        if (talkData == null)
        {
            SaveMemory.talking = false;

            talkUI.SetActive(false);
            talkUIDown.SetActive(false);
            SaveMemory.talkIndex = -1;
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
            else if (id == 15)
            {
                SaveMemory.talking = true;
                SaveMemory.talkIndex = 0;
                SaveMemory.enterSchool1 = true;
                SceneManager.LoadScene("School1");
            }
            else if (SaveMemory.Id == 16)
            {
                speed = 0.1f;
                moveObject = GhostRibbon;
                moveGhostDown = true;
                y = -1.3f;
                ribbon = true;
            }
            else if (SaveMemory.Id == 17)
            {
                speed = 0.1f;
                moveObject = GhostRibbon;
                moveGhostDown = true;
                moveGhostRight = true;
                x = 4f;
                y = -3f;
            }
            else if (SaveMemory.Id == 18)
            {
                SaveMemory.Id = 180;
                past.sprite = eraserShooting;     // 지우개가 튕겨나가는 모습
                showImage();
            }
            else if (SaveMemory.Id == 181)
            {
                SaveMemory.Id = 182;
                past.sprite = eraserUp;     // 햄버거 모양 지우개 모습
                showImage();
            }
            else if (SaveMemory.Id == 182)
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
                    SaveMemory.Id = 191;
                }
                Talk(SaveMemory.Id);
            }

            else if (SaveMemory.Id == 19)
            {
                past.sprite = eraserDown;     // 햄버거 모양 지우개 밑에 모습
                SaveMemory.Id = 190;
                showImage();
            }
            else if (SaveMemory.Id == 190 && SaveMemory.findEraserUp)
            {
                speed = 0.02f;
                x = 0.05f;
                SaveMemory.talking = true;
                SaveMemory.Id = 191;
                SaveMemory.talkIndex = 0;
                Talk(SaveMemory.Id);
                moveGhostLeft = true;
            }

            // 미니게임씬 생략
            else if (SaveMemory.Id == 23)
            {
                SaveMemory.Id = 26;
                SaveMemory.talkIndex = 0;
                SaveMemory.talking = true;
                Talk(SaveMemory.Id);
                //SaveMemory.MiniGame = true;
            }
            else if (SaveMemory.Id == 24)
            {
                SaveMemory.Id = 26;
                SaveMemory.talkIndex = 0;
                SaveMemory.talking = true;
                Talk(SaveMemory.Id);
            }
            else if (SaveMemory.Id == 26)
            {
                SaveMemory.selecting = true;
                select.SetActive(true);
            }
            else if (SaveMemory.Id == 29)                           // 3층 귀신과 함께 3층에 올라옴
            {
                moveObject = GhostGlasses;
                speed = 0.02f;
                x = -7f;
                moveGhostLeft = true;
            }
            else if (SaveMemory.Id == 31)                           // 6학년 단체 사진을 바견
            {
                past.sprite = picture;
                SaveMemory.Id = 311;
                showImage();
            }
            else if (SaveMemory.Id == 311)                           // 6학년 단체 사진을 바견
            {
                moveObject = Ghost;
                speed = 0.02f;
                x = -5.7f;
                y = -3.4f;
                moveGhostLeft = true;
                moveGhostDown = true;
            }
            else if (SaveMemory.Id == 32)                           // 귀신이 꽃에 빙의
            {
                moveObject = Ghost;
                speed = 0.02f;
                x = -2.11f;
                y = 0.06f;
                moveGhostUp = true;
                moveGhostRight = true;
            }
            else if (SaveMemory.Id == 321)                           // 귀신이 문에 들어가지 못 함.
            {
                SceneManager.LoadScene("BadEnding");
            }
            else if (SaveMemory.Id == 322)                           // 귀신이 문에 들어가지 못 함.
            {
                SaveMemory.Id = 323;
                SaveMemory.talkIndex = 0;
                SaveMemory.talking = true;
                Talk(SaveMemory.Id);
            }
            else if (SaveMemory.Id == 323)                           // 귀신이 문에 들어가지 못 함.
            {
                Black.SetActive(true);
            }
            else if (SaveMemory.Id == 33)                            // 저승사자 이동 후 귀신이 말검 아직 구현 안함.
            {
                SaveMemory.Id = 34;
                SaveMemory.talkIndex = 0;
                SaveMemory.talking = true;
                Talk(SaveMemory.Id);
            }

            /* 노멀엔딩 진엔딩 선택 분기 */
            else if (SaveMemory.Id == 34)
            {
                SaveMemory.selecting = true;
                select.SetActive(true);

                selectText1.GetComponent<Text>().text = "1. 너랑 같이 갈 생각이야.";
                selectText2.GetComponent<Text>().text = "2. 여기에 남아있을래";
            }

            else if (SaveMemory.Id == 340)
            {
                select.SetActive(true);

                SaveMemory.selecting = true;
                selectText1.GetComponent<Text>().text = "1. 그래도 너랑 같이 갈래";
                selectText2.GetComponent<Text>().text = "2. 알았어, 여기에 남아있을게.";
            }

            else if (SaveMemory.Id == 3400)
            {
                moveObject = Ghost;
                x = -0.7f;
                y = 0f;
                moveGhostRight = true;
                moveGhostUp = true;
            }
            else if (SaveMemory.Id == 3401 || SaveMemory.Id == 341)
            {
                moveObject = Ghost;
                x = -0.7f;
                y = 0f;
                moveGhostRight = true;
                moveGhostUp = true;
            }

            else if (SaveMemory.Id == 350)
            {
                moveObject = Ghost;
                moveObject2 = Reaper;
                x = 0;
                y = 1.16f;
                moveGhostRight = true;
                moveGhostUp = true;
            }
            else if (SaveMemory.Id == 3500)
            {
                SceneManager.LoadScene("HalfHappy");
            }

            else if (SaveMemory.Id == 351)
            {
                moveObject = Ghost;
                moveObject2 = Reaper;
                x = 0;
                y = 1.16f;
                moveGhostRight = true;
                moveGhostUp = true;
            }
            else if (SaveMemory.Id == 352)
            {
                Black.SetActive(true);
            }

            else if (SaveMemory.Id == 36)
            {
                SaveMemory.Id = 37;
                SceneManager.LoadScene("TrueEnding");
            }
            else if (SaveMemory.Id == 37)
            {
                SaveMemory.Id = 38;
                SaveMemory.talkIndex = 0;
                SaveMemory.talking = true;
                Talk(SaveMemory.Id);
            }
            else if (SaveMemory.Id == 38)
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
        Ghost.transform.position = new Vector3(0, player.transform.position.y, 0);
        Ghost.SetActive(true);
        SaveMemory.talking = true;
        Talk(SaveMemory.Id);
        SaveMemory.talkIndex++;
    }

    void Awake()
    {
        /* 이벤트 분기에 따라 스토리 진행 */
        ImageData = new Dictionary<int, Sprite[]>();
        GenerateData();
        if (SaveMemory.trueEnding)
        {
            SaveMemory.Id = 37;
            SaveMemory.talkIndex = 0;
            Talk(SaveMemory.Id);
            SaveMemory.talkIndex = 1;
        }
        else if (SaveMemory.halfHappy)
        {
            SaveMemory.Id = 352;
            SaveMemory.talkIndex = 0;
            Talk(SaveMemory.Id);
            SaveMemory.talkIndex = 1;
        }
        else if (SaveMemory.badEnding)
        {
            SaveMemory.Id = 322;
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
                SaveMemory.Id = 33;
            }
            else
            {
                SaveMemory.Id = 32;
                SaveMemory.talkIndex = 0;
                Talk(SaveMemory.Id);
                SaveMemory.talkIndex = 1;
            }
        }
        else if (SaveMemory.enterSchool3)
        {
            SaveMemory.Id = 29;
            SaveMemory.talkIndex = 0;
            Talk(SaveMemory.Id);
            SaveMemory.talkIndex = 1;
        }
        else if (SaveMemory.enterSchool2)
        {
            SaveMemory.Id = 21;
            SaveMemory.talkIndex = 0;
            Talk(SaveMemory.Id);
            SaveMemory.talkIndex = 1;
        }
        else if (SaveMemory.enterSchool1)
        {
            SaveMemory.Id = 16;
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
                if (SaveMemory.Id == 350 || SaveMemory.Id == 351)
                {
                    Ghost.SetActive(false);
                    Reaper.SetActive(false);

                    if (SaveMemory.Id == 351)
                    {
                        SaveMemory.talkIndex = 0;
                        SaveMemory.talking = true;
                        SaveMemory.Id = 36;
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
                if (SaveMemory.Id == 22)
                {
                    SaveMemory.Id = 23;
                    SaveMemory.talkIndex = 0;
                    SaveMemory.talking = true;
                    Talk(SaveMemory.Id);
                    SaveMemory.talkIndex++;
                }
                if (SaveMemory.Id == 33)
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
            if (SaveMemory.Id != 350 && SaveMemory.Id != 351 && moveObject2 != null)
            {
                moveObject2.transform.Translate(speed, 0, 0);
            }
            if (moveObject.transform.position.x >= x)
            {
                if (SaveMemory.Id == 32)
                {
                    Ghost.SetActive(false);
                    flower.SetActive(false);
                    flowerSmile.SetActive(true);
                    SaveMemory.talkIndex = 0;
                    SaveMemory.talking = true;
                    SaveMemory.Id = 320;
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
            SaveMemory.Id = 17;
            SaveMemory.talkIndex = 0;
            Talk(SaveMemory.Id);
            SaveMemory.talkIndex++;
            ribbon = false;
        }

        if (SaveMemory.enterSchool2 && !SaveMemory.enterSchool3 && !SaveMemory.schoolRoop && !SaveMemory.metTrouble && player.transform.position.x >= -4.2)
        {
            SaveMemory.Id = 22;
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

                if (SaveMemory.Id == 19)
                {
                    SaveMemory.Id = 190;
                    SaveMemory.talkIndex = 0;
                }
                SaveMemory.talking = true;
                if (SaveMemory.Id == 144 && !sawPiano)
                {
                    sawPiano = true;
                    past.sprite = piano3;
                    SaveMemory.talking = false;
                    showImage();
                }
                else if (SaveMemory.Id == 180 && !sawPiano)
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
                    if (SaveMemory.Id == 34)
                    {
                        SaveMemory.Id = 340;
                    }
                    else if (SaveMemory.Id == 340)
                    {
                        SaveMemory.halfHappy = true;
                        SaveMemory.Id = 3400;
                    }
                    else
                    {
                        SaveMemory.Id = 28;
                    }
                }
                else
                {
                    if (SaveMemory.Id == 34)
                    {
                        SaveMemory.Id = 341;
                        SaveMemory.trueEnding = true;
                    }
                    else if (SaveMemory.Id == 340)
                    {
                        SaveMemory.Id = 3401;
                        SaveMemory.trueEnding = true;
                    }
                    else
                    {
                        SaveMemory.Id = 27;
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

    /* 캐릭터 표정 다이얼로그를 Dictionary에 저장 */
    void GenerateData()
    {
        ImageData.Add(1, new Sprite[] {
            player1,//놀람
            player4// 걱정
        });

        ImageData.Add(2, new Sprite[] {
            player1,//놀람에 입염
            ghost5,//놀람에 입 다뭄
            ghost9,//흠..
            ghost2,//웃음 입 염
            player1,//황당하단 얼굴 벙찐 입 눈 무미건조
            ghost6,//씨익 웃으며 꿍꿍이 잇어보이는
            ghost10,//슬픈 입 염
            ghost6,//씨익 웃으며 꿍꿍이 잇어보이는
        });

        ImageData.Add(3, new Sprite[]
        {
            null,//얼굴X
          null,//얼굴X
           player5// 웃으며 멋쩍
        });

        // 귀신이 바위에서 나옴

        ImageData.Add(4, new Sprite[]
        {
            ghost3,// 실망 입 삐죽?
            ghost10,// 실망에 입 염
            player5,//멋쩍에 입염"그래, 그래서...\n저기 벽 중간에 있는 게 나가는 문이지?",
            ghost11,//입 미소"저건 가짜 문이야.",
            ghost2//눈 입 미소 "진짜 나가는 문은 투명해서 안 보이는데,\n내가 문 앞에 서서 알려줄게!"
        });

        ImageData.Add(5, new Sprite[]
        {
            ghost4,//눈 그대로 입염 "그쪽은 가짜 문이래두.",
            player3//눈 그대로 입염"내가 처음 보는 귀신 말을 어떻게 믿겠어?"
        });

        ImageData.Add(6, new Sprite[]
        {
            null,//"손잡이가 만져진다.",
            ghost2//눈 입 웃음"난 먼저 가있을게!"
        });
        ImageData.Add(7, new Sprite[]
        {
            player1,//입 염
            ghost2,//함박웃음 "헤헿, 앞으로도 나만 믿으라구!",
            player2,//다른곳 보며 입염 "그나저나 여긴 어디야?\n집 안에 들어온 거 같기는 한데...",
            ghost11,//입 미소"나도 여기가 어딘지는 몰라! 갇힌 이유도 모르구.\n다만 수상한 문이 있는 위치를 알고만 있을 뿐이야. ",
            ghost2,//함박웃음"여기서는 이제 현관 밖으로 나가야해!\n따라와!"
        });
        ImageData.Add(8, new Sprite[]
        {
            player5,//멋쩍 "문이 잠겨있어!",
            ghost4,//입염"...어? 그럼 어쩌지?",
            player6//걱정"밖에서도 안 열려?"
        });

        ImageData.Add(9, new Sprite[]
        {
            ghost10,//눈감고 입염 슬픈눈썹"고장난건가?",
            ghost8,//"아, 문고리에 빙의해볼게!\n빙의하면 빙의한 물건의 기억이 보이니까!" 
        });

        ImageData.Add(10, new Sprite[]
        {
            ghost11,//눈 그대로 입 웃음 "이 문 젓가락으로 풀면 열려!",
            player7// 눈감고 입염 심각한 눈썹"이 방에 젓가락이 있을 것 같진 않아.\n그렇다면,"
        });

        ImageData.Add(11, new Sprite[]
        {
            player8//"젓가락 같은 물건을 찾아보자."
        });

        ImageData.Add(12, new Sprite[]
        {
            player3,//"이 볼펜을 분해해서,",
            null,//"볼펜심을 획득했다.",
            player8//입 미소"이거로 열어보자."
        });

        ImageData.Add(13, new Sprite[]
        {
           null,//  "볼펜심을 잠금장치에 넣자 문이 열린다.",
            player9,//"됐다!",
            ghost2,//"오! 다행이다!",
            player8//"이제 현관으로 가볼까?"
        });

        ImageData.Add(14, new Sprite[]
        {
           player6,//"뭐야.\n열쇠로 여는 쪽이 집 쪽으로 있네?",
           ghost12,// "어...난 맨날 통과해서 다녀서 어떻게 여는지 잘 모르겠어.",
            player7,//"열쇠를 찾아야 되나?",
            ghost11//"물건을 조사하면 내가 빙의해서 기억을 볼게!"
        });

        ImageData.Add(1400, new Sprite[]                                       // 현관문을 다시 조사했을 때
       {
            player8//"열쇠를 찾아야 해"
       });

        ImageData.Add(140, new Sprite[]
        {
            ghost4//"뭐를 메모하고 있는 거지?"
        });

        ImageData.Add(141, new Sprite[]
        {
            ghost9//"음...피아노를 조사해볼까?"
        });
        ImageData.Add(142, new Sprite[]
        {
            ghost1//"앵무새다!"
        });
        ImageData.Add(143, new Sprite[]                  // 앵무새가 열쇠를 물고 피아노 위에 서있는 장면 까지
        {
            ghost9,//"!?",
            ghost12//"쟤 열쇠 물고 있는거 아니야?"
        });
        ImageData.Add(144, new Sprite[]                  // 앵무새가 피아노에 떨어진 장면을 보고
        {
           player6,//"아...\n열쇠...피아노 깊숙히 들어갔을 것 같은데...",
           ghost11,//"나한테 맡겨!",
           null,//"귀신이 피아노 안에서 열쇠를 꺼내왔다.
           null,//현관문 열쇠를 획득했다.",
           ghost2//"이제 나가면 되겠다. 그치?"
        });

        ImageData.Add(15, new Sprite[]
       {
            null,//"열쇠로 현관문을 열었다.",
            player9//"됐다!"
       });

        ImageData.Add(16, new Sprite[]
        {
             player3,//"어? 바로 학교잖아?.",
            ghost11,//"응! 이제 여기로 올라가기만 하면 돼.",
            null//"잠깐만!"
        });

        ImageData.Add(17, new Sprite[]
        {
            ribbon1,//"잠깐 나 좀 도와주면 안 될까?",
            ghost4,//"무슨 일인데?",
            ribbon2,//"2층 귀신들이 내 지우개를 가져갔었는데,\n가지고 놀다가 잃어버렸대.",
           ribbon1,//"혼자선 도저히 못 찾겠어서 그런데, 도와줄 수 있니?",
           ghost5,//"걔네들 보고 책임지고 찾아달라고 하면 되지.",
           ribbon2,//"걔네들은 3, 4학년 귀신인 걸?",
           ribbon1,//"3, 4학년은 무섭단 말이야.",
           ghost9,//"쪼꼬만 것들이 해봤자 뭘 하겠어?",
           player3,//"너는 몇 살인데?",
           ghost13,//"엄...몰라...",
           ribbon2,//"내 지우개를 찾아주면 딱지 3개 줄게.",
           ghost4,//"딱지?",
           ribbon3,//"응. 2층 귀신들을 만났을 때 분명 도움이 될 거야.",
           ribbon1,//"둘 다 딱지를 좋아하니깐.",
           player10,//"좋아, 열심히 찾아볼게. \n어차피 내가 없으면 얜 할 것도 없거든.",
           ghost14,//"!!!",
           ribbon3//"정말 고마워! 1학년 교실은 내가 찾아볼게.\n너네는 2학년 교실을 살펴봐줘.",
        });
        ImageData.Add(18, new Sprite[]
        {
            player4//"지우개가 창문에 맞은 건가?",
        });
        ImageData.Add(180, new Sprite[]
        {
            ghost8//"맞아! 지우개는 여기서 튕겼어!"
        });

        ImageData.Add(181, new Sprite[]
        {
            player11//"이건가?"
        });
        ImageData.Add(182, new Sprite[]
        {
            ghost4//"오! 햄버거 빵처럼 생겼다."
        });

        ImageData.Add(183, new Sprite[]
        {
            player5//"이렇게 봐서는 지우개인지 모르겠네.\n그래도 혹시 모르니까 챙기자."
         });

        ImageData.Add(19, new Sprite[]
        {
            player12,//"찾았다!",
            ghost11//"어디어디?"
        });

        ImageData.Add(190, new Sprite[]
        {
            ghost5,//"이게 어떻게 지우개야?",
            player9,//"이런 지우개도 있어.\n어렸을 때 음식모양 지우개가 집에 많았거든.",
            player8,//"아이스크림 모양도 있고 핫도그 모양도 있고.",
            ghost2,//"우와! 나도 구경시켜 줘!",
            player5,//"에이, 몇 년이 지났는데. 지금은 다 잃어버리고 없어.",
            player10,//"그래도 이런 지우개 오랜만에 봐서 기분이 이상하기는 하네.",            
        });

        ImageData.Add(191, new Sprite[]
        {
            player8//"이제 리본 맨 귀신한테 돌려주러 가자.",
        });
        ImageData.Add(20, new Sprite[]
        {
            ribbon2,//"어떡하지? 1학년 교실에는 없어. 열심히 찾았는데도 안보여...",
            ghost2,//"쨘!",
            ribbon3,//"우와! 내 지우개!\n양상추 하나쯤은 없어졌을 줄 알았는데 전부 찾았구나!",
            ribbon4,//"정말 고마워. 여기, 아까 말했던 딱지 3개!",
            null,//"딱지 3개를 얻었다.",
            ghost9,//"다음부터는 2층애들이 괴롭히면 너도 같이 싸워.,",
            ghost11,//"이미 귀신인데 더 죽기야 하겠어?",
            ribbon5,//"히히. 알았어.",
            ribbon3,//"그래도 2층 귀신들 만나서 혼내지는 마.\n가끔 내가 도움 받기도 하거든.",
            ghost4,//"그렇다면야, 뭐...",
            ribbon5,//"다들 잘 가! 지우개 찾아준 거 진짜 고마워!",
            player10//"그래, 너도 잘 있어!",
        });

        ImageData.Add(200, new Sprite[]
        {
            ribbon5//"2층 가는 길은 내 왼쪽으로 쭉 걸어가면 돼!"
        });

        ImageData.Add(201, new Sprite[]
        {
            ribbon1//"훌쩍훌쩍"
        });

        ImageData.Add(21, new Sprite[]
        {
            player9,//"그러고 보니, 어렸을 때 딱지치기 많이 했는데.",
            player5,//"그때 같이 놀았던 애들, 잘 지내고 있으려나?",
            ghost11,//"궁금하면 다시 연락하면 되지.",
            player13,//"음... 지금은 만나도 그때처럼 놀지는 못하니까.",
            player6,//"이제는 되돌아가지 못하는 시절이여서\n더 행복하고 좋았던 기억으로 남은 거 아닐까?"            
        });

        ImageData.Add(22, new Sprite[]
        {
            null,//"거기 잠깐!",
            null//"소지품 검사가 있겠다!"
        });

        ImageData.Add(23, new Sprite[]
        {
            cap1,//"아니! 이건...!\n내가 잃어버렸던 딱지!",
            glass1,//"뭐야! 훔친 거야?",
            cap2,//"용서할 수 없어!",
            ghost14//"아니, 해명할 기회는 줘야 할 것 아니야!"
        });

        ImageData.Add(24, new Sprite[]
        {
            cap3,//"뭐야, 이렇게 약한 녀석이 우리 딱지를 훔쳐간 거야?",
            glass2//"뭔가 이상하네.",
        });

        ImageData.Add(25, new Sprite[]
        {
            cap4,//"크윽, 우리가 지다니...!",
            glass2//"분하다!",
        });

        ImageData.Add(26, new Sprite[]
        {
            //player5,//"이제 우리 얘기도 들어줄래?",
            ghost15,//"맞아, 이 딱지는 우리가 훔친 게 아니야.\n1층 귀신이 준거라구!",
            glass1,//"1층 귀신이?",
            cap5,//"아!",
            glass3,//"왜?",
            cap6,//"이거 내가 저번에 1층에서 잃어버렸던 거야.\n까먹었었어.",
            glass4,//"...",
            ghost14,//"...",
            player5,//"우린 이제 가볼게.\n위로 올라갈 생각이었거든.",
            glass3,//"위로? 3층도 들르는 거야?",
            ghost4,//"왜?",
            cap7,//"얘, 사실 3층 귀신이야.",
            cap6,//"귀신 셋이서 1층, 2층, 3층을 맡아서 \n교실에서 사람이 뭘 하는지 관찰하는 게 우리 일이야.",
            glass5,//"여긴 살아있는 사람이 오진 않으니깐 심심해서 2층으로 놀러왔지.",
            glass3//"너네가 3층 교실에 들르면,\n나도 같이 올라갔다 올까 해서."
        });

        // 선택 후
        // 배드엔딩 루트
        ImageData.Add(27, new Sprite[]
        {
            player2,//"굳이 3층을 들러야 할 필요는 없지?",
            ghost11,//"응. 어차피 수상한 문은 옥상에 있으니깐!",
            glass6,//"좋은 생각이야! 어차피 3층에도 평범한 물건밖에 없거든.",
            glass7,//"연필, 지우개, 가방, 보드게임, 단체 사진 같은 거 말이야.",
            player8,//"그렇구나.",
            ghost2,//"이제 출발하자. 목적지가 눈앞에 있다구!",
            cap6,//"다들 잘 가! 너네랑 딱지치기 재밌었어!",
            glass6,//"안녕!",
            ghost1,//"잘 있어!",
            player12//"안녕!"
        });

        // 3층에 들른다.
        ImageData.Add(28, new Sprite[]
        {
            player8,//"3층도 돌아보고 싶어.",
            cap8,//"하긴,\n거의 10년 동안이나 내려와 있는 건 조금 너무한 거 같기도 하다. ",
            glass5,//"그런가...\n그래도 너네 데려다 주고 나서 아무 일 없으면 바로 내려올 거야.",
            ghost11,//"그래그래.",
            cap6,//"둘 다 잘 가!\n너네랑 딱지치기 재밌었어!",
            ghost1,//"잘 있어!",
            player12,//"안녕!",
        });

        // 3층에 올라와서
        ImageData.Add(29, new Sprite[]
        {
            glass3,//"여기 진짜 볼 거 없어.",
            glass7,//"그래도 소개하자면 위쪽이 5학년 교실이고 아래쪽이 6학년 교실이야.",
            glass6,//"어차피 여긴 더 이상 아무 사람도 안 올 테니까 마음대로 써도 괜찮아.",
            glass7,//"난 이제 간다?\n나갈 때 알아서 나가면 돼!",
            player14,//"그래, 같이 올라와줘서 고마워.",
        });

        // 책갈피 발견
        ImageData.Add(30, new Sprite[]
        {
            player1,//"어! 이거 예전에 잃어버렸던 거잖아?",
            ghost4,//"어렸을 때 잃어 버렸던 걸 지금까지 기억해?",
            player5,//"응, \n그때 친해지고 싶은 친구가 있었는데 그 애가 생일선물로 준 거였거든.",
            player13,//"나한텐 이게 특별한 물건이야.",
            player5//"그렇게나 좋았었는데 너무 오래되었는지 얼굴은 기억이 안 나네."
        });

        // 사진을 살펴보았을 경우
        ImageData.Add(31, new Sprite[]
        {
            player6,//"내 6학년 단체 사진이 왜 여기 있지?",
            ghost4//"어, 이 사진... 잠깐만.",
        });
        ImageData.Add(311, new Sprite[]
        {
            ghost10,//"그래, 맞아. 나는...",
            player15,//"뭐야?",
            ghost4,//"응?",
            ghost13,//"아....아니! 별거 없었어!",
            ghost11,//"이제 진짜 옥상으로 가면 마지막이네!",
            player13,//"그러네.",
           player10,// "서로 돕는 사이이긴 하지만 그래도 너 없었으면 여기까지 오기 힘들었을 거야.",
            player14,//"이제까지 제대로 도와줘서 고마워.",
            ghost10,//"어....",
            ghost12//"옥상 가는 길은 이쪽이야!"
        });

        // 배드엔딩
        ImageData.Add(32, new Sprite[]
        {
            ghost2,//"저게 내가 말한 문이야!",
            ghost9,//"이제 내가 빙의할 만한 게...",
            player9,//"저기 화단에 떨어져 있는 꽃은 어때?",
            ghost2,//"좋아!"
        });
        ImageData.Add(320, new Sprite[]
        {
            ghost11,//"이제 준비됐어!",
            player8,//"꽃을 들고 문으로 들어가자",
        });
        ImageData.Add(321, new Sprite[]
        {
            ghost4,//"어? 잠깐만!",
            ghost3,//"분명히 잘 잡혀 있었는데?",
            ghost10//"나 못 들어갔어!"
        });
        ImageData.Add(322, new Sprite[]
        {
            player12,//"우리 성공했어!\n이 꽃밭으로 이어지는 문 이었나봐.",
            player14//"옥상에 꽃도 여기서 따온 건가?"
        });

        ImageData.Add(323, new Sprite[]
        {
            player14,//"우리 성공했어!\n이 꽃밭으로 이어지는 문 이었나봐.",
            player16,//"옥상에 꽃도 여기서 따온 건가?"
            player15
        });

        ImageData.Add(33, new Sprite[]
        {
            Reaper1,//"이제 들어가도 되는가?",
            ghost4,//"누...누구세요?",
            Reaper2,//"원래 너를 데려가기로 했던 저승사자다.",
            Reaper1,//"네가 경계를 만드는 바람에 바로 저승으로 데려갈 수가 없었어.",
            Reaper2,//"이렇게 경계가 다시 열리기도 드문 일인데...\n운이 좋았구나.",
            player11,//"경계?",
            Reaper1,//"사람이 죽은 후에 자신이 누구였는지 잊게 된다면\n본인이 살던 장소로 구성된 경계를 만들게 되지.",
            Reaper2,//"자신이 누군지 다시 알게 된다면\n저승사자가 경계에 들어올 수 있지만,",
            Reaper1,//"그런 경우는 흔치 않아.",
            player12,//"그럼 너, 기억이 다 난거야?",
            ghost12,//"응... 미안,\n내가 누구인지는 못 말해줄 것 같아.",
            player11,//"왜?",
            ghost3,//"살아있을 때 친해지지도 못 했는데 귀신이 되어서야,",
            ghost10,//"그것도 아무 기억도 없는 상태로\n너한테 말을 걸고 같이 나가자고 했던 게 창피해.",
           ghost12,//"게다가 내가 귀신인 상태로 기억될 거잖아?\n그건 싫어!",
            player5,//"알았어. 그러면 더 안 물어 볼게.",
            player13,//"너 이제 저승 갈 건데 후회할 일 남기면 마음 안 좋잖아.",
            Reaper2,//".... 자네는 산 사람인가, 죽은 사람인가?",
            player6,//"그야 당연히 살아있는 사람...",
            Reaper2,//"산 사람이기엔 경계에 들어올 수가 없고\n죽은 사람이기엔 귀신의 형태로 변하지 않았으니,",
            Reaper1,//"솔직히 어째야 할지 난감하네.",
            player16,//"...",
            Reaper2,//"게다가 경계에서 나갈 수 있는 통로는 여기,\n이 저승으로 가는 저승문 뿐이야.",
            Reaper1,//"저승문으로 지나가게 되면 확실하게 죽게 되니, \n어떻게 할 것인지 잘 생각해보게.",
            Reaper2,//"귀신이 저승문으로 들어간 후에 \n경계가 어찌 되는지는 알려지지 않다만...",
            ghost12,//"저기, 잠시만 둘이서 얘기를 나눠도 될까요?",
            Reaper1//"그래, 결심이 서면 다시 나에게 말을 걸도록 하게."
        });

        ImageData.Add(34, new Sprite[]
        {
            ghost12//"있잖아, 넌 어떻게 할 생각이야?"
        });
        // 너랑 같이 갈 생각이야.
        ImageData.Add(340, new Sprite[]
        {
            ghost4,//"...어?",
            player6,//"경계에 남겨지면 어떻게 될지 모른다고 하니깐...",
            player5,//"혼자 남겨지는 것 보다는 너랑 같이 가는 게 더 낫지 않을까?",
            ghost10,//"그렇기는 하지만...\n나랑 같이 간다면 어떻게든 살아날 가능성도 없어지는 거잖아.",
            ghost3,//"진짜 괜찮겠어? 저승문을 지나면 진짜 저승에 가는 거야.",
            player4,//"...",
            ghost12,//"나는 솔직히 너가 여기에 남았으면 좋겠어.",
            ghost10,//"무책임한 말이기는 하지만 혹시라도 너가 죽은 게 아니라면",
            ghost12,//"그렇다면, 내가 저승에 가서 경계가 없어지고",
            ghost13,// "너도 이 공간에서 현실로 자연스럽게 나갈 수 있게 되는 게 아닐까?",
            player16,//"음... ",
            ghost4,//"여기 오면서 너가 그런 말도 했잖아? ",
            ghost12,//"\"이제는 되돌아가지 못하는 시절이여서 더 행복하고 좋았던 기억으로 남은 것 같다\"",
            ghost13,//"나도 그렇게 너한테 좋았던 추억으로 남고 싶어.",
            ghost11,//"너가 살아있었으면 좋겠어.",
            ghost12//"경계가 어떻게 될지 모르겠지만...\n저승문으로 가면 진짜로 너가 죽는거잖아."
        });

        ImageData.Add(3400, new Sprite[]
        {
            player8,//"그래도 난 너랑 같이 갈래.",
            player5,//"여기 있다가 영영 경계에 갇히게 되면 여기선 아무것도 못하게 되잖아.",
            player9,//"어차피 죽는 거랑 다름없는 상황이라면 난 너랑 같이 가는 게 더 좋아.",
            ghost3//"정 그렇다면 알았어...",
        });

        ImageData.Add(3401, new Sprite[]
        {
            player5,//"...알았어. 여기 남아있을게.",
            ghost11//"좋아! 너가 꼭 살아남길 바랄게.",
        });

        ImageData.Add(341, new Sprite[]
        {
            ghost11,//"좋아! 너가 꼭 살아남길 바랄게.",
            ghost13,//"기왕이면 너가 어릴 때 같이 놀았던 애들처럼\n나를 그렇게 기억해 줬으면 좋겠어...!",
            player10//"응. 그럴게.\n너도 조심해서 가."
        });

        ImageData.Add(350, new Sprite[]
        {
            Reaper2,//"이제 정했는가.",
            player8,//"네 저희 같이 갈 거에요.",
            Reaper2//"그럼 가도록 하지."
        });
        ImageData.Add(3500, new Sprite[]
        {
            player16,//"...",
            player8,//"나도 가자"
           
        });
        ImageData.Add(351, new Sprite[]
        {
            Reaper2,//"이제 정했는가.",
            player5,//"네 저는 남아있기로 결정했어요.",
            Reaper2,//"그럼 가도록 하지.",
            ghost13,//"꼭 살아남아야 해...! 너를 다시 만나서 즐거웠어.",
            player13//"응. 너도 조심히 가."
        });

        ImageData.Add(352, new Sprite[]
        {
            null,
            player1,//"어? 누구야...?",
            null,//"쨘!\n나 너랑 같이 여행 다니던 그 귀신이야!",
            null,//"이젠 사람모습으로 바뀌었다구!",
            player9,//"너 혹시...\n아까 단체사진에서 봤던, 그...",
            null,//"맞아! 나 000이야!",
            player10,//"오랜만이다! 너 진짜 6학년때 모습 그대로네?",
            null//"응! 졸업하자마자 죽었거든."
        });

        ImageData.Add(36, new Sprite[]
        {
            player6,//"진짜 여기에 갇힌 건가?",
            null,//"...아! 정신이 드니?",
            player16//"응? 내 이름이 들린거 같았는데?",
        });

        ImageData.Add(37, new Sprite[]
        {
            null,//"정신이 드니?",
            player1,//"엄마?",
            null//"하이고. 신이 살리셨네. 감사합니다. 감사합니다...\n우리 아들 살려주셔서 감사합니다."
        });

        ImageData.Add(38, new Sprite[]
        {
            null,
            null,
            null,
            null,//"나는 자취를 하다 오랜만에 부모님 집에 들르는 길에 교통사고를 당했다.",
            null,//"그곳은 10여 년 전에도 교통사고로 사망자가 나온 적 있는 곳이라 한다.",
            null,//"왠지 경계에서 만난 귀신이 생각나,\n혹시 내가 아는 애가 사고를 당했는지 여쭤봤다.",
            null,//"그 애는 내가 5학년 때 같은 반에 전학 왔던 친구라고 하셨다.",
            null,//"교통사고는 우리가족이 이사 간 후의 일이었기 때문에\n내가 충격 받을까봐 그 사실을 얘기해 주지 않으셨다고 하셨다.",
            null//"그리고 2주 후 난 병원에서 퇴원했다."
        });
    }

    /* 다이얼로그 ID에 맞춰 캐릭터 표정 변경 */
    Sprite GetTalk(int id, int talkIndex)
    {
        if (talkIndex == ImageData[id].Length)
            return null;
        else
            return ImageData[id][talkIndex];
    }
}