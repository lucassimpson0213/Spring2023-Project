using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUI : MonoBehaviour
{
    public bool buildMode;
    public int towerSelector;
    public GameObject towerBar;
    public GameObject[] outlineLocations;
    public GameObject highlight;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if build mode is active, instantiate the tower bar animation and pull it up

        if (buildMode == true)
        {
            towerBar.gameObject.SetActive(true);
        }
        else
        {
            towerBar.gameObject.SetActive(false);
        }

        //if towerSelector is equal to any of the towers corresponding numbers, switch the highlighted/selected tower

        highlight.transform.position = outlineLocations[towerSelector].transform.position;

    }
}
