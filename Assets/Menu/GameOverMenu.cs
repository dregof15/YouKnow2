using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMagneticCheck.Player1Hp <= 0f)
        {
            
            SceneManager.LoadScene("GameOver");
        }
    }

    public void ChangeGameScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}
