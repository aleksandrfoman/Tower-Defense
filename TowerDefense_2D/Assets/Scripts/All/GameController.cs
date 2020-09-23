using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Waypoints _waypointsScripts;
    private PlayerStats _playerStats;

    private void Awake()
    {
        _playerStats = new PlayerStats();
        _waypointsScripts = new Waypoints();
        _waypointsScripts.Init();
        _playerStats.Init();
    }
}
