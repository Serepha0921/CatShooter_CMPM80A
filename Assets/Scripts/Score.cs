using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score instance;

    public int Score_number = 0;
    public int control_method_value = 0;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
        if (instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }

    }
}
