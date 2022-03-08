using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{

    public Transform target;

    public float camera_distance_z = -10;

    public float speed = 0.15f;
    public float height;
    public float width;
    public Vector3 offset;

    [Space]
    public Vector2 center;
    public Vector2 mapSize;

    private void Start() {
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }

    private void limitCameraMove(){

        //transform.position = Vector3.Lerp(transform.position, target.position + gameObject.transform.position, Time.deltaTime * speed);
        Vector3 desiredPosition = target.position + offset + new Vector3(0,0,camera_distance_z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed);
        transform.position = smoothedPosition;

        float lx = mapSize.x - width;
        float clampX = Mathf.Clamp(transform.position.x, center.x - lx, center.x + lx);

        float ly = mapSize.y - height;
        float clampY = Mathf.Clamp(transform.position.y, center.y - ly, center.y + ly);

        transform.position = new Vector3(clampX, clampY, -10f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, mapSize * 2);
    }

    private void LateUpdate()
    {
        /*
        Vector3 desiredPosition = target.position + offset + new Vector3(0,0,camera_distance_z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed);
        transform.position = smoothedPosition;*/

        limitCameraMove();
    }
}
