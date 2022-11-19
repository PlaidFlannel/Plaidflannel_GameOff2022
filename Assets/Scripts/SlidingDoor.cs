using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    [SerializeField] Vector3 startPosition;
    [SerializeField] Vector3 endPosition;

    [SerializeField] float moveSpeed;

    [SerializeField] GroundButtonSensor controlButton1;
    [SerializeField] GroundButtonSensor controlButton2;

    [SerializeField] bool staysOpen;
    bool moveEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
        moveEnabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(controlButton2 != null)
        {
            if (controlButton1.objectEnabled || controlButton2.objectEnabled)
            {
                moveEnabled = true;
            }
            if (!controlButton1.objectEnabled && !controlButton2.objectEnabled)
            {
                moveEnabled = false;
            }
        }
        else
        {
            if (controlButton1.objectEnabled)
            {
                moveEnabled = true;
            }
            if (!controlButton1.objectEnabled)
            {
                moveEnabled = false;
            }
        }

        //moveEnabled = controlButton.objectEnabled;
        //Debug.Log("movenabled on door " + moveEnabled);
        if (moveEnabled)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, moveSpeed * Time.deltaTime);
        }
        if (!moveEnabled && !staysOpen)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, moveSpeed * 0.25f * Time.deltaTime);
        }
    }
    void DoAction()
    {
        if (moveEnabled) { moveEnabled = false; }
        if (!moveEnabled) { moveEnabled = true; }
    }

}
