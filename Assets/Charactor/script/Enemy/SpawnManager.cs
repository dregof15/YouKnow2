using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SpawnManager : MonoBehaviour
{
    public GameObject Zombie;
    private List<GameObject> zombieList = new List<GameObject>();
    public GameObject itemA, itemB;



    [SerializeField]
    private Inventory theInventory;

    public void Awake()
    {

    }

    public void Start()
    {
        for (int i = 0; i < 3; i++) //몇번좀비소환할건지 설정 
        {
            Invoke("Spawn", 0.3f); //0.3초뒤에 Spawn을 호출한다.

        }

    }
    void Spawn()
    {
        float randomX = Random.Range(-30f, 30f); //x축 랜덤범위조정
        float randomZ = Random.Range(-30f, 30f); //y 랜덤범위조정
        GameObject obj = Instantiate(Zombie, new Vector3(randomX, 1f, randomZ), Quaternion.identity) as GameObject;
        zombieList.Add(obj);

    }

    void PoweroverWhelming()
    {
        GameObject.Find("Zombie").GetComponent<ZombieCharacterControl>().Poweroverwhelming = true;

        for (int i = 0; i < 3; i++)
        {
            zombieList[i].GetComponent<ZombieCharacterControl>().Poweroverwhelming = true;
        }


    }

    void PoweroverWhelmingOff()
    {
        GameObject.Find("Zombie").GetComponent<ZombieCharacterControl>().Poweroverwhelming = false;

        for (int i = 0; i < 3; i++)
        {
            zombieList[i].GetComponent<ZombieCharacterControl>().Poweroverwhelming = false;
        }
    }

    void SpawnGreen() // 포션 클론에 넣기
    {
        for (int i = 0; i < 3; i++)
        {
            zombieList[i].GetComponent<ZombieMagneticCheck>().itemA = GameObject.Find("Zombie").GetComponent<ZombieMagneticCheck>().itemA;// 클론각각에 좀비오브젝트 itemA요소넣기
            zombieList[i].GetComponent<ZombieMagneticCheck>().itemB = GameObject.Find("Zombie").GetComponent<ZombieMagneticCheck>().itemB;// 클론각각에 좀비오브젝트 itemB요소넣기
            /*if (zombieList[i].GetComponent<ZombieMagneticCheck>().ZombieHp == 0) // 클론 피가 0이면 
            {
                //Instantiate(itemB, this.gameObject.transform.position, Quaternion.identity); // 클론앞에 초록포션소환
            }*/
        }
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider colider)
    {
        if (colider.gameObject.tag == "Item")
        {
            //포션이 Player라는 이름과 부딫혔다면 
            Debug.Log("획득");
            Destroy(colider.gameObject); // 부딫히면 물체사라짐
            theInventory.AcquireItem(colider.gameObject.transform.GetComponent<ItemPickup>().item);//아이템획득
        }
    }
}