using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int countZombie = 20;

    public static GameManager instance = null;

    [HideInInspector] public int EnemyCount;
    //남은 적캐릭터수 표시할 UI
    public Text EnemyCountTxt;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;

        } else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        //게임 초기 데이터 로드
        LoadGameData();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGameData()
    {
        //저장된 적수를 로드한다
        PlayerPrefs.SetInt("Enemy_COUNT", 20); // Enemy_COUNT 에  5를저장
        EnemyCount = PlayerPrefs.GetInt("Enemy_COUNT", 20); //저장한값 5로초기화한후 을 EnemyCount에 불러옴 
        EnemyCountTxt.text = "Enemy " + EnemyCount.ToString("00"); // 자릿수 글자표시
    }

    // 좀비수 감소함수
    public void DecEnemycount()
    {
        --EnemyCount;
        --countZombie;
        if(countZombie<=0){
            countZombie=20;
//            PlayerPrefs.SetInt("Enemy_COUNT", 20); // Enemy_COUNT 에  5를저장
//            EnemyCount = PlayerPrefs.GetInt("Enemy_COUNT", 20); //저장한값 5로초기화한후 을 EnemyCount에 불러옴 
            SceneManager.LoadScene("GameOver");
        }


        EnemyCountTxt.text = "Enemy " + EnemyCount.ToString("00");
        
        PlayerPrefs.SetInt("Enemy_COUNT", EnemyCount);

        
    }
}
