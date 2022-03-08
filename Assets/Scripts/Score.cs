using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int Score_number = 0;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }
}
