using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow_creator : MonoBehaviour
{
    //Скрипт, создающий тень на месте, куда летит мяч
    private Ball_move Ball_move_script; //Скрипт передвижения мяча для оределения координат конечной точки
    [SerializeField] private GameObject Shadow, canvas; //Объект канваса и префаб тени
    private GameObject Shadow_of_this_ball;

    private void Start()
    {
        Ball_move_script = GetComponent<Ball_move>();
        canvas = GameObject.Find("/Game_canvas"); //Поиск нужного канваса на сцене
        //Создание объекта тени, дочернего к найденному канвасу
        Shadow_of_this_ball = Instantiate(Shadow, Ball_move_script.GetTarget(), Quaternion.identity, canvas.transform);
    }

    //Публичный метод для получения объекта, созданной тени
    public GameObject GetShadow(){
        return Shadow_of_this_ball;
    }
}
