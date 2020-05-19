using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    GameObject Hp2=null;
    void Start()
    {
        Hp2 = GameObject.Find("HpGauge"); // 체력바 불러오기 메인카메라 자식에 있음
    }
    
    public void DecreaseHp()
    {
        this.Hp2.GetComponent<Image>().fillAmount -= 0.05f; // 체력바 줄어드는 코드
    }

    public void IncreaseHp()
    {
        this.Hp2.GetComponent<Image>().fillAmount += 0.2f; // 체력바 줄어드는 코드
    }
}
