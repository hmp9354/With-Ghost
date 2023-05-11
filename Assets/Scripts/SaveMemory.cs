using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMemory : MonoBehaviour
{
    /* ��� ���̾�α� ID */
    static public int Id = 1;
    static public int talkIndex = 0;

    /* ���丮 ���� �� ���� �б� */
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

    /* �ൿ �� ���ǿ� ���� �б� */
    static public int roomDoor = 0;     // 0 -> �� ó�� ����. 1 -> ����ִ� ��. 2 -> ����ȹ�� �� ��. 3 -> �� �ı�.
    static public int findKey = 0;      // 0 -> ������ Ű ã��. 1 -> ������ ó�� ����. 2 -> �ܼ� ȹ��.
    static public bool lookWindow = false;
    static public int findEraser = 0;   // 0 -> �������� ����. 1 -> å��(����) ���� �� 1�� �����. 
    static public bool findEraserUp = false;
    static public bool findEraserDown = false;
    static public bool dontGo3 = false;
    static public bool findBook = false;
    static public bool findPicture = false;

    /* ���� ���� ��Ȳ */
    static public bool talking = true;
    static public bool showing = false;
    static public bool selecting = false;

    static public Vector3 player;

    private void Awake()
    {
        talking = true;
    }
}
