using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Emit;
using UnityEngine;

public class healthTracker : MonoBehaviour
{
    int num = 3;
    public float targetTime;
    float a;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update(){
        targetTime -= Time.deltaTime;
    }

     public void healthDown()
    {        
        if(targetTime <= 0.0f){
            num--;
            targetTime = 1;
            
        }
    }

    void OnGUI()
    {                    //10  10  100  20
        GUI.Label(new Rect(10, 10, 100, 20), "Hp: " + num);
        if(num < 1){
            GUI.Label(new Rect(750,300,100,200),"GAME OVER");
        }
    }
}
