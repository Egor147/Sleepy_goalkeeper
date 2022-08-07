using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Set_end_score : MonoBehaviour
{
    /*
    Заранее поясню, почему сделал именно таким образом, чтобы итоговый счёт складывался со всеми предыдущими результатами
    Дело в том, что была идея, чтобы в будущем можно было переделать это в валюту, за которую можно добавить покупки
    Улучшения геймплея или же визуальной части игры.
    
    Для реализации просто вывода итогового счёта за игру потребовалось бы только обращение к Score_registrator_script.GetScore(),
    Чтобы получить набранное количество очков и вывести это всё на экран.
    
    Вот код реализации, если нет желания, чтобы все результаты игрока складывались:
    
    [SerializeField]private TMP_Text Score_txt;
    [SerializeField]private Score_registrator Score_registrator_script;

    public void ReloadCommonScore(){
        Score_txt.text = "Common score: " + Score_registrator_script.GetScore().ToString();
    }
    */
    [SerializeField]private TMP_Text Score_txt; //Текст, отображающий общий счёт на экране победы
    [SerializeField]private Score_registrator Score_registrator_script; //Для получения конечного счёта текущей игры

    public void ReloadCommonScore(){
        ReloadScore(); //Обновления значения общего счёта игрока
        //Вывод общего счёта на экран победы/поражения
        Score_txt.text = "Common score: " + PlayerPrefs.GetFloat("CommonScore", 0 ).ToString();
    }

    //Обновление общего счёта
    private void ReloadScore(){
        //Создание ключа для сохранения значения общего счёта игрока
        //Если ключь уже есть, то обновляет его значение и добавляет результат игры
        PlayerPrefs.SetFloat("CommonScore", PlayerPrefs.GetFloat("CommonScore", 0 ) + Score_registrator_script.GetScore());
    }
}
