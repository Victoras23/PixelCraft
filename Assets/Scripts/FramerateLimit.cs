using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramerateLimit : MonoBehaviour
{
    public enum FPSlimits
    {
        FPS30 = 30,
        FPS60 = 60,
        FPS90 = 90,
        FPS120 = 120,
    }

    public FPSlimits limit;

    void Awake()
    {
        Application.targetFrameRate = (int)limit;
    }
}
