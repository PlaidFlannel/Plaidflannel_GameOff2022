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
    int goldToMove;

    private BuildingManager buildingManager;

    public GameObject selectionUI;
    void Start()
    {
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
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
                else { Deselect(); }
            }
        }

        if (Input.GetMouseButtonDown(1) && selectedObject != null)
        {
            Deselect();
        }
    }
    private void SelectIt(GameObject obj)
    {
        if (obj == selectedObject) return;
        if (selectedObject != null) Deselect();
        //goldToMove = obj.GetComponent<BuildingInfo>().goldCost;
        //add material to show selection
        //material = canBuild
        Vector3 wheresItAt = obj.transform.position;
        indicator.transform.position = new Vector3( wheresItAt.x, 3.5f, wheresItAt.z);
        indicator.SetActive(true);
        //Instantiate(selectedObject, wheresItAt, Quaternion.identity);
        //selectionIndicatorObject.GameObject.Instantiate<>
        //indicator = obj.transform.GetChild<
        //obj.GetComponent<MeshRenderer>().material = highlightSelectionMaterial;
        objNameTxt.text = obj.name;
        //string gc = goldToMove.ToString();
        //costToMove.text =  gc ;
        selectedObject = obj;
        selectionUI.SetActive(true);

    }

    void Deselect()
    {
        if (selectedObject != null)
        {
            //selectedObject.GetComponent<MeshRenderer>().material = buildablesBuiltMaterial;
            selectionUI.SetActive(false);
            indicator.SetActive(false);
            selectedObject = null;
        }
        else { return; }

    }
    public void Delete()
    {
        GameObject objToDestroy = selectedObject;
        Deselect();
        Destroy(objToDestroy);
    }
    public void Move()
    {
        buildingManager.pendingObject = selectedObject;
        Deselect();
        //Vector3 wheresItAt = selectedObject.transform.position;
        //indicator.transform.position = new Vector3(wheresItAt.x, 1.5f, wheresItAt.z);
    }
}
