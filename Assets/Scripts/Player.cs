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
        /* 게임을 시작할 때 플레이어가 누워 있음 */
        if (!SaveMemory.gameStart)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }

        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        /* 플레이어 동작 관리 : 플레이어가 특정 지점까지 이동할 경우 이벤트 발생*/
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
        // 스토리 진행중이 아닐 때에만 캐릭터 이동 및 상호작용 가능
        if (!SaveMemory.talking && !SaveMemory.selecting && !SaveMemory.MiniGame)
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");

            int tDirX;
            int tDirY;

            // 플레이어 이동방향에 맞춰서 애니메이션 동작
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

            // Z키를 눌렀을 때 NPC 또는 아이템과 상호작용
            if (Input.GetKeyDown(KeyCode.Z) && scanObject != null)
            {
                Emanager.Action(scanObject);
            }
        }
    }

    /* Raycast를 이용해 캐릭터가 향하는 방향의 사물 확인 */
    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(h, v) * force;
        
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
            scanObject = null;

    }

    /* 특정 위치 도달 할 때(충돌 할 때) 맵 이동 */
    private void OnCollisionEnter2D(Collision2D collision)
    {        
        if (collision.collider.CompareTag("goTwo"))
        {
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
