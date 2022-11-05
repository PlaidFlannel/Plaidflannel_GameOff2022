using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//place this script on builable object prefabs
public class CheckBuildPlacement : MonoBehaviour
{

    BuildingManager buildingManager;
    void Start()
    {
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //anything with the following tag will not allow another thing to be built on that spot.
        if (other.gameObject.CompareTag("Object")) 
        {
            buildingManager.canPlace = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Object"))
        {
            buildingManager.canPlace = true;
        }
    }
}
