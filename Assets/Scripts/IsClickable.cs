using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsClickable : MonoBehaviour
{
    public bool isClickable;
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isClickable) { button.interactable = false; }
        else { button.interactable = true; }
    }
}

