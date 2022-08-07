using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_creator : MonoBehaviour
{
    [SerializeField]protected float timerOfSpawn; //Промежуток создания
    [SerializeField]protected GameObject Сreated_object; //Объект, который будет создаваться
    protected Get_camera_border Get_camera_border_script;   //Для определения границ камеры и создания мяча снизу за границами
    protected bool alreadyStartedCoroutine = false; //Флаг для определения запущена ли уже карутина
    protected bool Ready_to_start = false; //Флаг подготовлены ли ворота с игроком для текущего экрана телефона и готовы ли начинать

    //Метод, вызываемый из другого класса, сообщающий, что всё готово к началу игры
    public void GetReady(){
        Ready_to_start = true;
        Get_camera_border_script = GetComponent<Get_camera_border>();
    }
    
    protected void Update(){
        //Если карутина ещё не запущена и готовы к началу игры, то запускаем карутину
        if (alreadyStartedCoroutine == false && Ready_to_start){ 
            StartCoroutine(Spawn());
            alreadyStartedCoroutine = true;
        }
    }

    protected virtual IEnumerator Spawn(){
        timerOfSpawn = Random.Range(1,3); //Рандомная генерация периода создания объекта
        yield return new WaitForSeconds(timerOfSpawn);
            //Сигнал о том, что объект создался и карутину можно запускать снова
            alreadyStartedCoroutine = false;
            //Создание объекта за границами камеры снизу
            Instantiate(Сreated_object, new Vector3(0,Get_camera_border_script.GetBorderBottomRight().y - 1, 0), Quaternion.identity);
    }


}
