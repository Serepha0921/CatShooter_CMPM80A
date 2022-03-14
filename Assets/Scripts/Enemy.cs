using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public int health = 100;
    public int movementFlag;
    public int BonusScore = 0;

    [Space]
    public AudioSource audio;

    [Header("speeds")]
    private float speed = 0f;
    public float normal_speed = 1f;
    public float rotation_speed = 1f;

    private float radius = 0;
    private Vector2 newPos = new Vector2();
    private float runningTime = 0;
    private float x = 0f;
    private float y = 0f;

    [Space]
    public bool isTracing = false;

    public GameObject target;

    // Start is called before the first frame update
    public void GetDamage (int damage){
        health = health - damage;
        if (health <= 0){
            Dead();
        }
    }

    public void Dead(){
        audio.Play();
        GameManager.instance.Score = GameManager.instance.Score + 10 + BonusScore;
        Destroy(gameObject,0.8f);
    }

    private void OnDestroy() {
        GameManager.instance.number -= 1;
    }

    private void Awake() {
        speed = normal_speed;
        Vector2 pos = gameObject.transform.position;
        radius = Mathf.Sqrt (Mathf.Pow(pos.x,2) + Mathf.Sqrt (Mathf.Pow (pos.y,2)));
        StartCoroutine("ChangeMovement");
        if(GameManager.instance.number >= GameManager.instance.max){
            Destroy(gameObject);
        } else{
            GameManager.instance.number += 1;
        }
    }

    private void FixedUpdate() {
        move();
    }

    IEnumerator ChangeMovement(){
        movementFlag = Random.Range(1,3);
        yield return new WaitForSeconds(5f);
        
        StartCoroutine("ChangeMovement");
    }

    private void move(){
        speed = normal_speed;
        //runningTime += Time.deltaTime *speed;
        if(movementFlag == 1){
            transform.localScale = new Vector3 (1,1,1);
            runningTime += Time.deltaTime *speed;
        }else if (movementFlag == 2){
            transform.localScale = new Vector3 (1,-1,1);
            runningTime += Time.deltaTime *speed * -1;
        }
        x = radius * Mathf.Cos (runningTime);
        y = radius * Mathf.Sin (runningTime);
        newPos = new Vector2(x,y);
        gameObject.transform.position = newPos;

        Vector3 playerPos = target.transform.position;
        Vector2 direction = playerPos - transform.position;
        float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotation_speed * Time.deltaTime);

        /*
        Vector3 moveVelocity = Vector3.zero;

        if (isTracing){
            transform.localScale = new Vector3 (1,1,1);
            transform.localRotation = Quaternion.Euler (0,0,0);

            Vector3 playerPos = target.transform.position;
            Vector2 direction = playerPos - transform.position;
            float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotation_speed * Time.deltaTime);

            transform.position += transform.right * speed *Time.deltaTime;
        }else{
            if(movementFlag == 1){
                moveVelocity = Vector3.right;
                transform.localScale = new Vector3 (1,1,1);
            } else if (movementFlag == 2){
                moveVelocity = Vector3.left;
                transform.localScale = new Vector3 (-1,1,1);
            } else if (movementFlag == 3){
                moveVelocity = Vector3.up;
                transform.localScale = new Vector3 (1,1,1);
                transform.localRotation = Quaternion.Euler (0,0,90);
            } else if (movementFlag == 4){
                moveVelocity = Vector3.down;
                transform.localScale = new Vector3 (1,1,1);
                transform.localRotation = Quaternion.Euler (0,0,-90);
            }

            transform.position += moveVelocity * speed *Time.deltaTime;
        }
        */
    }
}
