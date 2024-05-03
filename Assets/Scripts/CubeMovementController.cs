using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Controls a cube's position update loop and position data.
/// </summary>
public class CubeMovementController : MonoBehaviour
{
    //[SerializeField] private CubeMovement _cubeMovement;
    
    private bool _isMovementEnabled;

    public GameObject cubePrefab;
    
    public void SetPositionData(List<List<PositionData>> positionData)
    {
        //var positionQueue = positionData != null ? new Queue<PositionData>(positionData) : new Queue<PositionData>();
        //_cubeMovement.SetPositionQueue(positionQueue);

        foreach (List<PositionData> cubeData in positionData){
            GameObject cube = Instantiate(cubePrefab, new Vector3(0, -0.5f, 0), cubePrefab.transform.rotation);
            var positionQueue = cubeData != null ? new Queue<PositionData>(cubeData) : new Queue<PositionData>();
            cube.GetComponent<CubeMovement>().SetPositionQueue(positionQueue);
        }
    }

    public void SetMovementEnabled(bool isMovementEnabled)
    {
        _isMovementEnabled = isMovementEnabled;
    }

    private void Update()
    {
        if (!_isMovementEnabled)
        {
            return;
        }
        
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");
        
        foreach (GameObject cube in cubes){

        cube.GetComponent<CubeMovement>().UpdatePosition();
        }
    }
}
