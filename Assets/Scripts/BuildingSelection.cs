using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSelection : MonoBehaviour
{
    public GameObject selectedObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.collider.gameObject.CompareTag("Object"))
                {
                    Select(hit.collider.gameObject);
                }
            }
        }
    }
    private void Select(GameObject obj)
    {
        if (obj == selectedObject) return;
        
    }

}
