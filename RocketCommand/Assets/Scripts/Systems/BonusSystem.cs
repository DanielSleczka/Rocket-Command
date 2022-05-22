using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class BonusSystem : MonoBehaviour
{
    // SpeedBonus - dost�p do ShootingControllera, po to, �eby przy�pieszy� lub zminimalizowa� czas prze�adowania rakiety.
    // SlowMo - wrzuci� do update Time.timeScale = 0.5F oraz przy�pieszy� pr�dko�� rakiety, aby zaimitowa� spowolnienie �wiata gry.
    // Shield - no to w sumie tylko zniszczenie obecnej je�li jest w cz�ci ca�a lub stworzenie nowej os�ony na rakiet command.
    // PointsBonus - raczej przej�ciowa propozycja pozyskiwania wi�kszej ilo�ci punkt�w. 

    [SerializeField] private ShootingController shootingController;
    private Bonuses bonuses;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }



}
