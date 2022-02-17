using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Bullet_speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    private void Start() {
        rb.velocity = transform.right * Bullet_speed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy"){
            Enemy enmy = other.GetComponent<Enemy>();
            if(enmy != null){
                enmy.GetDamage(damage);
            }

            Destroy(gameObject);
        }
        if(other.tag == "Building"){
            Destroy(gameObject);
        }

    }
}
