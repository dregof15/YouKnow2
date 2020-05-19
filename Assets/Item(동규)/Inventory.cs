using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{



    // 필요한 컴포넌트
    [SerializeField]
    private GameObject inventoryparent;

    // 슬롯들.
    public Slot[] slots;
    public Slot[] slots2;



    // Use this for initialization
    void Start()
    {
        // 배열안에 Slot스크립트넣기
        slots = inventoryparent.GetComponentsInChildren<Slot>();
        


    }


    public void AcquireItem(Item _item, int _count = 1)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            
             if (slots[i].item != null)
            {
                //이미 있는 아이템일경우 갯수만추가
                if (slots[i].item.itemName == _item.itemName)
                {
                    slots[i].SetSlotCount(_count);
                    return;
                }
            }
             
            else if (slots[i].item == null)
            {   
                //아이템공간이 비어져있으면 무조건추가 
                slots[i].AddItem(_item, _count);
                return;
            }
            
            
        }
    }

 
}
