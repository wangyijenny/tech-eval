using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Primary entry point for the application.
/// </summary>
public class ApplicationManager : MonoBehaviour
{
    [SerializeField] private PositionDataReader _positionDataReader;
    [SerializeField] private CubeMovementController _cubeMovementController;

    private void Start()
    {
        var data = _positionDataReader.ReadPositionData();
        Array.Sort(data, (a, b) => a.RelativeTimestamp.CompareTo(b.RelativeTimestamp));
        //Array.Sort(data, SortPositionData);

        _cubeMovementController.SetPositionData(data);
        _cubeMovementController.SetMovementEnabled(true);
    }

    private int SortPositionData(PositionData a, PositionData b){
        if (a.RelativeTimestamp > b.RelativeTimestamp){
            return 1;
        } else if (a.RelativeTimestamp < b.RelativeTimestamp){
            return -1;
        } else {
            return 0;
        }
    }
}
