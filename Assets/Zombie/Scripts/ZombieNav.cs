using UnityEngine;
using System.Collections;

public class ZombieNav : MonoBehaviour {

	static public bool zombieDeadCheck = false;
	private Transform player;
	private UnityEngine.AI.NavMeshAgent nvAgent;

	Transform field;
	public float charDis;
	public float fieldDis;

	void Start () {
		field = GameObject.Find("Field").GetComponent<Transform> ();
		player = GameObject.Find("Player").GetComponent<Transform> ();
		nvAgent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent> ();

		StartCoroutine("aaa");
	}

	

	// Update is called once per frame

	void Update () {
        
	}

	IEnumerator aaa() // 예비 자기장까지 줄어들었을 경우 일정시간후 다시 작아짐
    {
		while(true)
		{
			Vector3 zombiePos = transform.position; // 좀비 위치
			Vector3 charPos = player.transform.position; // 캐릭터 위치
			Vector3 FieldPos = field.transform.position; // 자기장 위치
			charDis = Vector3.Distance(zombiePos, charPos); // 좀비와 캐릭터 거리
			fieldDis = Vector3.Distance(zombiePos, FieldPos);



			//if(charDis < 20f) // 1순위로 좀비와 캐릭터가 가까우면
				nvAgent.destination = player.position;
			//	nvAgent.speed = 50f;
			//else if(MagneticField.r1 / 2 > fieldDis){ // 2순위로 좀비가 자기장 밖이면 안으로 네비
			// 	nvAgent.destination = field.position;
			//}
			yield return new WaitForSeconds(0.5f);
		}
    }

}