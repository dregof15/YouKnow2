using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Cbutton : MonoBehaviour, IPointerClickHandler
{

    public bool check = true;
    
    public void OnPointerClick(PointerEventData eventData)
    {

        if (check == true) // 무한딜레이방지
        {
            check = false;
            StartCoroutine(PowerOverwhelming());

        }
    }

    IEnumerator PowerOverwhelming()
    { //10초뒤에 무적풀림
        GameObject.Find("Player").GetComponent<SpawnManager>().SendMessage("PoweroverWhelming");
        yield return new WaitForSeconds(10.0f);
        GameObject.Find("Player").GetComponent<SpawnManager>().SendMessage("PoweroverWhelmingOff");
        check = true;
    }
}
