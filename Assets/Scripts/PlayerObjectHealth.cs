using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectHealth : MonoBehaviour
{
    [SerializeField] float health = 10f;
    void Start()
    {
        
    }

    public float GetHealth()
    {
        return health;
    }
    void Update()
    {
        
    }
}
