using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    #region Mouse Inputs

    public static event Action<Vector2> OnMouseInputDown;

    public static void Invoke_OnMouseInputDown(Vector2 mousePos)
    {
        OnMouseInputDown?.Invoke(mousePos);
    }

    public static event Action<Vector2> OnMouseInputStay;

    public static void Invoke_OnMouseInputStay(Vector2 mousePos)
    {
        OnMouseInputStay?.Invoke(mousePos);
    }

    public static event Action<Vector2> OnMouseInputUp;

    public static void Invoke_OnMouseInputUp(Vector2 mousePos)
    {
        OnMouseInputUp?.Invoke(mousePos);
    }

    #endregion

    #region Gameplay

    public static event Action<bool> OnCatActivation;

    public static void Invoke_OnCatActivation(bool isActive)
    {
        OnCatActivation?.Invoke(isActive);
    }

    #endregion
    
    
}