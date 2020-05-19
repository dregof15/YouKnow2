using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ZombieMagneticCheck : MonoBehaviour
{
    private bool Attack = false; // 자기장에 닿였는지 확인
    GameObject Field = null;
    public float ZombieHp = 100f; // 좀비 Hp
    bool eachZombieDeadCheck = true;
    Animator ani;
    private const string bulletTag = "BULLET";
    private GameObject bloodEffect;

    public GameObject itemA;
    public GameObject itemB;

    void Start()
    {
        this.Field = GameObject.Find("Field");
        StartCoroutine("RunFadeOut");
        ani = GetComponent<Animator>();
        bloodEffect = Resources.Load<GameObject>("BulletImpactFleshBigEffect");

        GameObject.Find("Player").SendMessage("SpawnGreen"); // 클론에 포션넣기 
    }

    void Update()
    {
        Vector3 p1 = transform.position; // 좀비 위치
        Vector3 p2 = this.Field.transform.position; // 자기장 위치
        float d = Vector3.Distance(p1, p2); // 자기장 중심과 좀비 사이의 거리

        if (MagneticField.r1 / 2 <= d) // 지름이라 2를 나눔
            Attack = true; // 자기장 밖인지 확인용
        else
            Attack = false;

        if (ZombieHp <= 90f && eachZombieDeadCheck) // 좀비 사망!!!!! eachZombieDeadCheck가 없으면 죽었을때 카운트가 계속 내려감
        {
            ani.SetBool("isDead", true); // 공격 애니메이션
            ZombieNav.zombieDeadCheck = true; // 좀비 사망체크.
            Debug.Log("좀비 죽음 죽음 죽음 죽음");

            Instantiate(itemA, this.gameObject.transform.position, Quaternion.identity); // 클론앞에 초록포션소환
            Instantiate(itemB, new Vector3(this.gameObject.transform.position.x + 2f, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity); // 클론앞에 빨간포션소환
            Destroy(this.gameObject, 5f); // 2초뒤에 오브젝트 삭제
            //
            //GameManager.instance.DecEnemycount();
            //충돌 해제 함수
            GetComponent<CapsuleCollider>().enabled = false;
            eachZombieDeadCheck = false;

            DontDestroyOnLoad(this); // 5.29수정
        }

    }
    IEnumerator RunFadeOut()
    {

        while (true)
        {
            if (Attack) // 자기방 밖인지 확인
            {
                ZombieHp -= 5f;
                // Debug.Log("좀비가 자기장에 맞음. HP: " + ZombieHp);
            }
            yield return new WaitForSeconds(1); // 1초마다 데미지를 입음
        }
    }
    private void OnCollisionEnter(Collision collision) // 좀비가 총알에 맞았을때
    {
        if (collision.collider.tag == bulletTag)
        {
            ShowBloodEffect(collision); // 피튀기고
            Destroy(collision.gameObject);//총알맞으면 총알삭제

            ZombieHp -= 10f;
            Debug.Log("현재피:");
        }
    }
    private void ShowBloodEffect(Collision coll) // 혈흔효과
    {
        Vector3 pos = coll.contacts[0].point;
        Vector3 _normal = coll.contacts[0].normal;
        Quaternion rot = Quaternion.FromToRotation(-Vector3.forward, _normal);

        GameObject blood = Instantiate<GameObject>(bloodEffect, pos, rot);
        Destroy(blood, 1.0f);
    }
}