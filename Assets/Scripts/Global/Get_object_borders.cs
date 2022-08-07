using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_object_borders : MonoBehaviour
{

    //Скрипт получает координаты левой верхней точки и правой нижней точки границы объекта
    private Vector2 TopLeft, BottomRight;
    private float _spriteHeight, _spriteWidth;

    //метод, опреденяющий левой верхней точки границы объекта
    public Vector2 GetLeftTopPoint(){
        GetSizes();

        //Получение крайней верней координаты объекта
        Vector2 UpPoint = (Vector2)transform.position + Vector2.up * (_spriteHeight / 2);
        //Получение крайней левой координаты объекта
        Vector2 LeftPoint = (Vector2)transform.position + Vector2.left * (_spriteWidth / 2);
        return new Vector2(LeftPoint.x,UpPoint.y);
    }

    //метод, опреденяющий правой нижней точки границы объекта
    public Vector2 GetRightDownPoint(){
        GetSizes();

        //Получение крайней правой координаты объекта
        Vector2 rightPoint = (Vector2)transform.position + Vector2.right * (_spriteWidth /2);

        //Получение крайней нижней координаты объекта
        Vector2 DownPoint = (Vector2)transform.position + Vector2.down * (_spriteHeight / 2);

        return new Vector2(rightPoint.x,DownPoint.y);
    }

    //Получение размеров спрайта объекта
    private void GetSizes(){
        //Вычисление ширины спрайта
        _spriteWidth = GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x;
        //Вычисление высоты спрайта
        _spriteHeight = GetComponent<SpriteRenderer>().sprite.bounds.size.y * transform.localScale.y;
    }

}
