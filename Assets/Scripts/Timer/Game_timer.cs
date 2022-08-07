using System.Collections;
using UnityEngine;
using UnityEngine.UI;
 
public class Game_timer : MonoBehaviour
{
    [SerializeField] private float time; //Переменная времени игры
    [SerializeField] private Image timerImage; //Компонент изображения
    //Скрипт, в который передаётся информация об окончании игры и победе игрока, если таймер дошёл до 0
    [SerializeField] private Loose_or_win_registrator Loose_or_win_registrator_script;
 
    private float _timeLeft = 0f;
 
    private IEnumerator StartTimer()
    {
        //Пока оставшееся время больше 0 уменьшаем его и "вырезаем" изображение
        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            var normalizedValue = Mathf.Clamp(_timeLeft / time, 0.0f, 1.0f);
            timerImage.fillAmount = normalizedValue;
            yield return null;
        }

        //Когда оставшееся время дошло до 0, значит, игрок победил. Отправка сигнала об этом
        Loose_or_win_registrator_script.Win(); 
    }
 
    public void StartTime()
    {
        //Запуск таймера, когда всё готово для того, чтобы начинать игру
        _timeLeft = time;
        StartCoroutine(StartTimer());
    }
}
