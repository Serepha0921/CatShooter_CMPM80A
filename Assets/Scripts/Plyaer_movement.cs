using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plyaer_movement : MonoBehaviour
{

    private Rigidbody2D rb;
    private Vector3 mousePosition;
    private Transform player;

    public GameObject Cat;

    [Header("SFX")]
    public AudioClip Hit;
    public AudioClip blast;
    private AudioSource audio;

    [Header("Guns")]
    public Transform gun;
    public GameObject bullet;
    private float timer = 0;
    public float attackCoolTime = 0.5f;

    private float speed;
    private bool Go_Forward = true;


    [Header("Speed_TBM")]
    public float rotating_speed = 50f;
    public float Moving_speed = 10f;

    [Header("Speed_Key")]
    public float RotateSpeed_key = 50f;
    public float MoveSpeed_key = 10f;

    // Start is called before the first frame update
    private void Awake() {
        player = GetComponent<Transform>();
        audio = GetComponent<AudioSource>();
        timer = 0;
    }

    private void Update() {

        if(!GameManager.instance.GameStop){
            switch (GameManager.instance.controls)
            {
                case GameManager.controlMethod.Mouse:{
                    WASD();
                    break;
                }
                case GameManager.controlMethod.TwoButtonMouse:{
                    twoButtonMouseControl();
                    break;
                }
                case GameManager.controlMethod.TwoButtonKeyboard:{
                    speed = MoveSpeed_key;
                    twoButtonKeyBoardControl();
                    break;
                }
            }
        }

        timer += Time.deltaTime;
    }

    private void WASD(){
        //Shoot
        if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.D)){
            shoot();
        }

        //rotate left
        if (Input.GetKey(KeyCode.A)){
            if(Input.GetKey(KeyCode.D)){
                shoot();
            }
            Cat.transform.Rotate(0,0,Time.deltaTime * RotateSpeed_key,Space.Self);
        }

        //rotate right
        if (Input.GetKey(KeyCode.D)){
            if(Input.GetKey(KeyCode.A)){
                shoot();
            }
            Cat.transform.Rotate(0,0,-(Time.deltaTime * RotateSpeed_key),Space.Self);
        }
    }

    private void twoButtonMouseControl(){
        //Shoot
        if (Input.GetMouseButtonDown(0) && Input.GetMouseButtonDown(1)){
            shoot();
        }

        //rotate left
        if (Input.GetMouseButton(0)){
            if (Input.GetMouseButtonDown(1)){
                shoot();
            }
            Cat.transform.Rotate(0,0,Time.deltaTime * rotating_speed,Space.Self);
        }

        //rotate right
        if (Input.GetMouseButton(1)){
            if (Input.GetMouseButtonDown(0)){
                shoot();
            }
            Cat.transform.Rotate(0,0,-(Time.deltaTime * rotating_speed),Space.Self);
        }
    }

    private void twoButtonKeyBoardControl(){
        //Shoot
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.RightArrow)){
            shoot();
        }

        //rotate left
        if (Input.GetKey(KeyCode.LeftArrow)){
            if(Input.GetKey(KeyCode.RightArrow)){
                shoot();
            }
            Cat.transform.Rotate(0,0,Time.deltaTime * RotateSpeed_key,Space.Self);
        }

        //rotate right
        if (Input.GetKey(KeyCode.RightArrow)){
            if(Input.GetKey(KeyCode.LeftArrow)){
                shoot();
            }
            Cat.transform.Rotate(0,0,-(Time.deltaTime * RotateSpeed_key),Space.Self);
        }
    }

    public void shoot(){
        if (timer >= attackCoolTime){
            if(audio.clip != blast){
                audio.clip = blast;
            }
            audio.Play();
            Instantiate(bullet,gun.position,gun.rotation);
            timer = 0;
        }
    }

}
