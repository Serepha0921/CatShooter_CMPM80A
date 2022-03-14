using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class Set : MonoBehaviour
{
    [Header("Pannels")]
    public GameObject pause_pannel;
    public GameObject setting_pannel;
    public GameObject pause_button;
    public GameObject Start_pannel;
    [Space]
    public bool Starting = false;

    [Space]
    public TextMeshProUGUI title;

    [Header("Settings")]
    public GameObject control_pannel;
    public GameObject video_pannel;
    public GameObject sound_pannel;
    public GameObject tutorial_pannel;

    [Header("Control Setting")]
    public TMP_Dropdown Methods;
    public GameObject sc;
    [Space]
    public GameObject Mouse_pannel;
    public GameObject Mouse_Button_pannel;
    public GameObject Keyboard_pannel;

    [Header("Vidoe Setting")]
    public bool fullscreen = true;
    public TMP_Dropdown resolution;
    public Toggle FS;

    [Header("Sound Settings")]
     public AudioMixer aduiMix;
     public Slider master;
     public Slider BGM;
     public Slider Enemy_Sound;
     public Slider player_sound;
     public Slider Explosion_sound;
     public Slider Special_sound;

     [Header("show Volume")]
     public TextMeshProUGUI master_num;
     public TextMeshProUGUI BGM_num;
     public TextMeshProUGUI Enemy_Sound_num;
     public TextMeshProUGUI player_sound_num;
     public TextMeshProUGUI Explosion_sound_num;
     public TextMeshProUGUI Special_sound_num;


    private void Start() {
        sc = GameObject.Find("Information");
        setting_pannel.SetActive (true);
        Methods.value = sc.GetComponent<Score>().control_method_value;

        pause_pannel.SetActive (false);
        setting_pannel.SetActive (false);
    }

    private void Update(){
        if(GameManager.instance.GameStart){
            if(Input.GetKeyDown(KeyCode.Escape)){
                pause();
            }
        }
    }

    //Buttons --------------------------------------------------------------------------------------------------------------------------------------------------------
    public void pause(){
        if(GameManager.instance.GameStart){
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

    public void Start_Set(){
        Start_pannel.SetActive(false);
        setting_pannel.SetActive(true);
        Starting = true;
    }

    public void back(){
        setting_pannel.SetActive (false);
        if(Starting){
            Start_pannel.SetActive(true);
        }else{
            pause_pannel.SetActive (true);
        }
    }

    public void StartTheGAme(){
        GameManager.instance.Start_Game();
        Starting = false;
        Start_pannel.SetActive(false);
    }

    public void quit(){
        Application.Quit();
    }

    //Pannel Settings --------------------------------------------------------------------------------------------------------------------------------------------------------
    public void control(){
        title.text = "Control";
        control_pannel.SetActive(true);

        video_pannel.SetActive(false);
        sound_pannel.SetActive(false);
        tutorial_pannel.SetActive(false);
    }

    public void video(){
        title.text = "Video";
        video_pannel.SetActive(true);

        control_pannel.SetActive(false);
        sound_pannel.SetActive(false);
        tutorial_pannel.SetActive(false);
    }

    public void sound(){
        title.text = "Sound";
        sound_pannel.SetActive(true);

        control_pannel.SetActive(false);
        video_pannel.SetActive(false);
        tutorial_pannel.SetActive(false);
    }

    public void tutorial(){
        title.text = "Tutorial";
        tutorial_pannel.SetActive(true);

        control_pannel.SetActive(false);
        video_pannel.SetActive(false);
        sound_pannel.SetActive(false);
    }

    //Sound Settings --------------------------------------------------------------------------------------------------------------------------------------------------------
    public void master_control(){
        float sound = master.value;
        master_num.text = "Master Volume: " + sound.ToString("F1");
        if (sound == -40f){
            aduiMix.SetFloat("Master Volume", -80);
        }else{
            aduiMix.SetFloat("Master Volume", sound);
        }
    }

    public void BGMV(){
        float sound = BGM.value;
        BGM_num.text = "BGM Volume: " + sound.ToString("F1");
        if (sound == -40f){
            aduiMix.SetFloat("BGM Volume", -80);
        }else{
            aduiMix.SetFloat("BGM Volume", sound);
        }
    }

    public void PlayerSound(){
        float sound = player_sound.value;
        player_sound_num.text = "Player Volume: " + sound.ToString("F1");
        if (sound == -40f){
            aduiMix.SetFloat("Player Volume", -80);
        }else{
            aduiMix.SetFloat("Player Volume", sound);
        }
    }

    public void EnemySound(){
        float sound = Enemy_Sound.value;
        Enemy_Sound_num.text = "Enemy Volume: " + sound.ToString("F1");
        if (sound == -40f){
            aduiMix.SetFloat("Enemy Volume", -80);
        }else{
            aduiMix.SetFloat("Enemy Volume", sound);
        }
    }

    public void ExplosionSound(){
        float sound = Explosion_sound.value;
        Explosion_sound_num.text = "Explosion Volume: " + sound.ToString("F1");
        if (sound == -40f){
            aduiMix.SetFloat("Explosion Volume", -80);
        }else{
            aduiMix.SetFloat("Explosion Volume", sound);
        }
    }
    public void SpecialSound(){
        float sound = Special_sound.value;
        Special_sound_num.text = "Win/Lose Volume: " + sound.ToString("F1");
        if (sound == -40f){
            aduiMix.SetFloat("Special Volume", -80);
        }else{
            aduiMix.SetFloat("Special Volume", sound);
        }
    }

    //Video Setting --------------------------------------------------------------------------------------------------------------------------------------------------------
    public void setFullScreen(){
        fullscreen = FS.isOn;
        Screen.fullScreen = fullscreen;
    }

    public void setResolution(){
        int choice = resolution.value;

        if (choice == 0){
            Screen.SetResolution(1920,1080,fullscreen);
        }else if(choice == 1){
            Screen.SetResolution(1280,720,fullscreen);
        }else if(choice == 2){
            Screen.SetResolution(960,540,fullscreen);
        }else if(choice == 3){
            Screen.SetResolution(2560,1440,fullscreen);
        }else{
            Screen.SetResolution(1920,1080,true);
        }
    }

    //Controll Setting --------------------------------------------------------------------------------------------------------------------------------------------------------
    public void SetControl(){

        if(Methods.value == 0){
            GameManager.instance.controls = GameManager.controlMethod.Mouse;
            Mouse_pannel.SetActive(true);
            Mouse_Button_pannel.SetActive(false);
            Keyboard_pannel.SetActive(false);
        }else if (Methods.value == 1){
            GameManager.instance.controls = GameManager.controlMethod.TwoButtonMouse;
            Mouse_Button_pannel.SetActive(true);
            Mouse_pannel.SetActive(false);
            Keyboard_pannel.SetActive(false);
        }else if (Methods.value == 2){
            GameManager.instance.controls = GameManager.controlMethod.TwoButtonKeyboard;
            Keyboard_pannel.SetActive(true);
            Mouse_pannel.SetActive(false);
            Mouse_Button_pannel.SetActive(false);
        }
    }

}
