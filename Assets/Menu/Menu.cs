using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //private SpawnManager script;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public  void ChangeGameScene()
    {
        
        PlayerMagneticCheck.Player1Hp = 100f;
        SceneManager.LoadScene("gameScence");
        GameObject.Find("GameManager").GetComponent<SpawnManager>().Start();
        
        // script.SpawnZombie();
    }
}
