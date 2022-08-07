using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common_options_of_things : MonoBehaviour
{
    //Скрипт, объединяющий общую часть кода для всех Объектов, падающих вниз
    //Скрипт должен наследоваться в скриптах всех Объектов, падающих вниз
    
    private float Down_border;

    protected void Start()
    {
        //Определение нижней границы камеры
        Down_border = Camera.main.GetComponent<Get_camera_border>().GetBorderBottomRight().y;
        GetRequiredComponent();
    }

    //Виртуальный метод определения всех необходимых компонентов для конкретного объекта
    protected virtual void GetRequiredComponent(){}

    void Update()
    {
        //Если объект упал ниже, чем нижняя граница камеры, то объект удаляется
        if(transform.position.y < Down_border)
            Destroy(gameObject);
    }
}
