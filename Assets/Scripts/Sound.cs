using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public GameObject SoundPrefab;
    public float DestroyTime;
    private bool Spawn;
    // Start is called before the first frame update
    void Start()
    {
        Spawn = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnSound(string SFXPlay)
    {
        switch (SFXPlay)
        {
            case "Shoot":
                GameObject sfx = Instantiate(SoundPrefab);
                Destroy(sfx, DestroyTime);
                break;
            case "Footstep":
                break;
        }

    }
}
