using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{

    [Header("Pannels")]
    public GameObject pause_pannel;
    public GameObject setting_pannel;

    // Start is called before the first frame update
    private void Start()
    {
        pause_pannel.SetActive (false);
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if (pause_pannel.activeSelf){
                GameManager.instance.resumeGame();
                pause_pannel.SetActive (false);
            } else {
                GameManager.instance.pauseGame();
                pause_pannel.SetActive (true);
            }
        }
    }

    public void resume(){
        GameManager.instance.resumeGame();
        pause_pannel.SetActive (false);
    }

    public void settings (){
        pause_pannel.SetActive (false);
        setting_pannel.SetActive (true);
    }

    public void quit(){
        Application.Quit();
    }

}
