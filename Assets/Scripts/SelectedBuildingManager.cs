using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SelectedBuildingManager : MonoBehaviour
{
    [SerializeField] private Material highlightSelectionMaterial;
    [SerializeField] private Material buildablesBuiltMaterial;

    //[SerializeField] GameObject selectionIndicatorObject;

    private GameObject selectedObject;
    [SerializeField] GameObject indicator;

    [Header("UI elements:")]
    public TextMeshProUGUI objNameTxt;
    public TextMeshProUGUI costToMove;

    [SerializeField] GameObject moveButton;
    private BuildingManager buildingManager;
    private Bank bank;
    
    public GameObject selectionUI;

    float goldCost = 0;
    void Start()
    {
        
        selectionUI.SetActive(false);
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
        bank = FindObjectOfType<Bank>();
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.collider.gameObject.CompareTag("Object"))
                {
                    SelectIt(hit.collider.gameObject);
                }
                //else { Deselect(); }
            }
        }

        if (Input.GetMouseButtonDown(1) && selectedObject != null)
        {
            Deselect();
        }
        
        if (goldCost > bank.CurrentBalance) { moveButton.GetComponent<IsClickable>().isClickable = false; }
        else { moveButton.GetComponent<IsClickable>().isClickable = true; }

    }
    private void SelectIt(GameObject obj)
    {
        var checkIfPlaced = obj.GetComponent<CheckBuildPlacement>();
        Debug.Log("checkifplaced" + checkIfPlaced.isPlaced);
        //toggleBuildableAction.isPlaced = false;
        //if (obj.isPlaced == false) ;
        if (checkIfPlaced == false) { Debug.Log("Returning now"); return; }
        if (checkIfPlaced == true)
        {
            if (obj == selectedObject) return;

            if (selectedObject != null) Deselect();

            //find the selected object, so the indicator can be moved over it and activated
            Vector3 wheresItAt = obj.transform.position;
            indicator.transform.position = new Vector3(wheresItAt.x, 3.5f, wheresItAt.z);
            indicator.SetActive(true);

            //sets the name in the UI
            objNameTxt.text = obj.name;


            selectedObject = obj;
            selectionUI.SetActive(true);
            goldCost = obj.GetComponent<BuildingInfo>().goldCost;
        }

    }

    public void Deselect()
    {
        if (selectedObject != null)
        {
            selectionUI.SetActive(false);
            indicator.SetActive(false);
            selectedObject = null;
        }
        else { return; } //prevents error if clicking with nothing selected...
    }
    public void Delete()
    {
        GameObject objToDestroy = selectedObject;
        Deselect();
        Destroy(objToDestroy);
    }
    public void Move()
    {
        //indicator.SetActive(false);
        //selectionUI.SetActive(false);
        buildingManager.pendingObject = selectedObject;
        Deselect();
    }
}
