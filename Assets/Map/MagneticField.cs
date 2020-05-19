using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagneticField : MonoBehaviour
{
    static public float r1;
    static public float temp;
    static public bool fieldstop = true;
    public float count = 0; // 자기장을 멈추는 시간
    float time = 0; // 게임 시작후 다음 자기장까지의 시간
    public Text MFcount; // 다음 자기장 까지의 시간 표시
    GameObject player = null;
    int a = 20;
    
    void Start()
    {
        r1 = 2000f; // 시작할때 자기장 크기
        this.player = GameObject.Find("Player");
        count = 10;
        StartCoroutine("RunFadeOut");
        temp = r1/2;
        time = count;
    }
    
    void Update()
    {
        if (fieldstop == false) // 자기장이 예비 자기장 까지 줄어들었는지 확인
        {
            MFcount.text = "자기장이 줄어드는 중입니다...";
            if (r1 > temp) // 보이는게 작아짐
            {
                r1 -= 0.2f;
                transform.localScale = new Vector3(r1, r1, r1);
            }
            else
            {
                temp = temp / 2; // 자기장 크기가 일정크기만큼 줄어들때 멈춤
                fieldstop = true;
                time = time / 2; // 다음 자기장까지의 시간
                count = count/2; // 자기장이 멈추는 시간 갈수록 줄어들게함
                time = count;
            }               // 이유는 자기장이 줄어드는 시간도 count 시간으로 인식해서임
        }
        else
        {
            if(time >= 0)
            {
                MFcount.text = "MF count down : " + time.ToString("00");// 다음 자기장까지 시간 표시
                time -= Time.deltaTime; // 초당 시간 줄어드는 코드
            }
        }
    }

    IEnumerator RunFadeOut() // 예비 자기장까지 줄어들었을 경우 일정시간후 다시 작아짐 // 여기 수정 필요
    {
        while(true)
        {
            yield return new WaitForSeconds(count); // 5초간 자기장이 멈춤
            fieldstop = false;
        }
    }

    //성현이 안녕 이게마지막이다
}
