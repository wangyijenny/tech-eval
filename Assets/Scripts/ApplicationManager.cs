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


    public List<int> uniqueObjectIDs = new List<int>();
    public List<List<PositionData>> dataSortedByObject = new List<List<PositionData>>();

    private void Start()
    {
        var data = _positionDataReader.ReadPositionData();
        Array.Sort(data, (a, b) => a.RelativeTimestamp.CompareTo(b.RelativeTimestamp));
        //Array.Sort(data, SortPositionData);

        // find the unique cubes in the data and create a list of postions for each cube
        foreach (PositionData pos in data)
        {
            // if the ObjectID is unique, add it to a list of unique ids 
            // and add a list in dataSortedByObject for it
            if (!uniqueObjectIDs.Contains( pos.ObjectID))
            {
                uniqueObjectIDs.Add(pos.ObjectID);
                dataSortedByObject.Add(new List<PositionData>());
            }

            // add the position to the appropriate list
            int index = uniqueObjectIDs.IndexOf(pos.ObjectID);
            dataSortedByObject[index].Add(pos);
        }

       _cubeMovementController.SetPositionData(dataSortedByObject);
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
