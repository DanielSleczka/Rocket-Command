using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Texture2D crosshair;

    [Header("Missile")]
    [SerializeField] private Missile missile;
    [SerializeField] private Transform startPosition;

    private Vector2 hotSpot = Vector2.zero;
    private CursorMode cursorMode = CursorMode.Auto;

    private Vector2 mousePosition;
    public static Vector2 objPosition;
    public static Vector2 targetPosition;


    private void Start()
    {
        Cursor.SetCursor(crosshair, hotSpot, cursorMode);
    }

    private void Update()
    {
        mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        objPosition = mainCamera.ScreenToWorldPoint(mousePosition);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Missile newMissile = Instantiate(missile);
            newMissile.transform.position = startPosition.position;
            newMissile.transform.rotation = startPosition.rotation;
        }
    }
}
