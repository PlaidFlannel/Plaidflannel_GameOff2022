using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //play sound on pickup
    public int coinValue = 1;
    private float spinSpeed = 1.0f;
    AudioClip audioClip;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (gameObject.activeSelf)
        {
            //Debug.Log("SPIN");
            transform.Rotate(new Vector3(0.0f, 0.0f, 90.0f), spinSpeed, Space.Self);
        }
    }
}
