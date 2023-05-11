using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PastImage : MonoBehaviour
{
    public Sprite roomDoor;
    Sprite[] pastImage;            

    public Sprite getPastImage(int index)
    {
        return pastImage[index];
    }
}
