using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{

    // Animator 
    private Animator animator;
    //FloatingJoystick joy = new FloatingJoystick();

    //public FloatingJoystick joystick;//이동조이스틱
    //public FixedJoystick Fjoy;

    private const string key_isRun = "IsRun";
    private const string key_isAttack01 = "IsAttack01";
    private const string key_isAttack02 = "IsAttack02";
    private const string key_isJump = "IsJump";
    private const string key_isDamage = "IsDamage";
    private const string key_isDead = "IsDead";
    //private const string IsFire = "isFire";
    // 初期化メソッド
    public float speed = 3f;
    public float jumpPower = 5f;
    public float rotateSpeed = 3f;
    public float sensi = 0.5f;
    Rigidbody rigidbody;

    Vector3 movement;
    Vector3 fmovement; //공격조이스틱
    float horizentalMove;
    float verticalMove;
    float Fhorizontal;//공격조이스틱
    float Fvertical;
    bool isMove;
    bool isJumping;
    bool isShoot;
    bool isfire;
   // bool isFire;
    FloatingJoystick FloatingJoystick;
    FixedJoystick FixedJoystick;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        this.animator = GetComponent<Animator>();
        FloatingJoystick = FindObjectOfType<FloatingJoystick>(); // 이동
        FixedJoystick = FindObjectOfType<FixedJoystick>(); //공격
    }
    void Update()
    {
        // this.animator.SetBool(key_isRun, true);    

        //this.animator.SetBool(key_isAttack02, true);
        //this.animator.SetBool(key_isJump, true);
        //this.animator.SetBool(key_isDamage, true);
        //this.animator.SetBool(key_isDead, true);
        horizentalMove = FloatingJoystick.Horizontal2();
        verticalMove = FloatingJoystick.Vertical2();        
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
    private void FixedUpdate()
    {
        Run();
        turn();
        aturn();
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
        if(isMove == false || isfire == true)
            return;

        Quaternion newRotation = Quaternion.LookRotation(movement);
        rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, newRotation, rotateSpeed * Time.deltaTime);

    }
    void aturn()//공격
    { 
        Debug.Log("d");
    //if ((Input.GetButton("Fire1") == true) || (FixedJoystick.Horizontal > 0.5 || FixedJoystick.Horizontal< -0.5 || FixedJoystick.Vertical> 0.5 || FixedJoystick.Vertical< -0.5))//공격 설정, 조이스틱이 반이상 당겨지면 공격 pc
            if(FixedJoystick.Horizontal > sensi || FixedJoystick.Horizontal < -sensi || FixedJoystick.Vertical > sensi || FixedJoystick.Vertical < -sensi)//모바일
        {
            Debug.Log("뺌");
            this.animator.SetBool("isFire", true);
            isfire = true;
            //animator.Play("Attack01", -1, 0);
            fmovement.Set(FixedJoystick.Horizontal, 0, FixedJoystick.Vertical);//공격방향으로 회전
            fmovement = fmovement.normalized* speed * Time.deltaTime;
            Quaternion newRotation2 = Quaternion.LookRotation(fmovement);
    transform.rotation = Quaternion.Slerp(rigidbody.rotation, newRotation2, rotateSpeed* Time.deltaTime);
        }
        else
        {
            Debug.Log("WW");
            this.animator.SetBool("isFire", false);
            isfire = false;
        }
}

}