using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float masterListenerVolume;

    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

        // Start is called before the first frame update
    void Start()
    {
        masterListenerVolume = 1f;
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
