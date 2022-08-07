using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loose_or_win_registrator : MonoBehaviour
{
    //Скрипт, включающий нужные картинки и нужный канвас при победе/поражении игрока

    [SerializeField]private GameObject End_game_canvas, Loose_img, Win_img;
    [SerializeField]private Set_end_score Set_end_score_script;

    //Включение нужного канваса и изображения поражения
    public void Loose(){ 
        ReloadScore();
        End_game_canvas.SetActive(true);
        Loose_img.SetActive(true);
    }

    //Включение нужного канваса и изображения победы
    public void Win(){
        ReloadScore();
        End_game_canvas.SetActive(true);
        Win_img.SetActive(true);
    }

    //Обновление значения количества набранных очков
    private void ReloadScore(){
        Time.timeScale = 0; //остановка времени игры
        Set_end_score_script.ReloadCommonScore();
    }
}
