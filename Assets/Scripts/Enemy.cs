using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;

    // Start is called before the first frame update
    public void GetDamage (int damage){
        health = health - damage;
        if (health <= 0){
            Dead();
        }
    }

    public void Dead(){
        Destroy(gameObject);
    }
}
