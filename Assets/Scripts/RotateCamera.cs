using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RotateCamera : MonoBehaviour
{

    [SerializeField] float rotationAmount = 0f;



    void Start()
    {

    }


    void Update()
    {

    }

    public void RotateCameraRight()
    {
        Debug.Log(rotationAmount);
        //if (rotationAmount < 100)
        //{
        rotationAmount -= 45f;
        //}
        transform.rotation = Quaternion.Euler(45, rotationAmount, 0);
    }
    public void RotateCameraLeft()
    {
        Debug.Log(rotationAmount);
        //if (rotationAmount > 100)
        //{
        rotationAmount += 45f;
        //}
        transform.rotation = Quaternion.Euler(45, rotationAmount, 0);
    }
}
