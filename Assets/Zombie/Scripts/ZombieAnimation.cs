using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimation : MonoBehaviour
{
    GameObject player;
    private float dis;
    Animator ani;


    void Start()
    {
        this.player = GameObject.Find("Player");
        ani = GetComponent<Animator>();
        StartCoroutine("ZombieAni");
    }


     IEnumerator ZombieAni() 
    {
        Vector3 p1 = transform.position; // 좀비 위치
        Vector3 p2 = player.transform.position; // 캐릭터 위치
        dis = Vector3.Distance(p1, p2); // 사이 거리
        if (dis <= 3f) // 거리가 3이하면
        {
            ani.SetBool("isAttack", true);
            yield return new WaitForSeconds(1.5f);
            ani.SetBool("isAttack", false); 
             yield return new WaitForSeconds(1.5f);

        }
        

        yield return new WaitForSeconds(0.1f);
    }

    void Update()
    {
        
    }
}
