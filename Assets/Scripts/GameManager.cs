using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game stats")]
    public bool isGameover = false;
    public bool GameStop = false;
    public GameObject GameOverUI;
    public GameObject GameWinUI;

    [Header("Player stats")]
    public int health = 100;

    public static GameManager instance;

    private void Awake() {
        if (instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void pauseGame(){
        Time.timeScale = 0;
        GameStop = true;
    }

    public void resumeGame(){
        Time.timeScale = 1;
        GameStop = false;
    }
}
