using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName ="New item/item")]
public class Item : ScriptableObject
{
    public string itemName;// 아이템이름
    public Sprite itemImage;// 아이템이미지
    public GameObject itemPrefab;//아이템 프리펩 실제로 떨어지는 아이템



}
