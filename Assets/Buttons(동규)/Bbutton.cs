using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Bbutton : MonoBehaviour, IPointerDownHandler,IPointerClickHandler, IPointerUpHandler
{
    
    public bool check = true;
    private bool isBtnDown = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(check == true) // 무한딜레이방지
        {
            check = false;
            StartCoroutine(WaitForIt());
            
        }
        
        
    }
    public void Update()
    {
        if (isBtnDown)
        {
            Debug.Log("BTN DOWN");
        }
        else if (isBtnDown == false)
        {
            Debug.Log("BTN Up");
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isBtnDown = true;
        StartCoroutine(WaitForIt2());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isBtnDown = false;
    }

    IEnumerator WaitForIt()
    { //3초뒤에 원래 연사력으로 복귀
        GameObject.Find("Player").GetComponent<FireCtrl>().FireDelay = GameObject.Find("Player").GetComponent<FireCtrl>().FireDelay / 2f;
        yield return new WaitForSeconds(3.0f);
        GameObject.Find("Player").GetComponent<FireCtrl>().FireDelay = GameObject.Find("Player").GetComponent<FireCtrl>().FireDelay * 2f;
        yield return new WaitForSeconds(10.0f);//스킬쿨타임10초
        check = true;
    }

    IEnumerator WaitForIt2()
    {
        yield return new WaitForSeconds(2.0f);
        isBtnDown = false;
    }


    
}
