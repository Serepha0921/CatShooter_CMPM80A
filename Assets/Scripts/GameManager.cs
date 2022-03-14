using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Game stats")]
    public bool isGameover = false;
    public bool GameStop = false;
    public Score sc;
    public int Score = 0;
    public float time = 120f;

    [Header("UI")]
    public TextMeshProUGUI Score_Pannel;
    public TextMeshProUGUI Timer;

    [Header("GameSystem")]
    public GameObject cat;
    public GameObject Spawner;

    public enum controlMethod {Mouse,TwoButtonMouse,TwoButtonKeyboard};
    public controlMethod controls;

    [Header("Enemy Info")]
    public int number = 0;
    public int max = 20;

    public static GameManager instance;

    private void Awake() {
        if (instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }
        pauseGame();
    }

    public void Start_Game() {
        cat.SetActive(true);
        Spawner.SetActive(true);
        Score = 0;
        resumeGame();
    }

    // Update is called once per frame
    private void Update()
    {
        if(!GameStop){
            if(time >0){
                time -= Time.deltaTime;
            }else{
                sc.Score_number = Score;
                
                if(controls == controlMethod.Mouse){
                    sc.control_method_value = 0;
                } else if (controls == controlMethod.TwoButtonMouse){
                    sc.control_method_value = 1;
                } else if (controls == controlMethod.TwoButtonKeyboard){
                    sc.control_method_value = 2;
                }

                SceneManager.LoadScene("Win");
            }
        }
        Timer.text = time.ToString("N0") + "s";
        Score_Pannel.text = "Score: " + Score;
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
