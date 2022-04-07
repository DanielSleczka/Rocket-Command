using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private Texture2D crosshair;
    private Vector2 hotSpot = Vector2.zero;
    private CursorMode cursorMode = CursorMode.Auto;

    private void Start()
    {
        Cursor.SetCursor(crosshair, hotSpot, cursorMode);
    }

}
