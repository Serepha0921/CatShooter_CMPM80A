using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Game stats")]
    public bool isGameover = false;
    public bool GameStop = false;
    public TextMeshProUGUI HP;

    [Header("Player stats")]
    public int health = 300;
    public int MaxHealth = 300;
    public enum controlMethod {Mouse,TwoButtonMouse,TwoButtonKeyboard};
    public controlMethod controls;

    [Header("Enemy Info")]
    public int number = 0;
    public int max = 10;

    public static GameManager instance;

    private void Awake() {
        if (instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }
    }

    private void Start() {
        health = MaxHealth;
    }

    public void PlayerDamage(int damage){
        health= health - damage;
        if (health <= 0){
            isGameover = true;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        HP.text = health+" / "+MaxHealth;
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
