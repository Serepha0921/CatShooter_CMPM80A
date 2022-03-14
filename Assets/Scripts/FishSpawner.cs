using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{

    public GameObject Yellow;
    public GameObject Red;

    public float term_yellow = 5f;
    public float term_red = 5f;

    // Start is called before the first frame update
    void Start()
    {
        if(!GameManager.instance.GameStop){
            StartCoroutine(Spawn(term_yellow, Yellow));
            StartCoroutine(Spawn(term_red, Red));
        }
    }

    private IEnumerator Spawn (float term, GameObject fish){
        yield return new WaitForSeconds(term);
        int rand = Random.Range(0,2);
        if(rand == 0){
            Instantiate(fish,new Vector3(Random.Range(8f,23f),Random.Range(10f,18f),0),Quaternion.identity);
        }else if(rand == 1){
            Instantiate(fish,new Vector3(Random.Range(-8f,-23f),Random.Range(-10f,-18f),0),Quaternion.identity);
        }
        if(!GameManager.instance.GameStop){
            StartCoroutine(Spawn(term,fish));
        }
    }
}
