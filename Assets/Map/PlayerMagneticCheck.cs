using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMagneticCheck : MonoBehaviour
{
    private bool Attack = false; // 자기장에 닿였는지 확인 및 다른 스크립트와의 변수 공유
    GameObject Field = null;
    GameObject Hp = null;
    static public float Player1Hp = 100f; // Player1 Hp 전역변수 설정
    
    // Start is called before the first frame update
    void Start()
    {
        this.Field = GameObject.Find("Field");
        StartCoroutine("RunFadeOut");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p1 = transform.position; // Player 위치
        Vector3 p2 = this.Field.transform.position; // 자기장 위치
        Vector3 dir = p1 - p2;
        float d = 0;
        d = Vector3.Distance(p1, p2); // 자기장 중심과 플레이어 사이의 거리

        /*if(MagneticField.fieldstop == false)
        {
            if (MagneticField.r1 > MagneticField.temp) // if 안쓰면 보이는건 커도 실제 값은 계속 작아짐
                MagneticField.r1 -= 0.2f; // 자기장 지름을 Sphere 크기처럼 줄어들게 함
        }*/

        if (MagneticField.r1 / 2 <= d) // 지름이라 2를 나눔
            Attack = true; // 자기장 밖인지 확인용
        else
            Attack = false;
        
    }
    IEnumerator RunFadeOut()
    {

        while (true)
        {
            if (Attack == true) // 자기방 밖인지 확인
            {
                Player1Hp -= 5;
                Debug.Log("자기장에 맞음. HP: " + Player1Hp);
                // 감독 스크립트에 자기장 밖에 있다고 알려줌
                Hp = GameObject.Find("HpBar");
                Hp.GetComponent<HpBar>().DecreaseHp();
            }
            yield return new WaitForSeconds(1); // 1초마다 데미지를 입음
        }
    }
}
