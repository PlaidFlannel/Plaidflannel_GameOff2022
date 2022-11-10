using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildingButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    BuildingManager buildingManager;
    [SerializeField] GameObject buildingGameObject;
    //public enum BuildingSelection { ballista, cannon,  healing};
    //public BuildingSelection buildingSelection;
    string buildingDecsription;
    int goldCost;

    private void Start()
    {

        buildingManager = FindObjectOfType<BuildingManager>();
        if (buildingGameObject == null) { return; }
        buildingDecsription = buildingGameObject.GetComponent<BuildingInfo>().buildingDescription;

        goldCost = buildingGameObject.GetComponent<BuildingInfo>().goldCost;
    }

    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        TooltipScreenSpaceUI.ShowTooltip_Static("Gold Cost: "+goldCost+"\n" + buildingDecsription);
        //Output to console the GameObject's name and the following message
        Debug.Log("Cursor Entering " + name + " GameObject");
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        TooltipScreenSpaceUI.HideTooltip_Static();
        //Output the following message with the GameObject's name
        Debug.Log("Cursor Exiting " + name + " GameObject");
    }
}
