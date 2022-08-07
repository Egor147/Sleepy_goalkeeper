using UnityEngine;
using UnityEngine.EventSystems;

//Наследование интерфейсов для работы с нажатием, движением и поднятием пальца
public class PlayerMove : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Vector2 Start_player_position; //Начальная позиция игрока
    [SerializeField]private GameObject Player; //Объект игрока
    private Vector3 offset; //Отклонение координат нажатия от координат объекта
    [SerializeField]private float Speed; //Скорость перемещения по экрану (На случай, если не захочется, чтобы он передвигался моментально за пальцем)

    private Camera cam; //Камера для перевода в мировые координаты

    //Присваивание начальных значений необходимым переменным
    void Start()
    {
        Start_player_position = Player.transform.position;
        cam = Camera.main;
    }
    //Виртуальный метод, который высчитывает смещение нажатия на экран, относительно координат игрока
    public virtual void OnPointerDown(PointerEventData EventData){
        offset = Player.transform.position - cam.ScreenToWorldPoint(new Vector3(EventData.position.x, EventData.position.y, cam.nearClipPlane));
    }

    //Виртуальный метод возвращает игрока в начальное положение при поднятии пальца от экрана
    public virtual void OnPointerUp(PointerEventData EventData){
        Player.transform.position = Start_player_position;
    }

    //Виртуальный метод повторения передвижений игроком за пальцем
    public virtual void OnDrag(PointerEventData EventData){
        Vector3 newPosition = cam.ScreenToWorldPoint(EventData.position);
        Player.transform.position =Vector2.MoveTowards(Player.transform.position, newPosition + offset, Speed * Time.deltaTime); //Vector3.Lerp(Player.transform.position, newPosition + offset ,Speed * Time.deltaTime);
    }
}
