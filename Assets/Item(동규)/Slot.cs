using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour , IPointerDownHandler, IPointerUpHandler
{

    public Item item; // 획득한 아이템.
    public int itemCount; // 획득한 아이템의 개수.
    public Image itemImage; // 아이템의 이미지.
    private bool isBtnDown = false;
    

    [SerializeField]
    private Inventory theInventory;

    // 필요한 컴포넌트.
    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage; // 아이템갯수 뒷배경

    int i = 0;
    // 이미지의 투명도 조절.
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    // 아이템 획득
    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;

        
            go_CountImage.SetActive(true);
            text_Count.text = itemCount.ToString();
        

        SetColor(1);
    }

    // 아이템 개수 조정.
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();
        

        if (itemCount <= 0)
            ClearSlot();
    }

    // 슬롯 초기화.
    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);

        text_Count.text = "0";
        go_CountImage.SetActive(false);
    }

    public void Update()
    {
        //버튼이 눌렸는지안눌렸지 체크
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

    IEnumerator WaitForIt2()
    {

        
        yield return new WaitForSeconds(2.0f);
        //2초동안꾹누른상태일때 아이템삭제 
        if (isBtnDown == true)
        {
            ClearSlot();   
            isBtnDown = false;
        }      
    }

}
