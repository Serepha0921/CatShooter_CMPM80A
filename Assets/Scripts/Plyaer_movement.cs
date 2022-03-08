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

    private float speed;
    private bool Go_Forward = true;

    [Header("Speed_M")]
    public float Movement_speed = 20f;
    public float rotation_speed = 15f;

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
    }

    private void Update() {

        if(!GameManager.instance.GameStop){
            switch (GameManager.instance.controls)
            {
                case GameManager.controlMethod.Mouse:{
                    speed = Movement_speed;
                    mouseControl();
                    break;
                }
                case GameManager.controlMethod.TwoButtonMouse:{
                    speed = Moving_speed;
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
    }

    private void mouseControl (){
        //rotate
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Cat.transform.position;
        float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Cat.transform.rotation = Quaternion.Slerp(Cat.transform.rotation, rotation, rotation_speed * Time.deltaTime);

        if(Input.GetMouseButtonDown(0)){// shoot
             //speed = 0f;
             shoot();
        }else if (Input.GetMouseButton(1)){//stop
             speed = 0f;
        }else{//Move
             speed = Movement_speed;
             player.position += Cat.transform.right * speed *Time.deltaTime;
        }
    }

    private void twoButtonMouseControl(){
        //stop
        if(Input.GetMouseButtonDown(2)){
            Go_Forward = !Go_Forward;
        }
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
        //stop
        if (Go_Forward){
            speed = Moving_speed;
        }else{
            speed = 0f;
        }
        //move
        player.position += Cat.transform.right * speed *Time.deltaTime;
    }

    private void twoButtonKeyBoardControl(){
        //stop
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            Go_Forward = !Go_Forward;
        }
        //Shoot
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            shoot();
        }

        //rotate left
        if (Input.GetKey(KeyCode.LeftArrow)){
            Cat.transform.Rotate(0,0,Time.deltaTime * RotateSpeed_key,Space.Self);
        }

        //rotate right
        if (Input.GetKey(KeyCode.RightArrow)){
            Cat.transform.Rotate(0,0,-(Time.deltaTime * RotateSpeed_key),Space.Self);
        }
        //stop
        if (Go_Forward){
            speed = MoveSpeed_key;
        }else{
            speed = 0f;
        }
        //move
        player.position += Cat.transform.right * speed *Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy"){
            GameManager.instance.PlayerDamage(30);
            if(audio.clip != Hit){
                audio.clip = Hit;
            }
            audio.Play();
        }
    }

    public void shoot(){
        if(audio.clip != blast){
            audio.clip = blast;
        }
        audio.Play();
        Instantiate(bullet,gun.position,gun.rotation);
    }

}
