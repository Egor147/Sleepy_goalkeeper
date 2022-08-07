using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_scaller : MonoBehaviour
{
    //Скрипт, создающий иллюзию отдаления от камеры (Уменьшения размера объекта мяча)
    private float Flight_time, Reduction_rate; //Время полёта и Скорость отдаления от камеры
    [SerializeField] private float End_scale; //Конечный размер объекта
    private Ball_move Ball_move_script; //Скрипт передвижения мяча

    void Start()
    {
        Ball_move_script = GetComponent<Ball_move>();
        Flight_time = Ball_move_script.GetTime();
        //Определения необходимой скорости, чтобы когда мяч достигнет нужных размеров, он был в конечной точке
        Reduction_rate = (transform.localScale.x - End_scale)/Flight_time;
    }

    void Update()
    {
        //Если размеры мяча ещё не достигли нужного размера, значит, он ещё летит и продолжает отдаляться от камеры (Уменьшаться)
        if (transform.localScale.x - End_scale > 0.01f)
            transform.localScale = new Vector3 (transform.localScale.x - Reduction_rate * Time.deltaTime, 
                                                transform.localScale.y - Reduction_rate * Time.deltaTime, 
                                                transform.localScale.z);
        
    }

    //Публичный метод, возвращающий конечные размеры мяча
    public float GetEndScale() { return End_scale;}
}
