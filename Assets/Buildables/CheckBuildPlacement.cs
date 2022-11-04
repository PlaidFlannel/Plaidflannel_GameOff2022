using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBuildPlacement : MonoBehaviour
{
    BuildingManager buildingManager;
    void Start()
    {
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
}
