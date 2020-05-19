using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleAnimation : MonoBehaviour
{

    // Animator コンポーネント
    private Animator animator;

    // 設定したフラグの名前
    private const string key_isRun = "IsRun";
    private const string key_isAttack01 = "IsAttack01";
    private const string key_isAttack02 = "IsAttack02";
    private const string key_isJump = "IsJump";
    private const string key_isDamage = "IsDamage";
    private const string key_isDead = "IsDead";
    // 初期化メソッド
    public float speed = 3f;
    public float jumpPower = 5f;
    public float rotateSpeed = 3f;
    Rigidbody rigidbody;

    Vector3 movement;
    float horizentalMove;
    float verticalMove;
    bool isMove;
    bool isJumping;
    bool isShoot;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        // 自分に設定されているAnimatorコンポーネントを習得する
        this.animator = GetComponent<Animator>();
    }

    // 1フレームに1回コールされる
    void Update()
    {


        horizentalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("Attack01", -1,0);
            //this.animator.SetBool(key_isAttack01, true);
        }
        //else this.animator.SetBool(key_isAttack01, false);
        // this.animator.SetBool(key_isRun, true);    

        //this.animator.SetBool(key_isAttack02, true);
        //this.animator.SetBool(key_isJump, true);
        //this.animator.SetBool(key_isDamage, true);
        //this.animator.SetBool(key_isDead, true);
        animator.SetFloat("horizentalMove", horizentalMove);
        animator.SetFloat("verticalMove", verticalMove);
        if (horizentalMove == 0 && verticalMove == 0) //무브 검사
            isMove = false;
        else
        {
            isMove = true;
        }

        animator.SetBool("isMove", isMove);
    }
    void Run()
    {
        movement.Set(horizentalMove, 0, verticalMove);
        movement = movement.normalized * speed * Time.deltaTime;
        rigidbody.MovePosition(transform.position + movement);
        //transform.Rotate(0, movement.normalized * speed * Time.deltaTime, 0);
        //this.animator.SetBool(key_isRun, true);
    }
    void turn()
    {
        if (horizentalMove == 0 && verticalMove == 0)
            return;

        Quaternion newRotation = Quaternion.LookRotation(movement);
        rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, newRotation, rotateSpeed * Time.deltaTime);
            
    }
    private void FixedUpdate()
    {
        Run();
        turn();
    }
}