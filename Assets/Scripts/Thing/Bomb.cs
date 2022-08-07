using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Common_options_of_things
{
    private Defeat_registrator Defeat_registrator_script;

    //Переопределение метода и получение необходимого компонента
    protected override void GetRequiredComponent(){
        Defeat_registrator_script = GameObject.Find("/Game_canvas").GetComponent<Defeat_registrator>();
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")){
            Defeat_registrator_script.Defeat(); //Добавление счёта при касании к игроку
            Destroy(gameObject);    //Удаление объекта после касания
        }
    }
}
