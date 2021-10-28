using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoSingleton<PlayerController>
{
    [SerializeField] private Vector2 inputCoordinate;
    [SerializeField, Range(0, 360f)] private float angle;
    [SerializeField, Range(-180f, 180f)] private float signedAngle;
    [SerializeField] private Vector2 center;

    [Header("REFERENCES")] [SerializeField]
    private GameObject catHead;

    private PlayerInput input;


    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        
    }

    private void Start()
    {
        catHead.SetActive(false);
    }

    private void SetCatHeadActivation(bool activation)
    {
        catHead.SetActive(activation);
    }
    private void RotateCatHead(Vector2 pos)
    {
        UpdateInputCoordinate(pos);
        GetAngleBetweenCenterAndTouch();
        UpdatePlayerRotation(angle);
    }

    private void StopRotateCatHead(Vector2 pos)
    {
        UpdatePlayerRotation(0);
    }

    private void UpdateInputCoordinate(Vector2 pos)
    {
        inputCoordinate = Camera.main.ScreenToWorldPoint(pos);
    }

    private void UpdatePlayerRotation(float angle)
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angle);
    }

    private void GetAngleBetweenCenterAndTouch()
    {
        if (inputCoordinate != null)
        {
            //burada angle i set et
            signedAngle = Vector2.SignedAngle(center, inputCoordinate);
            if (signedAngle < 0)
            {
                angle = 360f + signedAngle;
            }
            else
            {
                angle = signedAngle;
            }
        }
    }

    private void OnEnable()
    {
        EventManager.OnCatActivation += SetCatHeadActivation;
        
        EventManager.OnMouseInputDown += RotateCatHead;

        EventManager.OnMouseInputStay += RotateCatHead;

        EventManager.OnMouseInputUp += StopRotateCatHead;
    }

    private void OnDisable()
    {
        EventManager.OnCatActivation -= SetCatHeadActivation;
        
        EventManager.OnMouseInputDown -= RotateCatHead;

        EventManager.OnMouseInputStay -= RotateCatHead;

        EventManager.OnMouseInputUp -= StopRotateCatHead;
    }
}