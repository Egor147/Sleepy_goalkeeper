using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play_again : MonoBehaviour
{
    //Кнопка, перезагружающая сцену игры
    public void OnClick(){
        Time.timeScale = 1; //Включение времени
        SceneManager.LoadScene("Game"); //Перезагрузка сцены
    }
}
