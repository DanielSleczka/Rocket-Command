using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private Texture2D crosshair;
    private Vector2 hotSpot;

    private void Start()
    {
        hotSpot = new Vector2(crosshair.width / 2f, crosshair.height / 2f);
        Cursor.SetCursor(crosshair, hotSpot, CursorMode.Auto);
    }

}
