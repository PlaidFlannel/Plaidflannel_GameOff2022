using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] Button rotateRight;
    [SerializeField] Button rotateLeft;
    [SerializeField] float rotationAmount = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
