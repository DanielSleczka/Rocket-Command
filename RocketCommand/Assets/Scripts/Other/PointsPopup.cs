using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsPopup : MonoBehaviour
{
    [SerializeField] private TextMeshPro textPopup;
    [SerializeField] private float existDuration; 
    private Color textColor;

    public void Setup(float pointsToShow)
    {
        textColor = textPopup.color;
        textPopup.text = $"+{pointsToShow.ToString()}";
    }

    private void Update()
    {
        float moveYSpeed = 2f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;

        existDuration -= Time.deltaTime;
        if (existDuration < 0)
        {
            float disappearSpeed = 2f;

            textColor.a -= disappearSpeed * Time.deltaTime;
            textPopup.color = textColor;
            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }

}
