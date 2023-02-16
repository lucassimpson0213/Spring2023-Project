using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one BuildManager in scene!");
        }
        
        instance = this;
    }

    public GameObject GroundEnemyprefab;

    private void Start()
    {
        TurretToBuild = GroundEnemyprefab;
    }

    private GameObject TurretToBuild;

    public GameObject GetTurretToBuild ()
    {
        return TurretToBuild;
    }
}
