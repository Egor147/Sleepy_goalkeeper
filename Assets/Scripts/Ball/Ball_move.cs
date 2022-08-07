using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_move : MonoBehaviour
{
    //Скрипт, реализующий передвижение мяча

    private Vector2 Target_coordsinates; //Конечные координаты полёта
    [SerializeField] private float Speed; //Скорость полёта
    //Скрипт для определения крайних координат границ ворот
    [SerializeField] private Get_object_borders Get_object_borders_script;
    private Ball_scaller Ball_scaller_script; //Скрипт для получения конечного размера объекта

    public void Start()
    {
        Ball_scaller_script = GetComponent<Ball_scaller>();
        Get_object_borders_script = GameObject.Find("/Gate").GetComponent<Get_object_borders>();
        Vector2 Left_top = Get_object_borders_script.GetLeftTopPoint(); //Рассчёт крайнего левого х и верхнего y ворот
        Vector2 Right_bottom = Get_object_borders_script.GetRightDownPoint(); //Расчёт крайнего правого х и нижнего у ворот

        //Рандомная генерация конечной точки полёта в пределах границ ворот
        Target_coordsinates = new Vector2 (Random.Range(Left_top.x * 0.9f,Right_bottom.x * 0.9f),Random.Range(Left_top.y * 0.9f,Right_bottom.y * 0.9f));
    }

    private void Update()
    {
        /*Если размеры объекта ещё не соответствуют конечным и 
        дистанция между текущими координатами мяча и координатами конечной точки полёта больше 0.02 То продолжает полёт
        Иначе сообщает о том, что мяч долетел до конечной точки и готов быть пойманным*/
        if (transform.localScale.x - Ball_scaller_script.GetEndScale() > 0.01f){ 
            if (new Vector2 (Target_coordsinates.x - transform.position.x, 
                        Target_coordsinates.y - transform.position.y).magnitude > 0.02f)
                        {
                            transform.position = Vector2.MoveTowards(transform.position,Target_coordsinates, Speed * Time.deltaTime);
                        }
        }else{
            GetComponent<Catch_registrator>().SetReadyToCatch();
            Destroy(this);
        }
    }

    //Метод, рассчитывающий и передающий время полёта мяча
    public float GetTime(){
        Vector2 Distanse = (Vector3)Target_coordsinates - transform.position;    
        return Distanse.magnitude/Speed;
    }
    //Метод передающий координаты конечной точки полёта
    public Vector2 GetTarget(){
        return Target_coordsinates;
    }

}
