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
    void Update()
    {
        if (isOccupied)
        {
            boxCollider.size = new Vector3(boxCollider.size.x, occupiedYsize, boxCollider.size.z);
        }
        else
        {
            boxCollider.size = new Vector3(boxCollider.size.x, unoccupiedYsize, boxCollider.size.z);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || 
            other.gameObject.CompareTag("Enemies") || 
            other.gameObject.CompareTag("Ball") || 
            other.gameObject.CompareTag("Coin") || 
            other.gameObject.CompareTag("UnbuiltObject"))
        {
            return; 
        }
        if (other.gameObject.CompareTag("Object"))
        {
            gameObject.tag = "BuildingTile"; }
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
