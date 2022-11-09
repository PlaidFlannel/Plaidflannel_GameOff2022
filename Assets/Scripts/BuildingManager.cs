using System.Collections;
using System.Collections.Generic;
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

    public BuildingTargetFinder buildingTargetFinder;
    public bool canPlace;
    int goldCost;
    Bank bank;
    private void Start()
    {
        bank = FindObjectOfType<Bank>();
    }
    void Update()
    {
        if(pendingObject != null)
        {
            goldCost = pendingObject.GetComponent<BuildingInfo>().goldCost;
            var toggleBuildableAction = pendingObject.GetComponent<CheckBuildPlacement>();
            toggleBuildableAction.isPlaced = false;
            UpdateMaterials();
            if (gridSnapOn)
            {
                pendingObject.transform.position = new Vector3(
                    RoundToNearestGrid(pos.x),
                    RoundToNearestGrid(pos.y),
                    RoundToNearestGrid(pos.z)
                    );
            }
            else { pendingObject.transform.position = pos; }
            
            if (Input.GetMouseButtonDown(0) && canPlace)
            {
                bank.Withdraw(goldCost);
                toggleBuildableAction.isPlaced = true;
                PlaceObject();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                RotateObject();
            }
        }
    }
    public void PlaceObject()
    {
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
