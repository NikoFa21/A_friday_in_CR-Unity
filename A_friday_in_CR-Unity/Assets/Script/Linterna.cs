using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna : MonoBehaviour
{
    public Light linterna;    
    void Update()
    {
        if (LinternaPickup.linternaRecogida && Input.GetKeyDown(KeyCode.F))
        {
            linterna.enabled = !linterna.enabled;
        }
    }
}
