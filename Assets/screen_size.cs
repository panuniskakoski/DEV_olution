using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjust : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        int height = 2000;
        Camera.main.scaledPixelHeight.Equals(height);

        int width = 4000;
        Camera.main.scaledPixelWidth.Equals(width);
    }
}