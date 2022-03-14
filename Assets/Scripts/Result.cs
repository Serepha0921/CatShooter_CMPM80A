using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Result : MonoBehaviour
{
    public GameObject score;
    public int sc;
    public TextMeshProUGUI scorePan;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Information");
        sc = score.GetComponent<Score>().Score_number;
        scorePan.text = "Score: " + sc;
    }

    public void back(){
        score.GetComponent<Score>().Score_number = 0;
        SceneManager.LoadScene("SampleScene");
    }

}
