using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class testingTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        TooltipScreenSpaceUI.ShowTooltip_Static("This is a test of the tooltip set up\nLine 2 begins now.");
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
