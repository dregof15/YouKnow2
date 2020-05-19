using UnityEngine;
using System.Collections.Generic;
using System.Threading;
using System.Collections;

public class ZombieCharacterControl : MonoBehaviour
{
    static public float zombieSpeed = 2f;  // 좀비스피드
    public float dis = 0;   //  좀비캐릭터 거리
    GameObject player;
    GameObject zombie;
    GameObject Hp; // 캐릭터가 좀비한테 맞았을때 hp바 줄어들게
    Animator ani;
    public bool Poweroverwhelming = false;
    public GameObject itemA;
    void Start()
    {
        player = GameObject.Find("Player");
        zombie = GameObject.Find("Zombie");
        Hp = GameObject.Find("HpGauge");
        ani = GetComponent<Animator>();
        StartCoroutine("temp");
    }

    IEnumerator temp()
    {

        while (true)
        {

            Vector3 p1 = transform.position; // 좀비 위치
            Vector3 p2 = this.player.transform.position; // 캐릭터 위치
            dis = Vector3.Distance(p1, p2); // 좀비와 캐릭터 거리

            if (dis <= 1.5f) // 거리가 3 이내일때
            {
                ani.SetBool("isAttack", true); // 공격 애니메이션
                yield return new WaitForSeconds(0.3f);

                if (dis <= 1.5f) //  0.5초 뒤에도 거리가 3일때 딜들어감
                {
                    if (Poweroverwhelming == false)
                    {
                        zombieAttack();
                        Hp.GetComponent<HpBar>().DecreaseHp();
                    }
                    //PlayerMagneticCheck.Player1Hp -= 5f; // 실질적인 hp 감소

                    // zombieAttack();//실질적인 hp 감소 동규
                    // Hp.GetComponent<HpBar>().DecreaseHp(); // 체력바 줄어들게하기 
                    //Debug.Log("캐릭터가 좀비에 맞음. HP: " + PlayerMagneticCheck.Player1Hp); // 유니티 콘솔창
                }

                ani.SetBool("isAttack", false);
                yield return new WaitForSeconds(1.7f);
            }

            // if(ZombieMagneticCheck.ZombieHp<=90f && eachZombieDeadCheck) // 좀비 사망!!!!!
            // {
            //     ani.SetBool("isDead", true); // 공격 애니메이션
            //     ZombieNav.zombieDeadCheck = true; // 좀비 사망체크.
            //     Debug.Log("좀비 죽음 죽음 죽음 죽음");
            //     Destroy(this.gameObject , 5f); // 2초뒤에 오브젝트 삭제

            //     GameManager.instance.DecEnemycount();
            //     //충돌 해제 함수
            //     GetComponent<CapsuleCollider>().enabled = false;
            //     eachZombieDeadCheck=false;
            // }

            // float xx = Random.Range (-zombieSpeed, zombieSpeed);
            // float zz = Random.Range (-zombieSpeed, zombieSpeed);
            // for(int i=0 ; i<10 ; i++){ // for문 i 범위로 이동거리 설정
            //     //transform.Translate(new Vector3(xx, transform.position.y, zz) * Time.deltaTime);
            //     transform.Translate(new Vector3(0, 0, zombieSpeed) * Time.deltaTime); // 이동!
            //     transform.Rotate(0, xx*2f, 0);  //y값만 변경시켜야함 회전하는거 랜덤임
            //     yield return new WaitForSeconds(0.0001f); // 숫자가 크면 거의 안움직임
            // }

            yield return new WaitForSeconds(0.01f); // 한번 이동하고 쉬는시간
        }
    }


    void Update()
    {
        if (PlayerMagneticCheck.Player1Hp <= 0f)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    //동규
    void zombieAttack()
    {
        GameObject.Find("Player").SendMessage("Hpdown");//실질적인 hp감소
    }






}
