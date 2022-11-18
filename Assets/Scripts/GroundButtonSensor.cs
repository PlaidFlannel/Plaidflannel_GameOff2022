using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundButtonSensor : MonoBehaviour
{
    [Header("Materials")]
    [SerializeField] Material wrongThing;
    [SerializeField] Material active;
    [SerializeField] Material inactive;
    [Header("Object controlled by this button.")]
    [SerializeField] GameObject connectedObject;
    [SerializeField] bool PlayerControlsIt;
    public bool objectEnabled = false;
    MeshRenderer meshRenderer;
    void Start()
    {
        //connectedObject = GetComponent<GameObject>();
        meshRenderer = GetComponent<MeshRenderer>();
        Debug.Log(PlayerControlsIt);
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (PlayerControlsIt)
        {
            if (other.CompareTag("Player"))
            {
                //connectedObject.GetComponent<SlidingDoor>().moveEnabled = true;
                meshRenderer.material = active;
                objectEnabled = true;
            }
            if (other.CompareTag("Ball"))
            {
                meshRenderer.material = wrongThing;
            }
        }
        if(!PlayerControlsIt)
        {
            if (other.CompareTag("Ball"))
            {
                //connectedObject.GetComponent<SlidingDoor>().moveEnabled = true;
                meshRenderer.material = active;
                objectEnabled = true;
            }
            else
            {
                meshRenderer.material = wrongThing;
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        objectEnabled = false;
        meshRenderer.material = inactive;
    }
}
