using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpareField : MonoBehaviour
{
    public GameObject Shpare;
    public float f02;
    public int count = 0;

    void Start()
    {
        InvokeRepeating("Shpareitem", 10, 10); // 예비 자기장을 처음 2초후 3초마다 생성
    }

    // Update is called once per frame
    void Update()
    {
        if(MagneticField.fieldstop == true)
        {
            Shpare.transform.localScale = new Vector3(MagneticField.temp, MagneticField.temp, MagneticField.temp);
            // 예비 자기장의 크기가 자기장의 크기의 절반만큼 줄어들게함
            if(count >= 1)
            {
                Destroy(this);
            }
        }
    }
    void Shpareitem()
    {
        
        float randomX = Random.Range(-(MagneticField.temp/2), MagneticField.temp / 2); // 예비 자기장이 생기는 x 범위
        float randomZ = Random.Range(-(MagneticField.temp / 2), MagneticField.temp / 2); // 예비 자기장이 생기는 y 범위
        if (true)
        {
            Debug.Log("생성");
            GameObject shpare = (GameObject)Instantiate(Shpare, new Vector3(randomX, 0f, randomZ),Quaternion.identity);
            count++;
        }
    }

    
}
