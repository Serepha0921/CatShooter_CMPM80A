using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class Set : MonoBehaviour
{
    [Header("Control Setting")]
    public TMP_Dropdown Methods;

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


      //Sound Settings
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

    //Video Setting
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

    //Controll Setting
    public void SetControl(){
        int choice = Methods.value;

        if(choice == 0){
            GameManager.instance.controls = GameManager.controlMethod.Mouse;
        }else if (choice == 1){
            GameManager.instance.controls = GameManager.controlMethod.TwoButtonMouse;
        }else if (choice == 2){
            GameManager.instance.controls = GameManager.controlMethod.TwoButtonKeyboard;
        }
    }

}
