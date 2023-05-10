using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public EventManager Emanager;
    public TalkManager Tmanager;

    float h;
    float v;    
    public float force = 2f;    

    Vector3 dirVec;

    GameObject scanObject;
    Rigidbody2D rigid;
    Animator animator;

    static bool metGhost = false;
    static bool houseEnter = false;    

    private void Awake()
    {
        if (!SaveMemory.gameStart)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }

        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();        
    }
    
    void Update()
    {        
        if ((!SaveMemory.metGhost) && (transform.position.x >= -2))
        {
            Emanager.meetGhost();
            SaveMemory.talking = true;
            animator.SetInteger("DirX", 0);
            animator.SetInteger("DirY", 0);
            h = 0;
            v = 0;
            SaveMemory.metGhost = true;
        }

        if (SaveMemory.enterSchool2 && !SaveMemory.metTrouble && transform.position.x >= -4.2)
        {
            SaveMemory.talking = true;
            animator.SetInteger("DirX", 0);
            animator.SetInteger("DirY", 0);
            h = 0;
            v = 0;           
        }

        if (!SaveMemory.talking && !SaveMemory.selecting && !SaveMemory.MiniGame)     // 스토리 진행중이 아닐때에만 캐릭터 이동 가능
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");

            int tDirX;
            int tDirY;

            if (animator.GetInteger("DirX") != h)
            {
                animator.SetBool("isChange", true);
                animator.SetInteger("DirX", (int)h);
            }
            else if (animator.GetInteger("DirY") != v)
            {
                animator.SetBool("isChange", true);
                animator.SetInteger("DirY", (int)v);
            }
            else
            {
                animator.SetBool("isChange", false);
            }

            tDirX = animator.GetInteger("DirX");
            tDirY = animator.GetInteger("DirY");

            if (tDirX == 1)
                dirVec = Vector3.right;
            else if (tDirX == -1)
                dirVec = Vector3.left;
            else if (tDirY == -1)
                dirVec = Vector3.down;
            else if (tDirY == 1)
                dirVec = Vector3.up;

            if (Input.GetKeyDown(KeyCode.Z) && scanObject != null)
            {
                Debug.Log("스캔 오브젝트는 눌렸다");
                Emanager.Action(scanObject);
            }
        }        
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(h, v) * force;        

        // 스캔할 때는 Ray를 쓴다. 오브젝트를 스캔
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if(rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else       
            scanObject = null;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("goTwo")){
            if (SaveMemory.RibbonGB)
            {
                SaveMemory.enterSchool2 = true;
                SceneManager.LoadScene("School2");
            }            
        }
        else if (collision.collider.CompareTag("goTree"))
        {
            if (SaveMemory.dontGo3)
            {
                SaveMemory.Id = 32;
                SaveMemory.schoolRoop = true;
                SceneManager.LoadScene("SchoolRoop");
            }
            else
            {
                SaveMemory.enterSchool3 = true;
                SceneManager.LoadScene("School3");
            }
        }
        else if (collision.collider.CompareTag("goRoop"))
        {
            if (SaveMemory.findPicture)
            {
                SaveMemory.Id = 33;
                SaveMemory.schoolRoop = true;
                SceneManager.LoadScene("SchoolRoop");
            }
            else
            {
                SaveMemory.Id = 32;
                SaveMemory.schoolRoop = true;
                SceneManager.LoadScene("SchoolRoop");
            }
        }
    }
}
