using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 onMouseDownCoordinates;
    public Vector2 onMouseStayCoordinates;
    public Vector2 onMouseUpCoordinates;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onMouseDownCoordinates = Input.mousePosition;
            EventManager.Invoke_OnMouseInputDown(Input.mousePosition);
            EventManager.Invoke_OnCatActivation(true);
        }

        if (Input.GetMouseButton(0))
        {
            onMouseStayCoordinates = Input.mousePosition;
            EventManager.Invoke_OnMouseInputStay(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            onMouseUpCoordinates = Input.mousePosition;
            EventManager.Invoke_OnMouseInputUp(Input.mousePosition);
            EventManager.Invoke_OnCatActivation(false);
        }
    }
}