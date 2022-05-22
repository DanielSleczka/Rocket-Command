using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class BonusSystem : MonoBehaviour
{
    // SpeedBonus - dostêp do ShootingControllera, po to, ¿eby przyœpieszyæ lub zminimalizowaæ czas prze³adowania rakiety.
    // SlowMo - wrzuciæ do update Time.timeScale = 0.5F oraz przyœpieszyæ prêdkoœæ rakiety, aby zaimitowaæ spowolnienie œwiata gry.
    // Shield - no to w sumie tylko zniszczenie obecnej jeœli jest w czêœci ca³a lub stworzenie nowej os³ony na rakiet command.
    // PointsBonus - raczej przejœciowa propozycja pozyskiwania wiêkszej iloœci punktów. 

    [SerializeField] private ShootingController shootingController;
    private Bonuses bonuses;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }



}
