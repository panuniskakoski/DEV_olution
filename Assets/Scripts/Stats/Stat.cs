using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    public float baseValue;

    public float GetValue()
    {
        return baseValue;
    }
}
