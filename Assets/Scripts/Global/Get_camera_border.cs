using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_camera_border : MonoBehaviour
{
    //Скрипт, получающий координаты границ камеры (Левой верхней точки и правой нижней)
    private Camera cam;


    private void Start(){
        cam = GetComponent<Camera>();
    }
    //Получение координал правой нижней точки границы камеры
    public Vector2 GetBorderBottomRight(){
        float width = cam.pixelWidth;

        Vector2 cameraBottomRight = cam.ScreenToWorldPoint(new Vector2 (width, 0));
        return cameraBottomRight;
    }
    //Получение координал левой верхней точки границы камеры
    public Vector2 GetBorderTopLeft(){
        float height = cam.pixelHeight;

        Vector2 cameraTopLeft = cam.ScreenToWorldPoint(new Vector2 (0, height));
        return cameraTopLeft;
    }
}
