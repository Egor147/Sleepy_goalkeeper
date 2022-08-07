using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score_registrator : MonoBehaviour
{
    private int Score; //Текущий счёт в текущей сессии
    [SerializeField]private TMP_Text Score_txt; //Текст для отображения счёта
    

    public void SetScore(int Change){
        Score += Change; //Изменение счёта
        Score_txt.text = Score.ToString(); //перезагрузки счёта, отображающегося на экране
    }

    public int GetScore(){
        return Score;   //Для получения значения счёта из другого класса
    }


}
