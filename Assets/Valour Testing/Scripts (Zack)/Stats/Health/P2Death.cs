﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Death : MonoBehaviour
{
    // HealthLoss Script.
    // Add to enemies so that when they collide with/hit the palyer, the player will lose health.


    void OnTriggerEnter(Collider collider)
    {
        GameControlScript.p2Health -= 1;
    }
}