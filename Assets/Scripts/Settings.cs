using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
   public TextMeshProUGUI title;

   [Header("Settings")]
   public GameObject control_pannel;
   public GameObject video_pannel;
   public GameObject sound_pannel;
   public GameObject tutorial_pannel;

   private void Start() {
       control();
   }

   //Pannel Settings
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
}
