using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Bullet_speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    [Header("animaiton")]
    public GameObject explosion;
    public Transform Pos;
    // Start is called before the first frame update
    private void Start() {
        rb.velocity = transform.right * Bullet_speed;
    }


    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy"){
            Enemy enmy = other.gameObject.GetComponent<Enemy>();
            if(enmy != null){
                enmy.GetDamage(damage);
            }

            anim();
        }
        if(other.gameObject.tag == "Building"){
            anim();
        }
    }

    /*
    private void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Enemy"){
            Enemy enmy = other.GetComponent<Enemy>();
            if(enmy != null){
                enmy.GetDamage(damage);
            }

            anim();
        }
        if(other.tag == "Building"){
            anim();
        }

    }*/

    private void anim(){
        rb.velocity = transform.right * 0;
        Instantiate(explosion,Pos.position,Quaternion.identity);
        Destroy(gameObject);
    } 

}
