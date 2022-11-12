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
    string buildingName;
    string buildingDecsription;
    int goldCost;
    Bank bank;
    Button button;
    private void Start()
    {
        button = gameObject.GetComponent<Button>();
        bank = FindObjectOfType<Bank>();
        buildingManager = FindObjectOfType<BuildingManager>();
        if (buildingGameObject == null) { return; }
        buildingName = buildingGameObject.name;
        buildingDecsription = buildingGameObject.GetComponent<BuildingInfo>().buildingDescription;

        goldCost = buildingGameObject.GetComponent<BuildingInfo>().goldCost;
    }
    public void ButtonToggle()
    {
        if (button.interactable)
        {
            button.interactable = false;
        }
        else
        {
            if (goldCost > bank.CurrentBalance) { button.interactable = false; }
            else { button.interactable = true; }
        }
    }
    private void Update()
    {
        if (goldCost > bank.CurrentBalance){ button.interactable = false; }
        else { button.interactable = true; }
    }

    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        TooltipScreenSpaceUI.ShowTooltip_Static(buildingName + "\nGold Cost: " +goldCost+"\n" + buildingDecsription);
        //Output to console the GameObject's name and the following message
        //Debug.Log("Cursor Entering " + name + " GameObject");
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        TooltipScreenSpaceUI.HideTooltip_Static();
        //Output the following message with the GameObject's name
        //Debug.Log("Cursor Exiting " + name + " GameObject");
    }
}
