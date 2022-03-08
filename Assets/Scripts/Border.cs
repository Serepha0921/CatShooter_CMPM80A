using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "Enemy"){
          GameManager.instance.number -= 1;
          Destroy(other.gameObject);
      }
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Trig" + other.gameObject.tag);
        if(other.gameObject.tag == "Enemy"){
          GameManager.instance.number -= 1;
          Destroy(other.gameObject);
        }
    }
}
