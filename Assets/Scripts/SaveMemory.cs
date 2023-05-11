using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMemory : MonoBehaviour
{
    /* 대사 다이얼로그 ID */
    static public int Id = 1;
    static public int talkIndex = 0;

    /* 스토리 진행 및 엔딩 분기 */
    static public bool gameStart = false;
    static public bool metGhost = false;
    static public bool enterHouse = false;
    static public bool enterSchool1 = false;
    static public bool RibbonGB = false;
    static public bool enterSchool2 = false;
    static public bool metTrouble = false;
    static public bool enterSchool3 = false;
    static public bool schoolRoop = false;
    static public bool badEnding = false;
    static public bool halfHappy = false;
    static public bool trueEnding = false;

    static public bool MiniGame = false;
    static public bool MiniGameEnd = false;

    /* 행동 및 조건에 따른 분기 */
    static public int roomDoor = 0;     // 0 -> 문 처음 조사. 1 -> 잠겨있는 문. 2 -> 볼펜획득 후 문. 3 -> 문 파괴.
    static public int findKey = 0;      // 0 -> 현관문 키 찾기. 1 -> 현관문 처음 조사. 2 -> 단서 획득.
    static public bool lookWindow = false;
    static public int findEraser = 0;   // 0 -> 조사하지 않음. 1 -> 책상(가방) 조사 후 1로 변경됨. 
    static public bool findEraserUp = false;
    static public bool findEraserDown = false;
    static public bool dontGo3 = false;
    static public bool findBook = false;
    static public bool findPicture = false;

    /* 게임 진행 상황 */
    static public bool talking = true;
    static public bool showing = false;
    static public bool selecting = false;

    static public Vector3 player;

    private void Awake()
    {
        talking = true;
    }
}
