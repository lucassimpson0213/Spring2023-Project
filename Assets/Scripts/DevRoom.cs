using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevRoom : MonoBehaviour
{
    [SerializeField] GameObject tutorial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            tutorial.SetActive(!tutorial.activeInHierarchy);
        }
    }
}
