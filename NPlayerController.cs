/********************************************************************************
* @file         NPlayerController.cs                                            *
* @details      노멀 모드에서 플레이어를 관리하는 스크립트.                     *
*               스페이스바를 누르면 점프/더블 점프 가능                         *
*               플레이어의 HP bar가 플레이어 머리 위에 따라다니도록 함          *
*               장애물과 충돌할 시 효과음과 함께 알파값이 변하는 충돌 효과 발생 *
*                                                                               *
* ⓒ made by FellowFollow                                                       *
********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPlayerController : MonoBehaviour
{
    private GameObject HPbar;
    private GameObject game;

    Rigidbody2D rigid2D;
    Animator animator;
    SpriteRenderer spriteRender;
    float jumpForce = 410.0f;

    bool isGround;
    [SerializeField]
    Transform pos;
    [SerializeField]
    float checkRadius;
    [SerializeField]
    LayerMask islayer;

    public int jumpCount;
    int JumpCnt;

    public AudioClip clip;

    void Start()
    {
        this.HPbar = GameObject.Find("Canvas/Slider");
        this.game = GameObject.Find("NormalModeDirector");
        this.animator = GetComponent<Animator>();
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.spriteRender = GetComponent<SpriteRenderer>();

        JumpCnt = jumpCount;
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics2D.OverlapCircle(pos.position, checkRadius, islayer);

        if (isGround == true && Input.GetKeyDown(KeyCode.Space) && JumpCnt > 0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }
        if (isGround == false && Input.GetKeyDown(KeyCode.Space) && JumpCnt > 0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            JumpCnt--;
        }
        if (isGround)
        {
            JumpCnt = jumpCount;
        }

        HPbar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0.5f, 2.8f, 0));
    }

    private void FixedUpdate()
    {
        float hor = Input.GetAxis("Horizontal");
        rigid2D.velocity = new Vector2(hor * 3, rigid2D.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Ondamaged();
        }
    }

    void Ondamaged()
    {
        SoundManager.instance.SFXPlay("Attacked", clip);
        spriteRender.color = new Color(1, 1, 1, 0.4f);

        Invoke("OffDamaged", 0.5f);
    }

    void OffDamaged()
    {
        spriteRender.color = new Color(1, 1, 1, 1);
    }
}
