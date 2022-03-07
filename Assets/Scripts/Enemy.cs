using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public AudioSource audio;

    // Start is called before the first frame update
    public void GetDamage (int damage){
        health = health - damage;
        if (health <= 0){
            Dead();
        }
    }

    public void Dead(){
        audio.Play();
        Destroy(gameObject,0.8f);
    }
}
