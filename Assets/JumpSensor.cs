﻿using UnityEngine;
using System.Collections;
public class JumpSensor : MonoBehaviour
{

    public int TouchedCount = 0;
    void OnTriggerEnter(Collider other)
    {
        TouchedCount++;
    }
    void OnTriggerExit(Collider other)
    {
        TouchedCount--;
    }
    public bool IsCanJump()
    {
        return TouchedCount > 0;
    }
}