using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    // build state = 1
    // sell state = 2
    // attack state = 0

    public int state;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.LeftShift))
       {
            state++;
            state %= 3;
       };
    }
}
