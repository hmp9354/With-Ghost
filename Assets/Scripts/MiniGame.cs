using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MiniGame : MonoBehaviour
{
    // 게임 카펫
    public GameObject Carpet;
    public GameObject Carpet2;      // 플레이어 딱지들 보여줌

    // 귀신딱지 설명해주는 설명 창.
    public GameObject textUp;

    // 현재 점수박스
    public GameObject ghostBox;
    public GameObject playerBox;

    // 색깔 선택 창 ->  말그대로 선택하는 네모 박스
    public GameObject Red;
    public GameObject Blue;
    public GameObject Green;

    // 선택한 색 0->빨강 1-> 파랑 2-> 초록
    public int GhostColor;
    public int PlayerColor;

    // 선택한 딱지를 보여줌
    public Image ghostSelect;
    public Image playerSelect;

    // 딱지 스프라이트
    public Sprite sred;
    public Sprite sblue;
    public Sprite sgreen;

    // 현재 점수
    int ghostScore = 3;
    int playerScore = 3;

    // 남아있는 색깔 숫자
    int redNum = 1;
    int blueNum = 1;
    int greenNum = 1;
    int redGNum = 1;
    int blueGNum = 1;
    int greenGNum = 1;

    // 현재 해당 색깔을 쓸수 없는가
    bool redBan = false;
    bool blueBan = false;
    bool greenBan = false;
    bool redGBan = false;
    bool blueGBan = false;
    bool greenGBan = false;

    bool selectColor = false;
    public void game()
    {
        // 어떤 딱지를 못 쓰는지 판별
        if (redNum == 0) { redBan = true; }
        else { redBan = false; }
        if (blueNum == 0) { blueBan = true; }
        else { blueBan = false; }
        if (greenNum == 0) { greenBan = true; }
        else { greenBan = false; }

        if (redGNum == 0) { redGBan = true; }
        else { redGBan = false; }
        if (blueGNum == 0) { blueGBan = true; }
        else { blueGBan = false; }
        if (greenGNum == 0) { greenGBan = true; }
        else { greenGBan = false; }


        // 귀신이 딱지를 선택함.
        while (true)
        {
            GhostColor = Random.Range(0, 3);
            if (GhostColor == 0 && !redGBan)
            {
                GhostColor = 0;
                //ghostSelect.GetComponent<Sprite>());
                break;
            }
            else if (GhostColor == 1 && !blueGBan)
            {
                GhostColor = 1;
                break;
            }
            else if (GhostColor == 2 && !greenGBan)
            {
                GhostColor = 2;
                break;
            }
            else { Debug.Log("오류."); break; }
        }


    }
    // Update is called once per frame
    bool setting = false;
    void Update()
    {
        if (SaveMemory.MiniGame == true && !setting)
        {
            textUp.SetActive(true);
            ghostBox.SetActive(true);
            playerBox.SetActive(true);
            Carpet.SetActive(true);
            setting = true;
        }

        // 누가 이겼는가.
        if (ghostScore == 0)
        {
            SaveMemory.MiniGame = false;
            SaveMemory.MiniGameEnd = true;
            SaveMemory.Id = 25;
            ghostScore = 3;
        }
        else if (playerScore == 0)
        {
            SaveMemory.MiniGame = false;
            SaveMemory.MiniGameEnd = true;
            SaveMemory.Id = 24;
            playerScore = 3;
        }

        // 선택 창
        if (SaveMemory.MiniGame)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && !redBan)
            {
                Red.SetActive(true);
                Blue.SetActive(false);
                Green.SetActive(false);
                PlayerColor = 0;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && !blueBan)
            {
                Red.SetActive(false);
                Blue.SetActive(true);
                Green.SetActive(false);
                PlayerColor = 1;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && !greenBan)
            {
                Red.SetActive(false);
                Blue.SetActive(false);
                Green.SetActive(true);
                PlayerColor = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Red.SetActive(false);
            Blue.SetActive(false);
            Green.SetActive(false);

            bool win = false;
            if (selectColor)
            {
                if (PlayerColor == 0 && GhostColor == 2)
                {
                    win = false;
                    for (int i = 0; i < 5; i++)
                    {
                        int tmp = Random.Range(0, 2);
                        if (tmp == 1)
                        {
                            win = true;
                            break;
                        }
                    }
                    if (win)
                    {
                        greenNum++;
                        greenGNum--;
                    }
                    else
                    {
                        redNum--;
                        redGNum++;
                    }
                }
                else if (PlayerColor < GhostColor)
                {
                    win = true;
                    for (int i = 0; i < 5; i++)
                    {
                        int tmp = Random.Range(0, 2);
                        if (tmp == 1)
                        {
                            win = false;
                            break;
                        }
                    }
                    if (win)
                    {
                        if (PlayerColor == 1)
                        {
                            greenNum++;
                            redGNum--;
                        }
                        else
                        {

                        }
                    }
                }
            }
        }
        if (SaveMemory.showing)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                selectColor = true;
            }

        }

    }
}
