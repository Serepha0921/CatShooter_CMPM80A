using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plyaer_movement : MonoBehaviour
{

    private Rigidbody2D rb;
    private Vector3 mousePosition;
    private Transform player;

    public GameObject Cat;

    [Header("Guns")]
    public Transform gun;
    public GameObject bullet;
    [Header("Speed")]
    public float Movement_speed = 20f;
    private float speed;
    public float rotation_speed = 15f;

    // Start is called before the first frame update
    private void Awake() {
        player = GetComponent<Transform>();
    }

    private void Update() {
        /*
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.position;
        float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        player.rotation = Quaternion.Slerp(player.rotation, rotation, rotation_speed * Time.deltaTime);*/

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Cat.transform.position;
        float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Cat.transform.rotation = Quaternion.Slerp(Cat.transform.rotation, rotation, rotation_speed * Time.deltaTime);

        if(!GameManager.instance.GameStop){
            if(Input.GetMouseButtonDown(0)){// shoot
             speed = 0f;
             shoot();
             }else if (Input.GetMouseButton(1)){//stop
             speed = 0f;
             }else{//Move
             speed = Movement_speed;
             player.position += Cat.transform.right * speed *Time.deltaTime;
        }
        }
    }

    public void shoot(){
        Instantiate(bullet,gun.position,gun.rotation);
    }

}
