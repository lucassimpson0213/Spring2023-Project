using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SpaceInteract : MonoBehaviour
{
    public Color hoverColor;

    private GameObject turret;

    private Renderer render;
    private Color startColor;

    StateController currentState;

    private void Awake()
    {
        currentState = GameObject.Find("StateController").GetComponent<StateController>();
    }

    private void Start()
    {
        render = GetComponent<Renderer>();
        startColor = render.material.color;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Can't build there!");
            return;
        }

        //Build a turret

        if (currentState.state == 1 && !GetComponent<TowerHealth>())
        {
            GameObject TurretToBuild = BuildManager.instance.GetTurretToBuild();
            turret = Instantiate(TurretToBuild, transform.position, transform.rotation);
            Destroy(gameObject);
            Debug.Log(turret);
        }
        
        //Sell a turret
        if (currentState.state == 2 & GetComponent<TowerHealth>())
        {
            Destroy(gameObject);
        }
    }

    void OnMouseEnter()
    { 
        render.material.color = hoverColor;
        Debug.Log(render.gameObject);
    }

    void OnMouseExit ()
    {
        render.material.color = startColor;
    }
}
