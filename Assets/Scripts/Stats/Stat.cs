using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    public double baseValue;

    public double GetValue()
    {
        return baseValue;
    }
}
