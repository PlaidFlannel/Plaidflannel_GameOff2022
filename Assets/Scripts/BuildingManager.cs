using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    public int damageFromBallista = 1;
    public int damageFromCannon = 2;

    public GameObject[] objects;
    public GameObject pendingObject;

    [SerializeField] private Material[] materials;

    private Vector3 pos;
    private RaycastHit hit;
    [Tooltip("Identify which layer will allow building - such as 'Ground'")]
    [SerializeField] private LayerMask layerMask;

    public float rotateAmount = 45;
    public float gridSize; //determines grid size which objects will snap to
    bool gridSnapOn = true;
    [SerializeField] private Toggle gridToggle;

    BuildingButtons[] buildingButtons;

    public BuildingTargetFinder buildingTargetFinder;
    public bool canPlace;
    int goldCost;
    Bank bank;
    private void Start()
    {
        //buildUI.SetActive(false);
        buildingButtons = FindObjectsOfType<BuildingButtons>();
        bank = FindObjectOfType<Bank>();
        //Debug.Log("BuildingManager active");
    }
    void Update()
    {
        if(pendingObject != null)
        {
            foreach (BuildingButtons b in buildingButtons)
            {
                b.ButtonToggle();
            }
            if (Input.GetMouseButtonDown(1))
            {
                pendingObject.SetActive(false);
                Debug.Log("Right click");
                pendingObject = null;
                foreach (BuildingButtons b in buildingButtons)
                {
                    b.ButtonToggle();
                }
                return;

            }
            goldCost = pendingObject.GetComponent<BuildingInfo>().goldCost;
            var toggleBuildableAction = pendingObject.GetComponent<CheckBuildPlacement>();
            toggleBuildableAction.isPlaced = false;
            UpdateMaterials();
            if (gridSnapOn)
            {
                pendingObject.transform.position = new Vector3(
                    RoundToNearestGrid(pos.x- 1),
                    RoundToNearestGrid(pos.y- 1),
                    RoundToNearestGrid(pos.z - 1)
                    );
            }
            else { pendingObject.transform.position = pos; }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
            {
                
                if (hit.collider.gameObject.CompareTag("BuildingTile"))
                {
                    //BuildingPlatform platform = hit.collider.gameObject.GetComponent<BuildingPlatform>();
                    if (Input.GetMouseButtonDown(0) && canPlace)
                    {

                        if (goldCost < bank.CurrentBalance + 1)
                        {
                            bank.Withdraw(goldCost);
                            toggleBuildableAction.isPlaced = true;
                            hit.collider.gameObject.tag = "OccupiedBuildingTile";
                            PlaceObject();
                            //platform.isOccupied = true;
                        }
                        //else { Debug.Log("can't afford this"); }
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                RotateObject();
            }
        }
    }
    public void PlaceObject()
    {
        pendingObject.gameObject.tag = "Object";
        pendingObject.GetComponent<MeshRenderer>().material = materials[2];
        pendingObject = null;
    }
    public void RotateObject()
    {
        pendingObject.transform.Rotate(Vector3.up, rotateAmount);
    }
    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray,out hit, 1000, layerMask))
        {
            pos = hit.point;
        }
    }
    void UpdateMaterials() 
    {
        if (canPlace)
        {
            //Debug.Log(pendingObject.GetComponent<MeshRenderer>().material);
            pendingObject.GetComponent<MeshRenderer>().material = materials[0];
        }
        else
        {
            pendingObject.GetComponent<MeshRenderer>().material = materials[1];
        }
    }

    public void SelectObject(int index)
    {
        pendingObject = Instantiate(objects[index], pos, transform.rotation);
        pendingObject.name = objects[index].name;
    }
    public void ToggleGrid()
    {
        if (gridToggle.isOn) 
        {
            gridSnapOn = true;
        }
        else
        {
            gridSnapOn = false;
        }
    }
    float RoundToNearestGrid(float pos)
    {
        float xDifference = pos % gridSize;
        pos -= xDifference;
        if (xDifference > (gridSize / 2))
        {
            pos += gridSize;
        }
        return pos;
    }
}
