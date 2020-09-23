using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Waypoints _waypointsScripts;

    private void Awake()
    {
        _waypointsScripts = new Waypoints();
        _waypointsScripts.Init();
    }
}
