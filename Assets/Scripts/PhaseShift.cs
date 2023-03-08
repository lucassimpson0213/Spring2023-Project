using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseShift : MonoBehaviour
{
    private bool activePhase; //True if in active phase, False if in setup
    public bool enemiesRemain; //True if there are still enemies, false if there are no enemies
    public bool skip; //True if skip setup button is pressed, false otherwise
    [SerializeField] float setupTime;
    

    // Start is called before the first frame update
    void Start()
    {
        activePhase = false;    //Start in setup phase im guessing...
        setupTime = 100; //Random value for testing
        StartCoroutine(setupWait());
    }

    // Update is called once per frame
    void Update()
    {

        /*
         * if(skipButton is pressed && activePhase = false)
         * {
         *      activePhase = true;
         *      setupTime = 100;
         *      StartCoroutine(setupWait());
         *      
         * }
         *      
         */
        if (activePhase)
        {
            if(!enemiesRemain)
            {
                activePhase = false;
                setupTime = 100;
                StartCoroutine(setupWait());
            }
        }
    }
    public bool isActivePhase()
    {
        return activePhase;
    }
    IEnumerator setupWait()
    {
        yield return new WaitForSeconds(setupTime);
        activePhase = true;
        
    }

}
