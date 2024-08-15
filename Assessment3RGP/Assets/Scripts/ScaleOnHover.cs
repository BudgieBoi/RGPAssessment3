using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnHover : MonoBehaviour
{
    private Vector3 _initialScale;
    public float _scaleSizing;
    private void OnMouseEnter()
    {
        IncreaseScale(true);
    }
    private void OnMouseExit()
    {
        IncreaseScale(false);
    }

    private void Awake()
    {
        _initialScale = transform.localScale;
    }

    private void IncreaseScale(bool status)
    {
        Vector3 finalScale = _initialScale;

        //If status is true increase scale
        if(status)
            finalScale = _initialScale * _scaleSizing;
        
        transform.localScale = finalScale;
    }
}
