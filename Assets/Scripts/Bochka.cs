using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bochka : MonoBehaviour
{
    public UILog LogBar;
    public float Bochkalives = 400;//ХП
    public float BochkalivesMax = 400;
    
    bool Hpbochka()
    {
        if (Bochkalives <= 0)
        {
            Destroy(gameObject);
            return false;
        }
        else
        {
            return true;
        }
    }


 public void LivesUILog () //Отрисовать хп у зомби
    {
        if (Bochkalives > 0) {
           LogBar.SetSizeLog ((Bochkalives / BochkalivesMax));
        } else {
            LogBar.SetSizeLog (0f);
        }

    }




    public bool BochkaController(int hp)
    {//Изменение хп и вызов всех связанных функций
    
        Bochkalives += hp;//Добавляем значение хп
        LivesUILog();
        return Hpbochka();
    }
}
