using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Things_creator : Ball_creator //Скрипт наследуется от генератора мячей, только карутина Spawn переопределена
{
    //Список объектов, которые могут падать сверху
    [SerializeField] private List<GameObject> Things_list = new List<GameObject>();

    protected override IEnumerator Spawn(){
        //Рандомный выбор промежутка создания объектов
        timerOfSpawn = Random.Range(3,10);
        yield return new WaitForSeconds(timerOfSpawn);
            //Сигнал о том, что объект создался и карутину можно запускать снова
            alreadyStartedCoroutine = false;
            //Генерация случайной координаты х в пределах границ камеры
            float randomX = Random.Range(Get_camera_border_script.GetBorderTopLeft().x * 0.9f, Get_camera_border_script.GetBorderBottomRight().x * 0.9f);
            //Случайный выбор создаваемого объекта из списка
            Сreated_object = Things_list[Random.Range(0, Things_list.Count)];
            //Создание объекта за границами камеры сверху в сгенерированной заранее координате х
            Instantiate(Сreated_object, new Vector3(randomX,Get_camera_border_script.GetBorderTopLeft().y + 1, 0), Quaternion.identity);
    }
}
