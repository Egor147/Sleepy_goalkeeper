using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defeat_registrator : MonoBehaviour
{
    //Список объектов жизней
    [SerializeField] private List<GameObject> Life_list = new List<GameObject>();
    //Скрипт, в который передаётся информация о поражении игрока
    [SerializeField]private Loose_or_win_registrator Loose_or_win_registrator_script;

    private void Start(){
        FindChildsWithTag(gameObject, "Life"); //Поиск дочерних объектов по тегу
    }

    //Метод, срабатывающий, когда игрок должен потерять жизнь
    public void Defeat(){
        if (Life_list.Count > 0){ //Если у игрока ещё остались жизни
            Destroy(Life_list[Life_list.Count - 1]); //Уничтожение последнего в списке объекта
            Life_list.RemoveAt(Life_list.Count - 1); //Удаление пустого последнего слота в списке
        }
        //Если после удаления у игрока не осталось ни 1 жизни, то отправляется сигнал о поражении игрока
        if (Life_list.Count == 0){
            Loose_or_win_registrator_script.Loose();
        }

    }

    //Метод поиска объекта следи дочерних по тегу
    private void FindChildsWithTag(GameObject parent, string tag)
    {

        foreach (Transform child in parent.transform)
        {
            if (child.CompareTag(tag))
                Life_list.Add(child.gameObject);
        }
    }
}
