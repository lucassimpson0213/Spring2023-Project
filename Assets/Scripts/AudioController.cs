using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    GameObject gm;
    Slider volumeSlider;

    public void Awake()
    {
        gm = GameObject.Find("GameManager");
        volumeSlider = GetComponent<Slider>();
        volumeSlider.value = gm.GetComponent<GameManager>().GetMasterListenerVolume();
    }

    public void SetVolume(float newVolume)
    {
        gm.GetComponent<GameManager>().SetMasterListenerVolume(newVolume);
        AudioListener.volume = newVolume;
        //Debug.Log("Volume = " + AudioListener.volume);
    }
}
