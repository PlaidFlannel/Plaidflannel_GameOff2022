using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.UI;

public class BuildingInfo : MonoBehaviour
{
    public int goldCost;
    public string buildingDescription;
    public int damageAmount;
    //BuildingManager buildingManager;
    //public bool isCannon;
    //public bool isBallista;

    private void Awake()
    {
        /*buildingManager = FindObjectOfType<BuildingManager>();
        if (isCannon)
        {
            damageAmount = buildingManager.damageFromCannon;
        }
        if (isBallista)
        {
            damageAmount = buildingManager.damageFromCannon;
        }*/
    }
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
