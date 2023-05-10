using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject player;
    Vector3 pPosition;
    Vector3 nowPosition;

    void Start()
    {
        pPosition = player.transform.position;
    }
    
    void Update()
    {
        pPosition = player.transform.position;
        if (SaveMemory.schoolRoop)
        {

        }
        else if (SaveMemory.enterSchool1 || SaveMemory.enterSchool2)
        {
            nowPosition = pPosition;            
            nowPosition.z = -10f;

            if (nowPosition.x <= 0.1)
            {
                nowPosition.x = 0.1f;
            }
            else if (nowPosition.x >= 1.9)
            {
                nowPosition.x = 1.9f;
            }

            if (nowPosition.y <= -0.6)
            {
                nowPosition.y = -0.6f;
            }
            else if (nowPosition.y >= 2.6)
            {
                nowPosition.y = 2.6f;
            }
            transform.position = nowPosition;
        }
        else if (SaveMemory.enterHouse)
        {            
            nowPosition = pPosition;
            nowPosition.x = 0.1f;
            nowPosition.z = -10f;

            if (nowPosition.y <= -0.6)
            {
                nowPosition.y = -0.6f;
            }
            else if (nowPosition.y >= 0.6)
            {
                nowPosition.y = 0.6f;
            }           
            transform.position = nowPosition;
        }
    }
}
