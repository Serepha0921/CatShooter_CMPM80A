using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public int health = 100;
    public int damage = 30;
    public int movementFlag = 1;
    public bool isAttacked = false;

    [Space]
    public AudioSource audio;

    [Header("speeds")]
    private float speed = 0f;
    public float normal_speed = 1f;
    public float tracing_speed = 1f;
    public float rotation_speed = 1f;

    [Space]
    public bool isTracing = false;

    private GameObject target;

    // Start is called before the first frame update
    public void GetDamage (int damage){
        health = health - damage;
        isAttacked = true;
        if (health <= 0){
            Dead();
        }
    }

    public void Dead(){
        audio.Play();
        Destroy(gameObject,0.8f);
    }

    private void OnDestroy() {
        GameManager.instance.number -= 1;
    }

    private void Awake() {
        speed = normal_speed;
        if(GameManager.instance.number >= GameManager.instance.max){
            Destroy(gameObject);
        } else{
            GameManager.instance.number += 1;
            StartCoroutine("ChangeMovement");
        }
    }

    private void FixedUpdate() {
        move();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            target = other.gameObject;
            StopCoroutine("ChangeMovement");
        }
    }


    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            isTracing = true;
            if(isAttacked){
                speed = tracing_speed;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            isTracing = false;
            speed = normal_speed;
            isAttacked = false;
            StartCoroutine("ChangeMovement");
        }
    }

    IEnumerator ChangeMovement(){
        Debug.Log("change");
        movementFlag = Random.Range(0,5);
        yield return new WaitForSeconds(5f);
        
        StartCoroutine("ChangeMovement");
    }

    private void move(){
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
    }
}
