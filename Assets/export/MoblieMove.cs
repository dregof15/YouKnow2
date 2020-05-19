using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoblieMove : MonoBehaviour
{
        private Animator animator;
   
    private const string key_isRun = "IsRun";
    private const string key_isAttack01 = "IsAttack01";
    private const string key_isAttack02 = "IsAttack02";
    private const string key_isJump = "IsJump";
    private const string key_isDamage = "IsDamage";
    private const string key_isDead = "IsDead";
    private const string IsFire = "isFire";
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
    static public bool isfire = false;
    FloatingJoystick FloatingJoystick;
    bl_Joystick bl_Joystick;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        this.animator = GetComponent<Animator>();
        FloatingJoystick = FindObjectOfType<FloatingJoystick>(); // 이동
        bl_Joystick = FindObjectOfType<bl_Joystick>(); //공격
    }
    void Update()
    {
        // this.animator.SetBool(key_isRun, true);    

        //this.animator.SetBool(key_isAttack02, true);
        //this.animator.SetBool(key_isJump, true);
        //this.animator.SetBool(key_isDamage, true);
        //this.animator.SetBool(key_isDead, true);
       
    }
    private void FixedUpdate()
    {
        Run();
        turn();
        aturn();
        move();
    }
    void move()
        {
        horizentalMove = FloatingJoystick.Horizontal;
        verticalMove = FloatingJoystick.Vertical;
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
        if(isMove == false || isfire == true)
            return;

        Quaternion newRotation = Quaternion.LookRotation(movement);
        rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, newRotation, rotateSpeed * Time.deltaTime);

    }
    void aturn()//공격
    {
        Fhorizontal = bl_Joystick.Horizontal;
        Fvertical = bl_Joystick.Vertical;
        //if ((Input.GetButton("Fire1") == true) || (FixedJoystick.Horizontal > 0.5 || FixedJoystick.Horizontal< -0.5 || FixedJoystick.Vertical> 0.5 || FixedJoystick.Vertical< -0.5))//공격 설정, 조이스틱이 반이상 당겨지면 공격 pc  
            if(Fhorizontal > sensi || Fhorizontal < -sensi || Fvertical > sensi || Fvertical < -sensi)//모바일
        {
            this.animator.SetBool(IsFire, true);
            isfire = true;
            //animator.Play("Attack01", -1, 0);
            fmovement.Set(Fhorizontal, 0, Fvertical);//공격방향으로 회전
            fmovement = fmovement.normalized* speed * Time.deltaTime;
            Quaternion newRotation2 = Quaternion.LookRotation(fmovement);
    transform.rotation = Quaternion.Slerp(rigidbody.rotation, newRotation2, rotateSpeed* Time.deltaTime);
        }
        else
        {
            this.animator.SetBool(IsFire, false);
isfire = false;
        }
}

}