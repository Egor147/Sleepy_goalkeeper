using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch_registrator : MonoBehaviour
{
    //Скрипт, регистрирующий попадание в ворота, либо факт того, что игрок поймал мяч
    private bool Ready_to_catch = false, caught = false; //Необходимые флаги
    [SerializeField]private GameObject Canvas, My_shadow; //Объекты канваса и тени

    //Публичный метод, вызываемый из другого скрипта, показывающий, что мяч долетел до вотор и готов к тому, чтобы его поймали
    public void SetReadyToCatch(){
        Ready_to_catch = true;
    }

    
    void Start()
    {
        //Определение тени
        My_shadow = GetComponent<Shadow_creator>().GetShadow();
        //Поиск канваса через тень (Тень дочерняя к нужному канвасу)
        Canvas = My_shadow.transform.parent.gameObject;
    }


    void Update()
    {
        if (Ready_to_catch){
            if (caught){
                //Если флаг, что игрок поймал и мяч готов к ловке - правда, то увеличение счёта
                Canvas.GetComponent<Score_registrator>().SetScore(1);
            } else{
                //Если мячь готов к ловле, но игрок не поймал, то уменьшение жизней
                Canvas.GetComponent<Defeat_registrator>().Defeat();
            }
            //Выключение флага, чтобы больше ни разу до удаления объекта Update не зашёл в условие
            Ready_to_catch = false;

            //Удаление тени и игрока
            Destroy(My_shadow);
            Destroy(gameObject,0.2f);
        }
    }

    private void OnTriggerStay2D(Collider2D other){
        //Если игрок пересёк коллайдер мяча, то включается флаг о ловле
        if (other.gameObject.CompareTag("Player")){
            caught = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        //Если игрок вышел из коллайдера мяча, то выключается флаг о ловле
        if (other.gameObject.CompareTag("Player")){
            caught = false;
        }
    }
}
