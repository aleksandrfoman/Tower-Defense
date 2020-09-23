using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints
{
    public static Transform[] points; //Array waypoints
    private GameObject _waypoints;
    public void Init()
    {
        _waypoints = GameObject.Find("WayPoints");

        points = new Transform[_waypoints.transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = _waypoints.transform.GetChild(i);
        }
    }
}
