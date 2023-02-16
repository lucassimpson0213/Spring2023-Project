using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceInteract : MonoBehaviour
{
    public Color hoverColor;

    private GameObject turret;

    private Renderer render;
    private Color startColor;

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
        }

        //Build a turret

        GameObject TurretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(TurretToBuild, transform.position, transform.rotation);
    }

    void OnMouseEnter ()
    {
        render.material.color = hoverColor;
    }

    void OnMouseExit ()
    {
        render.material.color = startColor;
    }
}
