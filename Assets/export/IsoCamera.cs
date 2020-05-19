using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class IsoCamera : MonoBehaviour

{
    public int sight = 10; //시야
    public float smoth = 12f; //부르더운 이동
    private int offsetY = 0;
    private int offsetX = 0;
    private int offsetZ = 0;
    GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player"); //플레이어 찾기
        offsetY = sight;
        offsetZ = 0 - sight;
    }


    // Update is called once per frame
    //void Update()
    //{
     //   transform.position = new Vector3(player.transform.position.x + offsetX, player.transform.position.y + offsetY, player.transform.position.z + offsetZ);
    //}
    void FixedUpdate()
    {
        Vector3 TargetPos = new Vector3(player.transform.position.x + offsetX, player.transform.position.y + offsetY, player.transform.position.z + offsetZ);
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * smoth);
    }
}