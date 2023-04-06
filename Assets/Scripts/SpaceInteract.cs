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

    public int condition;
    // condition 0 = can build
    // condition 1 = cannot build

    private void Awake()
    {
        currentState = GameObject.Find("StateController").GetComponent<StateController>();
    }

    private void Start()
    {
        render = GetComponent<Renderer>();
        startColor = render.material.color;

        condition = 0;
    }

    private void OnMouseDown()
    {
        if (currentState.state == 1)
        {
            Debug.Log("Can't build there!");
            return;
        }
        
        //Sell a turret
        if (currentState.state == 2 & GetComponent<TowerHealth>())
        {
            Destroy(gameObject);
        }
    }

    void OnMouseEnter()
    {
        BuildManager.instance.SetCondition(1);

        Debug.Log("Tower");
    }

    void OnMouseExit ()
    {
        BuildManager.instance.SetCondition(0);
    }
}
