using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimagnetic : MonoBehaviour
{
    static public float r1;
    static public float temp;
    static public bool fieldstop = true;
    public int count = 0;
    public int time = 0; // 자기장 게임 시작후 멈춰있는 시간
    GameObject player = null;

    void Start()
    {
        r1 = 2000f; // 시작할때 자기장 크기
        this.player = GameObject.Find("Player");
        count = 10;
        StartCoroutine("RunFadeOut");
        temp = r1 / 2;
    }

    void Update()
    {
        if (fieldstop == false) // 자기장이 예비 자기장 까지 줄어들었는지 확인
        {
            if (r1 > temp) // 보이는게 작아짐
            {
                r1 -= 0.2f;
                transform.localScale = new Vector3(r1,10,r1);
            }
            else
            {
                temp = temp / 2; // 자기장 크기가 일정크기만큼 줄어들때 멈춤
                fieldstop = true;
                count = count/2; // 자기장이 멈추는 시간 갈수록 줄어들게함
            }               // 이유는 자기장이 줄어드는 시간도 count 시간으로 인식해서임
        }
    }

    IEnumerator RunFadeOut() // 예비 자기장까지 줄어들었을 경우 일정시간후 다시 작아짐
    {
        while (true)
        {
            yield return new WaitForSeconds(count); // 5초간 자기장이 멈춤
            fieldstop = false;
        }
    }
}
