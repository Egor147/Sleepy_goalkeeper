using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_starter : MonoBehaviour
{
    //Скрипт, отправляющий сигналы в нужные скрипты о готовности к началу игры


    [SerializeField]private Game_timer Game_timer_script;

    public void StartTheGame(){
        Game_timer_script.StartTime();
        GetComponent<Ball_creator>().GetReady(); 
        GetComponent<Things_creator>().GetReady();
    }
}
