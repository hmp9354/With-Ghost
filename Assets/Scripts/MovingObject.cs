using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float force = 0.02f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        /* 누른 키 받아오기 */
        if (Input.GetKey(KeyCode.LeftArrow))
        {            
            animator.SetFloat("DirX", -1);
            animator.SetFloat("DirY", 0);
            animator.SetBool("Walking", true);
            this.transform.Translate(new Vector3(-force, 0, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {            
            animator.SetFloat("DirX", 1);
            animator.SetFloat("DirY", 0);
            animator.SetBool("Walking", true);
            this.transform.Translate(new Vector3(force, 0, 0));

        }
        if (Input.GetKey(KeyCode.UpArrow))         // 위로 이동하는것을 앞으로 이동한다고 봄
        {
            animator.SetFloat("DirX", 0);
            animator.SetFloat("DirY", 1);
            animator.SetBool("Walking", true);
            this.transform.Translate(new Vector3(0, force, 0));

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetFloat("DirX", 0);
            animator.SetFloat("DirY", -1);
            animator.SetBool("Walking", true);
            this.transform.Translate(new Vector3(0, -force, 0));

        }

        if ((Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow)))
        {        
            animator.SetBool("Walking", false);
        }
    }

    
}
