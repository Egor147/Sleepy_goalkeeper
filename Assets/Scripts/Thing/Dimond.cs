using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dimond : Common_options_of_things
{
    private Score_registrator Score_registrator_script;
    [SerializeField]private int Price;

    //Переопределение метода и получение необходимого компонента
    protected override void GetRequiredComponent(){
        Score_registrator_script = GameObject.Find("/Game_canvas").GetComponent<Score_registrator>();
    }


    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")){
            Score_registrator_script.SetScore(Price);   //Добавление счёта при касании к игроку
            Destroy(gameObject); //Удаление объекта после касания
        }
    }

    
}
