using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate_scaller : MonoBehaviour
{
    //Данный скрипт подстраивает ширину ворот (Соответственно и игрока, т.к. он дочерний к воротам) к ширине экрана
    //Игра начинается только после того, как этот скрипт закончит свою работу

    private Vector2 cameraTopLeft, cameraBottomRight; // Для ххранения верхей левой и правой нижней точек границы камеры

    [SerializeField]private float step; //шаг уменьшения размера объекта

    //Скрипт для получения координат границ камеры
    [SerializeField]private Get_camera_border Get_camera_border_script;
    //Скрипт для получения координат границ ворот
    private Get_object_borders Get_object_borders_script;
    //Флаг, сообщающий о том, что координаты камеры уже получены и можно начинать с ними работать
    private bool flag = false;

    private void Start()
    {
        Get_object_borders_script = GetComponent<Get_object_borders>();
        //Задержка получения координат границ камеры, потому что иначе данный запрос проходил быстрее, чем
        //скрипт Get_camera_border вычислял те самые границы
        Invoke("GetCameraBorders", 0.01f);
    }

    //Метод, получающий координаты границ камеры
    private void GetCameraBorders(){
        cameraBottomRight = Get_camera_border_script.GetBorderBottomRight();
        cameraTopLeft = Get_camera_border_script.GetBorderTopLeft();
        flag = true;
    }

    private void Update(){
        if (flag){
            //Получение координат границ ворот
            float Right_x = Get_object_borders_script.GetRightDownPoint().x;
            float Left_x = Get_object_borders_script.GetLeftTopPoint().x;
            //Если ворота выходят за границы видимости камеры, то уменьшение ворот
            if (Right_x - cameraBottomRight.x > 0 && Left_x - cameraTopLeft.x < 0){
                transform.localScale = new Vector3(transform.localScale.x - step, transform.localScale.y - step, transform.localScale.z);
            }
            //Если ворота слишком маленькие, то увеличение ворот
            else if (cameraBottomRight.x - Right_x > 0.05f && Mathf.Abs(cameraTopLeft.x) - Mathf.Abs(Left_x) > 0.05f)
                transform.localScale = new Vector3(transform.localScale.x + step, transform.localScale.y + step, transform.localScale.z);
            else{
                //Если все уменьшения/увеличение выполнены, то отправление сигнала о готовности начать игру
                Get_camera_border_script.gameObject.GetComponent<Game_starter>().StartTheGame();
                //Удаление данного скрипта с объекта, так как он свою задачу выполнил и больше не требуется
                Destroy(this);
            }
        }
    }
}
