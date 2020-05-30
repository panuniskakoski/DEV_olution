using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appearance : MonoBehaviour
{
    public bool unlocked = false;

    public void Start()
    {
        this.GetComponent<Renderer>().enabled = false;
    }

    public void Update()
    {

    }

    public void ToggleUnlock()
    {
        unlocked = true;
        this.GetComponent<Renderer>().enabled = true;
    }
}
