using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateLimiter : MonoBehaviour
{
    public int targetFrameRate = 60;  // Set your desired frame rate here

    void Start()
    {
        // Set the frame rate limit
        Application.targetFrameRate = targetFrameRate;
    }
}
