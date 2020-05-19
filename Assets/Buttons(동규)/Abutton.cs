using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Abutton : MonoBehaviour, IPointerClickHandler
{
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("버튼눌렀습니다");
        //// player오브젝트안의 HpRecovery메소드실행: 실제hp회복
        GameObject.Find("Player").SendMessage("HpRecovery"); 
        // 오른쪽상단의 hp체력바이미지회복 
        GameObject.Find("HpGauge").GetComponent<HpBar>().IncreaseHp();
    }



    






}
