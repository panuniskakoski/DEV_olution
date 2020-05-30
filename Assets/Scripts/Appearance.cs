using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appearance : MonoBehaviour
{


    public void Start()
    {
        this.GetComponent<Renderer>().enabled = false;
    }

}
