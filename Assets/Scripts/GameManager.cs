using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float masterListenerVolume;

    // Start is called before the first frame update
    void Start()
    {
        masterListenerVolume = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMasterListenerVolume(float volume)
    {
        masterListenerVolume = volume;
    }

    public float GetMasterListenerVolume()
    {
        return masterListenerVolume;
    }
}
