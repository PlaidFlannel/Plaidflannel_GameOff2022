using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingPlatform : MonoBehaviour
{
    public bool isOccupied;
    [SerializeField] int unoccupiedYsize = 4;
    [SerializeField] int occupiedYsize = 1;
    BoxCollider boxCollider;
    void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "OccupiedBuildingTile")
        {
            isOccupied = true;
            //boxCollider.enabled = false;
            boxCollider.size = new Vector3(boxCollider.size.x, occupiedYsize, boxCollider.size.z);
        }
        else
        {
            isOccupied = false;
            // boxCollider.enabled = true;
            boxCollider.size = new Vector3(boxCollider.size.x, unoccupiedYsize, boxCollider.size.z);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        gameObject.tag = "BuildingTile";
    }

    public void TogglePlatform()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else { gameObject.SetActive(true); }
    }
}
