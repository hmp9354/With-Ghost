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
        /* 캐릭터 이동 및 Walking 애니메이션 동작 */
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
        if (Input.GetKey(KeyCode.UpArrow))
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

        /* 캐릭터가 정지했을 때 애니메이션 동작 멈춤 */
        if ((Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow)))
        {
            animator.SetBool("Walking", false);
        }
    }
}
