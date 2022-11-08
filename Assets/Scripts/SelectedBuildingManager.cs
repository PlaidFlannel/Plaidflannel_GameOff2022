using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class SelectedBuildingManager : MonoBehaviour
{
    [SerializeField] private Material highlightSelectionMaterial;
    [SerializeField] private Material buildablesBuiltMaterial;

    //[SerializeField] GameObject selectionIndicatorObject;

    private GameObject selectedObject;


    [Header("UI elements:")]
    public TextMeshProUGUI objNameTxt;

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
        //add material to show selection
        //material = canBuild
        //Vector3 wheresItAt = obj.transform.position;
        //Instantiate(selectedObject, wheresItAt, Quaternion.identity);
        //selectionIndicatorObject.GameObject.Instantiate<>
        obj.GetComponent<MeshRenderer>().material = highlightSelectionMaterial;
        objNameTxt.text = obj.name;
        selectedObject = obj;
        selectionUI.SetActive(true);

    }

    void Deselect()
    {
        selectedObject.GetComponent<MeshRenderer>().material = buildablesBuiltMaterial;
        selectionUI.SetActive(false);
        selectedObject = null;
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
    }
}
