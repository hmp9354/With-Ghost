using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    /* ĳ���� ǥ�� Sprite */
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


    /* ������ ���� Sprite */
    public GameObject scanObject;
    public Image past;         // ���� �׸�    

    public Sprite roomDoor;
    public Sprite coffee;
    public Sprite memo;
    public Sprite piano1;       // �ǾƳ� ���� ���� ����
    public Sprite piano2;       // �ǾƳ� ���� ���� ����
    public Sprite piano3;       // �ǾƳ� �ȿ� ���� ����
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


    /* ĳ���� �̵� ���� ����*/
    GameObject moveObject;
    GameObject moveObject2;

    bool moveGhostUp = false;
    bool moveGhostDown = false;
    bool moveGhostRight = false;
    bool moveGhostLeft = false;

    // �̵��ؾ� �ϴ� ��ǥ �� �̵� �ӵ�
    float y;
    float x;
    float speed;


    /* ��ȭâ */
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

    // ����â
    public GameObject select;
    public GameObject selectBox1;
    public GameObject selectBox2;
    public GameObject selectText1;
    public GameObject selectText2;
    bool selected = false;


    /* �̺�Ʈ �б� */
    bool sawPiano = false;
    bool ribbon = false;
    bool ImageControll = false;
    bool black = false;


    /* ���� ���� ���� */
    public SaveMemory SM;
    public GameObject Black;
    public GameObject Ending;


    /* scanObj�� ���� ��� �� �ൿ*/
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

            if (scanObj.name == "missingBook")                                       // å���� �߰�
            {
                if (!SaveMemory.findBook)
                {
                    SaveMemory.talkIndex = 0;
                    SaveMemory.Id = 30;
                    SaveMemory.findBook = true;
                    Talk(SaveMemory.Id);
                }
            }

            if (scanObj.name == "missingMemory")                                   // ��ü���� ����
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

        /* �÷��̾� ��ġ�� ���� ��ȭâ�� ��ġ ���� */
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


        /* ��ȭ ���� �� �̺�Ʈ �߻� */
        if (talkData == null)
        {
            SaveMemory.talking = false;

            talkUI.SetActive(false);
            talkUIDown.SetActive(false);
            SaveMemory.talkIndex = -1;
            if (id == 1)                     // ���ΰ� �Ͼ�� �ϱ�
            {
                player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                SaveMemory.Id++;
                SaveMemory.gameStart = true;
            }
            else if (id == 2)                    // �ͽ��� ������ ����
            {
                Ghost.SetActive(false);
                GhostFace.SetActive(true);
                SaveMemory.talking = true;
                SaveMemory.talkIndex = 0;
                Talk(3);
                SaveMemory.Id++;
            }
            else if (id == 3)                     // �ͽ��� �������� ����
            {
                Ghost.SetActive(true);
                GhostFace.SetActive(false);
                SaveMemory.talking = true;
                SaveMemory.talkIndex = 0;
                Talk(4);
                SaveMemory.Id++;
            }
            else if (id == 4)                        // �ͽ��� ��¥ ���� �˷���
            {
                Ghost.transform.position = new Vector3(2, 1, 0);
            }

            // �� ����
            else if (id == 6)
            {
                Ghost.SetActive(false);
                SaveMemory.talking = true;
                SaveMemory.talkIndex = 0;
                SaveMemory.enterHouse = true;
                SceneManager.LoadScene("House");

            }
            // �ͽ��� ���� ����
            else if (id == 7)
            {
                speed = 0.02f;
                y = 0.8f;
                moveObject = Ghost;
                moveGhostUp = true;
            }
            else if (id == 8)                // ���ΰ��� ���� ���� ���ؼ� �ͽ��� �� ���� ���� �õ���.
            {
                speed = 0.02f;
                moveObject = Ghost;
                moveGhostRight = true;
                x = -2.3f;
                moveGhostDown = true;
                y = 0;
            }
            else if (id == 9)                // �ͽ��� ������ ����
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
                past.sprite = eraserShooting;     // ���찳�� ƨ�ܳ����� ���
                showImage();
            }
            else if (SaveMemory.Id == 181)
            {
                SaveMemory.Id = 182;
                past.sprite = eraserUp;     // �ܹ��� ��� ���찳 ���
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
                past.sprite = eraserDown;     // �ܹ��� ��� ���찳 �ؿ� ���
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

            // �̴ϰ��Ӿ� ����
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
            else if (SaveMemory.Id == 29)                           // 3�� �ͽŰ� �Բ� 3���� �ö��
            {
                moveObject = GhostGlasses;
                speed = 0.02f;
                x = -7f;
                moveGhostLeft = true;
            }
            else if (SaveMemory.Id == 31)                           // 6�г� ��ü ������ �ٰ�
            {
                past.sprite = picture;
                SaveMemory.Id = 311;
                showImage();
            }
            else if (SaveMemory.Id == 311)                           // 6�г� ��ü ������ �ٰ�
            {
                moveObject = Ghost;
                speed = 0.02f;
                x = -5.7f;
                y = -3.4f;
                moveGhostLeft = true;
                moveGhostDown = true;
            }
            else if (SaveMemory.Id == 32)                           // �ͽ��� �ɿ� ����
            {
                moveObject = Ghost;
                speed = 0.02f;
                x = -2.11f;
                y = 0.06f;
                moveGhostUp = true;
                moveGhostRight = true;
            }
            else if (SaveMemory.Id == 321)                           // �ͽ��� ���� ���� �� ��.
            {
                SceneManager.LoadScene("BadEnding");
            }
            else if (SaveMemory.Id == 322)                           // �ͽ��� ���� ���� �� ��.
            {
                SaveMemory.Id = 323;
                SaveMemory.talkIndex = 0;
                SaveMemory.talking = true;
                Talk(SaveMemory.Id);
            }
            else if (SaveMemory.Id == 323)                           // �ͽ��� ���� ���� �� ��.
            {
                Black.SetActive(true);
            }
            else if (SaveMemory.Id == 33)                            // ���»��� �̵� �� �ͽ��� ���� ���� ���� ����.
            {
                SaveMemory.Id = 34;
                SaveMemory.talkIndex = 0;
                SaveMemory.talking = true;
                Talk(SaveMemory.Id);
            }

            /* ��ֿ��� ������ ���� �б� */
            else if (SaveMemory.Id == 34)
            {
                SaveMemory.selecting = true;
                select.SetActive(true);

                selectText1.GetComponent<Text>().text = "1. �ʶ� ���� �� �����̾�.";
                selectText2.GetComponent<Text>().text = "2. ���⿡ ����������";
            }

            else if (SaveMemory.Id == 340)
            {
                select.SetActive(true);

                SaveMemory.selecting = true;
                selectText1.GetComponent<Text>().text = "1. �׷��� �ʶ� ���� ����";
                selectText2.GetComponent<Text>().text = "2. �˾Ҿ�, ���⿡ ����������.";
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

    /* ����â ���� ������ ǥ�� */
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

    /* �ͽ� ������ �̺�Ʈ */
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
        /* �̺�Ʈ �б⿡ ���� ���丮 ���� */
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
            //SaveMemory.Id = 32;     // ���߿� �ٲ�� �ϴ� ��
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

        /* NPC�̵� */
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

        /* �̺�Ʈ �߻��� ���� ���丮 ���� */
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

        /* ZŰ�� ���� ��ȭ ���� */
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
                else // 144�̸鼭 sawPiano�� �ƴϸ� ��ȭâ ����
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

    /* ĳ���� ǥ�� ���̾�α׸� Dictionary�� ���� */
    void GenerateData()
    {
        ImageData.Add(1, new Sprite[] {
            player1,//���
            player4// ����
        });

        ImageData.Add(2, new Sprite[] {
            player1,//����� �Կ�
            ghost5,//����� �� �ٹ�
            ghost9,//��..
            ghost2,//���� �� ��
            player1,//Ȳ���ϴ� �� ���� �� �� ���̰���
            ghost6,//���� ������ ����� �վ�̴�
            ghost10,//���� �� ��
            ghost6,//���� ������ ����� �վ�̴�
        });

        ImageData.Add(3, new Sprite[]
        {
            null,//��X
          null,//��X
           player5// ������ ��½
        });

        // �ͽ��� �������� ����

        ImageData.Add(4, new Sprite[]
        {
            ghost3,// �Ǹ� �� ����?
            ghost10,// �Ǹ��� �� ��
            player5,//��½�� �Կ�"�׷�, �׷���...\n���� �� �߰��� �ִ� �� ������ ������?",
            ghost11,//�� �̼�"���� ��¥ ���̾�.",
            ghost2//�� �� �̼� "��¥ ������ ���� �����ؼ� �� ���̴µ�,\n���� �� �տ� ���� �˷��ٰ�!"
        });

        ImageData.Add(5, new Sprite[]
        {
            ghost4,//�� �״�� �Կ� "������ ��¥ ���̷���.",
            player3//�� �״�� �Կ�"���� ó�� ���� �ͽ� ���� ��� �ϰھ�?"
        });

        ImageData.Add(6, new Sprite[]
        {
            null,//"�����̰� ��������.",
            ghost2//�� �� ����"�� ���� ��������!"
        });
        ImageData.Add(7, new Sprite[]
        {
            player1,//�� ��
            ghost2,//�Թڿ��� "���m, �����ε� ���� ������!",
            player2,//�ٸ��� ���� �Կ� "�׳����� ���� ����?\n�� �ȿ� ���� �� ����� �ѵ�...",
            ghost11,//�� �̼�"���� ���Ⱑ ������� ����! ���� ������ �𸣱�.\n�ٸ� ������ ���� �ִ� ��ġ�� �˰� ���� ���̾�. ",
            ghost2,//�Թڿ���"���⼭�� ���� ���� ������ ��������!\n�����!"
        });
        ImageData.Add(8, new Sprite[]
        {
            player5,//��½ "���� ����־�!",
            ghost4,//�Կ�"...��? �׷� ��¼��?",
            player6//����"�ۿ����� �� ����?"
        });

        ImageData.Add(9, new Sprite[]
        {
            ghost10,//������ �Կ� ���´���"���峭�ǰ�?",
            ghost8,//"��, ������ �����غ���!\n�����ϸ� ������ ������ ����� ���̴ϱ�!" 
        });

        ImageData.Add(10, new Sprite[]
        {
            ghost11,//�� �״�� �� ���� "�� �� ���������� Ǯ�� ����!",
            player7// ������ �Կ� �ɰ��� ����"�� �濡 �������� ���� �� ���� �ʾ�.\n�׷��ٸ�,"
        });

        ImageData.Add(11, new Sprite[]
        {
            player8//"������ ���� ������ ã�ƺ���."
        });

        ImageData.Add(12, new Sprite[]
        {
            player3,//"�� ������ �����ؼ�,",
            null,//"������� ȹ���ߴ�.",
            player8//�� �̼�"�̰ŷ� �����."
        });

        ImageData.Add(13, new Sprite[]
        {
           null,//  "������� �����ġ�� ���� ���� ������.",
            player9,//"�ƴ�!",
            ghost2,//"��! �����̴�!",
            player8//"���� �������� ������?"
        });

        ImageData.Add(14, new Sprite[]
        {
           player6,//"����.\n����� ���� ���� �� ������ �ֳ�?",
           ghost12,// "��...�� �ǳ� ����ؼ� �ٳ༭ ��� ������ �� �𸣰ھ�.",
            player7,//"���踦 ã�ƾ� �ǳ�?",
            ghost11//"������ �����ϸ� ���� �����ؼ� ����� ����!"
        });

        ImageData.Add(1400, new Sprite[]                                       // �������� �ٽ� �������� ��
       {
            player8//"���踦 ã�ƾ� ��"
       });

        ImageData.Add(140, new Sprite[]
        {
            ghost4//"���� �޸��ϰ� �ִ� ����?"
        });

        ImageData.Add(141, new Sprite[]
        {
            ghost9//"��...�ǾƳ븦 �����غ���?"
        });
        ImageData.Add(142, new Sprite[]
        {
            ghost1//"�޹�����!"
        });
        ImageData.Add(143, new Sprite[]                  // �޹����� ���踦 ���� �ǾƳ� ���� ���ִ� ��� ����
        {
            ghost9,//"!?",
            ghost12//"�� ���� ���� �ִ°� �ƴϾ�?"
        });
        ImageData.Add(144, new Sprite[]                  // �޹����� �ǾƳ뿡 ������ ����� ����
        {
           player6,//"��...\n����...�ǾƳ� ����� ���� �� ������...",
           ghost11,//"������ �ð�!",
           null,//"�ͽ��� �ǾƳ� �ȿ��� ���踦 �����Դ�.
           null,//������ ���踦 ȹ���ߴ�.",
           ghost2//"���� ������ �ǰڴ�. ��ġ?"
        });

        ImageData.Add(15, new Sprite[]
       {
            null,//"����� �������� ������.",
            player9//"�ƴ�!"
       });

        ImageData.Add(16, new Sprite[]
        {
             player3,//"��? �ٷ� �б��ݾ�?.",
            ghost11,//"��! ���� ����� �ö󰡱⸸ �ϸ� ��.",
            null//"���!"
        });

        ImageData.Add(17, new Sprite[]
        {
            ribbon1,//"��� �� �� �����ָ� �� �ɱ�?",
            ghost4,//"���� ���ε�?",
            ribbon2,//"2�� �ͽŵ��� �� ���찳�� ���������µ�,\n������ ��ٰ� �Ҿ���ȴ�.",
           ribbon1,//"ȥ�ڼ� ������ �� ã�ھ �׷���, ������ �� �ִ�?",
           ghost5,//"�³׵� ���� å������ ã�ƴ޶�� �ϸ� ����.",
           ribbon2,//"�³׵��� 3, 4�г� �ͽ��� ��?",
           ribbon1,//"3, 4�г��� ������ ���̾�.",
           ghost9,//"�ɲ��� �͵��� �غ��� �� �ϰھ�?",
           player3,//"�ʴ� �� ���ε�?",
           ghost13,//"��...����...",
           ribbon2,//"�� ���찳�� ã���ָ� ���� 3�� �ٰ�.",
           ghost4,//"����?",
           ribbon3,//"��. 2�� �ͽŵ��� ������ �� �и� ������ �� �ž�.",
           ribbon1,//"�� �� ������ �����ϴϱ�.",
           player10,//"����, ������ ã�ƺ���. \n������ ���� ������ �� �� �͵� ���ŵ�.",
           ghost14,//"!!!",
           ribbon3//"���� ����! 1�г� ������ ���� ã�ƺ���.\n�ʳ״� 2�г� ������ �������.",
        });
        ImageData.Add(18, new Sprite[]
        {
            player4//"���찳�� â���� ���� �ǰ�?",
        });
        ImageData.Add(180, new Sprite[]
        {
            ghost8//"�¾�! ���찳�� ���⼭ ƨ���!"
        });

        ImageData.Add(181, new Sprite[]
        {
            player11//"�̰ǰ�?"
        });
        ImageData.Add(182, new Sprite[]
        {
            ghost4//"��! �ܹ��� ��ó�� �����."
        });

        ImageData.Add(183, new Sprite[]
        {
            player5//"�̷��� ������ ���찳���� �𸣰ڳ�.\n�׷��� Ȥ�� �𸣴ϱ� ì����."
         });

        ImageData.Add(19, new Sprite[]
        {
            player12,//"ã�Ҵ�!",
            ghost11//"�����?"
        });

        ImageData.Add(190, new Sprite[]
        {
            ghost5,//"�̰� ��� ���찳��?",
            player9,//"�̷� ���찳�� �־�.\n����� �� ���ĸ�� ���찳�� ���� ���Ұŵ�.",
            player8,//"���̽�ũ�� ��絵 �ְ� �ֵ��� ��絵 �ְ�.",
            ghost2,//"���! ���� ������� ��!",
            player5,//"����, �� ���� �����µ�. ������ �� �Ҿ������ ����.",
            player10,//"�׷��� �̷� ���찳 �������� ���� ����� �̻��ϱ�� �ϳ�.",            
        });

        ImageData.Add(191, new Sprite[]
        {
            player8//"���� ���� �� �ͽ����� �����ַ� ����.",
        });
        ImageData.Add(20, new Sprite[]
        {
            ribbon2,//"�����? 1�г� ���ǿ��� ����. ������ ã�Ҵµ��� �Ⱥ���...",
            ghost2,//"º!",
            ribbon3,//"���! �� ���찳!\n����� �ϳ����� �������� �� �˾Ҵµ� ���� ã�ұ���!",
            ribbon4,//"���� ����. ����, �Ʊ� ���ߴ� ���� 3��!",
            null,//"���� 3���� �����.",
            ghost9,//"�������ʹ� 2���ֵ��� �������� �ʵ� ���� �ο�.,",
            ghost11,//"�̹� �ͽ��ε� �� �ױ�� �ϰھ�?",
            ribbon5,//"����. �˾Ҿ�.",
            ribbon3,//"�׷��� 2�� �ͽŵ� ������ ȥ������ ��.\n���� ���� ���� �ޱ⵵ �ϰŵ�.",
            ghost4,//"�׷��ٸ��, ��...",
            ribbon5,//"�ٵ� �� ��! ���찳 ã���� �� ��¥ ����!",
            player10//"�׷�, �ʵ� �� �־�!",
        });

        ImageData.Add(200, new Sprite[]
        {
            ribbon5//"2�� ���� ���� �� �������� �� �ɾ�� ��!"
        });

        ImageData.Add(201, new Sprite[]
        {
            ribbon1//"��½��½"
        });

        ImageData.Add(21, new Sprite[]
        {
            player9,//"�׷��� ����, ����� �� ����ġ�� ���� �ߴµ�.",
            player5,//"�׶� ���� ��Ҵ� �ֵ�, �� ������ ��������?",
            ghost11,//"�ñ��ϸ� �ٽ� �����ϸ� ����.",
            player13,//"��... ������ ������ �׶�ó�� ������ ���ϴϱ�.",
            player6,//"������ �ǵ��ư��� ���ϴ� �����̿���\n�� �ູ�ϰ� ���Ҵ� ������� ���� �� �ƴұ�?"            
        });

        ImageData.Add(22, new Sprite[]
        {
            null,//"�ű� ���!",
            null//"����ǰ �˻簡 �ְڴ�!"
        });

        ImageData.Add(23, new Sprite[]
        {
            cap1,//"�ƴ�! �̰�...!\n���� �Ҿ���ȴ� ����!",
            glass1,//"����! ��ģ �ž�?",
            cap2,//"�뼭�� �� ����!",
            ghost14//"�ƴ�, �ظ��� ��ȸ�� ��� �� �� �ƴϾ�!"
        });

        ImageData.Add(24, new Sprite[]
        {
            cap3,//"����, �̷��� ���� �༮�� �츮 ������ ���İ� �ž�?",
            glass2//"���� �̻��ϳ�.",
        });

        ImageData.Add(25, new Sprite[]
        {
            cap4,//"ũ��, �츮�� ���ٴ�...!",
            glass2//"���ϴ�!",
        });

        ImageData.Add(26, new Sprite[]
        {
            //player5,//"���� �츮 ��⵵ ����ٷ�?",
            ghost15,//"�¾�, �� ������ �츮�� ��ģ �� �ƴϾ�.\n1�� �ͽ��� �ذŶ�!",
            glass1,//"1�� �ͽ���?",
            cap5,//"��!",
            glass3,//"��?",
            cap6,//"�̰� ���� ������ 1������ �Ҿ���ȴ� �ž�.\n��Ծ�����.",
            glass4,//"...",
            ghost14,//"...",
            player5,//"�츰 ���� ������.\n���� �ö� �����̾��ŵ�.",
            glass3,//"����? 3���� �鸣�� �ž�?",
            ghost4,//"��?",
            cap7,//"��, ��� 3�� �ͽ��̾�.",
            cap6,//"�ͽ� ���̼� 1��, 2��, 3���� �þƼ� \n���ǿ��� ����� �� �ϴ��� �����ϴ� �� �츮 ���̾�.",
            glass5,//"���� ����ִ� ����� ���� �����ϱ� �ɽ��ؼ� 2������ �����.",
            glass3//"�ʳװ� 3�� ���ǿ� �鸣��,\n���� ���� �ö󰬴� �ñ� �ؼ�."
        });

        // ���� ��
        // ��忣�� ��Ʈ
        ImageData.Add(27, new Sprite[]
        {
            player2,//"���� 3���� �鷯�� �� �ʿ�� ����?",
            ghost11,//"��. ������ ������ ���� ���� �����ϱ�!",
            glass6,//"���� �����̾�! ������ 3������ ����� ���ǹۿ� ���ŵ�.",
            glass7,//"����, ���찳, ����, �������, ��ü ���� ���� �� ���̾�.",
            player8,//"�׷�����.",
            ghost2,//"���� �������. �������� ���տ� �ִٱ�!",
            cap6,//"�ٵ� �� ��! �ʳ׶� ����ġ�� ��վ���!",
            glass6,//"�ȳ�!",
            ghost1,//"�� �־�!",
            player12//"�ȳ�!"
        });

        // 3���� �鸥��.
        ImageData.Add(28, new Sprite[]
        {
            player8,//"3���� ���ƺ��� �;�.",
            cap8,//"�ϱ�,\n���� 10�� �����̳� ������ �ִ� �� ���� �ʹ��� �� ���⵵ �ϴ�. ",
            glass5,//"�׷���...\n�׷��� �ʳ� ������ �ְ� ���� �ƹ� �� ������ �ٷ� ������ �ž�.",
            ghost11,//"�׷��׷�.",
            cap6,//"�� �� �� ��!\n�ʳ׶� ����ġ�� ��վ���!",
            ghost1,//"�� �־�!",
            player12,//"�ȳ�!",
        });

        // 3���� �ö�ͼ�
        ImageData.Add(29, new Sprite[]
        {
            glass3,//"���� ��¥ �� �� ����.",
            glass7,//"�׷��� �Ұ����ڸ� ������ 5�г� �����̰� �Ʒ����� 6�г� �����̾�.",
            glass6,//"������ ���� �� �̻� �ƹ� ����� �� �� �״ϱ� ������� �ᵵ ������.",
            glass7,//"�� ���� ����?\n���� �� �˾Ƽ� ������ ��!",
            player14,//"�׷�, ���� �ö���༭ ����.",
        });

        // å���� �߰�
        ImageData.Add(30, new Sprite[]
        {
            player1,//"��! �̰� ������ �Ҿ���ȴ� ���ݾ�?",
            ghost4,//"����� �� �Ҿ� ���ȴ� �� ���ݱ��� �����?",
            player5,//"��, \n�׶� ģ������ ���� ģ���� �־��µ� �� �ְ� ���ϼ����� �� �ſ��ŵ�.",
            player13,//"������ �̰� Ư���� �����̾�.",
            player5//"�׷��Գ� ���Ҿ��µ� �ʹ� �����Ǿ����� ���� ����� �� ����."
        });

        // ������ ���캸���� ���
        ImageData.Add(31, new Sprite[]
        {
            player6,//"�� 6�г� ��ü ������ �� ���� ����?",
            ghost4//"��, �� ����... ���.",
        });
        ImageData.Add(311, new Sprite[]
        {
            ghost10,//"�׷�, �¾�. ����...",
            player15,//"����?",
            ghost4,//"��?",
            ghost13,//"��....�ƴ�! ���� ������!",
            ghost11,//"���� ��¥ �������� ���� �������̳�!",
            player13,//"�׷���.",
           player10,// "���� ���� �����̱� ������ �׷��� �� �������� ������� ���� ������� �ž�.",
            player14,//"�������� ����� �����༭ ����.",
            ghost10,//"��....",
            ghost12//"���� ���� ���� �����̾�!"
        });

        // ��忣��
        ImageData.Add(32, new Sprite[]
        {
            ghost2,//"���� ���� ���� ���̾�!",
            ghost9,//"���� ���� ������ ���� ��...",
            player9,//"���� ȭ�ܿ� ������ �ִ� ���� �?",
            ghost2,//"����!"
        });
        ImageData.Add(320, new Sprite[]
        {
            ghost11,//"���� �غ�ƾ�!",
            player8,//"���� ��� ������ ����",
        });
        ImageData.Add(321, new Sprite[]
        {
            ghost4,//"��? ���!",
            ghost3,//"�и��� �� ���� �־��µ�?",
            ghost10//"�� �� ����!"
        });
        ImageData.Add(322, new Sprite[]
        {
            player12,//"�츮 �����߾�!\n�� �ɹ����� �̾����� �� �̾�����.",
            player14//"���� �ɵ� ���⼭ ���� �ǰ�?"
        });

        ImageData.Add(323, new Sprite[]
        {
            player14,//"�츮 �����߾�!\n�� �ɹ����� �̾����� �� �̾�����.",
            player16,//"���� �ɵ� ���⼭ ���� �ǰ�?"
            player15
        });

        ImageData.Add(33, new Sprite[]
        {
            Reaper1,//"���� ���� �Ǵ°�?",
            ghost4,//"��...��������?",
            Reaper2,//"���� �ʸ� ��������� �ߴ� ���»��ڴ�.",
            Reaper1,//"�װ� ��踦 ����� �ٶ��� �ٷ� �������� ������ ���� ������.",
            Reaper2,//"�̷��� ��谡 �ٽ� �����⵵ �幮 ���ε�...\n���� ���ұ���.",
            player11,//"���?",
            Reaper1,//"����� ���� �Ŀ� �ڽ��� ���������� �ذ� �ȴٸ�\n������ ��� ��ҷ� ������ ��踦 ����� ����.",
            Reaper2,//"�ڽ��� ������ �ٽ� �˰� �ȴٸ�\n���»��ڰ� ��迡 ���� �� ������,",
            Reaper1,//"�׷� ���� ��ġ �ʾ�.",
            player12,//"�׷� ��, ����� �� ���ž�?",
            ghost12,//"��... �̾�,\n���� ���������� �� ������ �� ����.",
            player11,//"��?",
            ghost3,//"������� �� ģ�������� �� �ߴµ� �ͽ��� �Ǿ��,",
            ghost10,//"�װ͵� �ƹ� ��ﵵ ���� ���·�\n������ ���� �ɰ� ���� �����ڰ� �ߴ� �� â����.",
           ghost12,//"�Դٰ� ���� �ͽ��� ���·� ���� ���ݾ�?\n�װ� �Ⱦ�!",
            player5,//"�˾Ҿ�. �׷��� �� �� ���� ����.",
            player13,//"�� ���� ���� �� �ǵ� ��ȸ�� �� ����� ���� �� ���ݾ�.",
            Reaper2,//".... �ڳ״� �� ����ΰ�, ���� ����ΰ�?",
            player6,//"�׾� �翬�� ����ִ� ���...",
            Reaper2,//"�� ����̱⿣ ��迡 ���� ���� ����\n���� ����̱⿣ �ͽ��� ���·� ������ �ʾ�����,",
            Reaper1,//"������ ��°�� ���� �����ϳ�.",
            player16,//"...",
            Reaper2,//"�Դٰ� ��迡�� ���� �� �ִ� ��δ� ����,\n�� �������� ���� ���¹� ���̾�.",
            Reaper1,//"���¹����� �������� �Ǹ� Ȯ���ϰ� �װ� �Ǵ�, \n��� �� ������ �� �����غ���.",
            Reaper2,//"�ͽ��� ���¹����� �� �Ŀ� \n��谡 ���� �Ǵ����� �˷����� �ʴٸ�...",
            ghost12,//"����, ��ø� ���̼� ��⸦ ������ �ɱ��?",
            Reaper1//"�׷�, ����� ���� �ٽ� ������ ���� �ɵ��� �ϰ�."
        });

        ImageData.Add(34, new Sprite[]
        {
            ghost12//"���ݾ�, �� ��� �� �����̾�?"
        });
        // �ʶ� ���� �� �����̾�.
        ImageData.Add(340, new Sprite[]
        {
            ghost4,//"...��?",
            player6,//"��迡 �������� ��� ���� �𸥴ٰ� �ϴϱ�...",
            player5,//"ȥ�� �������� �� ���ٴ� �ʶ� ���� ���� �� �� ���� ������?",
            ghost10,//"�׷���� ������...\n���� ���� ���ٸ� ��Ե� ��Ƴ� ���ɼ��� �������� ���ݾ�.",
            ghost3,//"��¥ �����ھ�? ���¹��� ������ ��¥ ���¿� ���� �ž�.",
            player4,//"...",
            ghost12,//"���� ������ �ʰ� ���⿡ �������� ���ھ�.",
            ghost10,//"��å���� ���̱�� ������ Ȥ�ö� �ʰ� ���� �� �ƴ϶��",
            ghost12,//"�׷��ٸ�, ���� ���¿� ���� ��谡 ��������",
            ghost13,// "�ʵ� �� �������� ���Ƿ� �ڿ������� ���� �� �ְ� �Ǵ� �� �ƴұ�?",
            player16,//"��... ",
            ghost4,//"���� ���鼭 �ʰ� �׷� ���� ���ݾ�? ",
            ghost12,//"\"������ �ǵ��ư��� ���ϴ� �����̿��� �� �ູ�ϰ� ���Ҵ� ������� ���� �� ����\"",
            ghost13,//"���� �׷��� ������ ���Ҵ� �߾����� ���� �;�.",
            ghost11,//"�ʰ� ����־����� ���ھ�.",
            ghost12//"��谡 ��� ���� �𸣰�����...\n���¹����� ���� ��¥�� �ʰ� �״°��ݾ�."
        });

        ImageData.Add(3400, new Sprite[]
        {
            player8,//"�׷��� �� �ʶ� ���� ����.",
            player5,//"���� �ִٰ� ���� ��迡 ������ �Ǹ� ���⼱ �ƹ��͵� ���ϰ� ���ݾ�.",
            player9,//"������ �״� �Ŷ� �ٸ����� ��Ȳ�̶�� �� �ʶ� ���� ���� �� �� ����.",
            ghost3//"�� �׷��ٸ� �˾Ҿ�...",
        });

        ImageData.Add(3401, new Sprite[]
        {
            player5,//"...�˾Ҿ�. ���� ����������.",
            ghost11//"����! �ʰ� �� ��Ƴ��� �ٶ���.",
        });

        ImageData.Add(341, new Sprite[]
        {
            ghost11,//"����! �ʰ� �� ��Ƴ��� �ٶ���.",
            ghost13,//"����̸� �ʰ� � �� ���� ��Ҵ� �ֵ�ó��\n���� �׷��� ����� ������ ���ھ�...!",
            player10//"��. �׷���.\n�ʵ� �����ؼ� ��."
        });

        ImageData.Add(350, new Sprite[]
        {
            Reaper2,//"���� ���ߴ°�.",
            player8,//"�� ���� ���� �� �ſ���.",
            Reaper2//"�׷� ������ ����."
        });
        ImageData.Add(3500, new Sprite[]
        {
            player16,//"...",
            player8,//"���� ����"
           
        });
        ImageData.Add(351, new Sprite[]
        {
            Reaper2,//"���� ���ߴ°�.",
            player5,//"�� ���� �����ֱ�� �����߾��.",
            Reaper2,//"�׷� ������ ����.",
            ghost13,//"�� ��Ƴ��ƾ� ��...! �ʸ� �ٽ� ������ ��ſ���.",
            player13//"��. �ʵ� ������ ��."
        });

        ImageData.Add(352, new Sprite[]
        {
            null,
            player1,//"��? ������...?",
            null,//"º!\n�� �ʶ� ���� ���� �ٴϴ� �� �ͽ��̾�!",
            null,//"���� ���������� �ٲ���ٱ�!",
            player9,//"�� Ȥ��...\n�Ʊ� ��ü�������� �ô�, ��...",
            null,//"�¾�! �� 000�̾�!",
            player10,//"�������̴�! �� ��¥ 6�г⶧ ��� �״�γ�?",
            null//"��! �������ڸ��� �׾��ŵ�."
        });

        ImageData.Add(36, new Sprite[]
        {
            player6,//"��¥ ���⿡ ���� �ǰ�?",
            null,//"...��! ������ ���?",
            player16//"��? �� �̸��� �鸰�� ���Ҵµ�?",
        });

        ImageData.Add(37, new Sprite[]
        {
            null,//"������ ���?",
            player1,//"����?",
            null//"���̰�. ���� �츮�̳�. �����մϴ�. �����մϴ�...\n�츮 �Ƶ� ����ּż� �����մϴ�."
        });

        ImageData.Add(38, new Sprite[]
        {
            null,
            null,
            null,
            null,//"���� ���븦 �ϴ� �������� �θ�� ���� �鸣�� �濡 ������ ���ߴ�.",
            null,//"�װ��� 10�� �� ������ ������� ����ڰ� ���� �� �ִ� ���̶� �Ѵ�.",
            null,//"���� ��迡�� ���� �ͽ��� ������,\nȤ�� ���� �ƴ� �ְ� ��� ���ߴ��� ����ô�.",
            null,//"�� �ִ� ���� 5�г� �� ���� �ݿ� ���� �Դ� ģ����� �ϼ̴�.",
            null,//"������� �츮������ �̻� �� ���� ���̾��� ������\n���� ��� ������� �� ����� ����� ���� �����̴ٰ� �ϼ̴�.",
            null//"�׸��� 2�� �� �� �������� ����ߴ�."
        });
    }

    /* ���̾�α� ID�� ���� ĳ���� ǥ�� ���� */
    Sprite GetTalk(int id, int talkIndex)
    {
        if (talkIndex == ImageData[id].Length)
            return null;
        else
            return ImageData[id][talkIndex];
    }
}