using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{

    [Header("Pannels")]
    public GameObject pause_pannel;
    public GameObject setting_pannel;
    public GameObject pause_button;

    // Start is called before the first frame update
    private void Start()
    {
        pause_pannel.SetActive (false);
        setting_pannel.SetActive (false);
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            pause();
        }
    }

    public void pause(){
        if (!pause_pannel.activeSelf && ! setting_pannel.activeSelf){
            GameManager.instance.pauseGame();
            pause_pannel.SetActive (true);
            pause_button.SetActive (false);
        } else {
            GameManager.instance.resumeGame();
            pause_pannel.SetActive (false);
            setting_pannel.SetActive (false);
            pause_button.SetActive (true);
        }
    }

    public void resume(){
        GameManager.instance.resumeGame();
        pause_pannel.SetActive (false);
        pause_button.SetActive (true);
    }

    public void settings (){
        pause_pannel.SetActive (false);
        setting_pannel.SetActive (true);
    }

    public void back(){
        setting_pannel.SetActive (false);
        pause_pannel.SetActive (true);
    }

    public void quit(){
        Application.Quit();
    }

}
