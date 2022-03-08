using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public int health = 100;
    public int damage = 30;
    public bool attacked = false;

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
        attacked = true;
        if (health <= 0){
            Dead();
        }
    }

    public void Dead(){
        audio.Play();
        Destroy(gameObject,0.8f);
    }

    private void Awake() {
        speed = normal_speed;
    }

    private void FixedUpdate() {
        move();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            target = other.gameObject;
        }
    }


    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            if(attacked){
                isTracing = true;
                speed = tracing_speed;
            }
            StartCoroutine("wait");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            isTracing = false;
            speed = normal_speed;
        }
    }

    IEnumerator wait (){
        yield return new WaitForSeconds(5f);
        isTracing = true;
        speed = tracing_speed;
    }

    private void move(){
        Vector3 moveVelocity = Vector3.right;

        if (isTracing){
            Vector3 playerPos = target.transform.position;
            Vector2 direction = playerPos - transform.position;
            float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotation_speed * Time.deltaTime);
        }

        transform.position += transform.right * speed *Time.deltaTime;
    }
}
