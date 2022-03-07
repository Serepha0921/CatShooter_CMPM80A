using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Settings : MonoBehaviour
{
   public TextMeshProUGUI title;

   private void Start() {
       title.text = "Control";
   }

    public void control(){
        title.text = "Control";
    }

    public void video(){
        title.text = "Video";
    }

    public void sound(){
        title.text = "Sound";
    }

    public void tutorial(){
        title.text = "Tutorial";
    }

}
