using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class NoiseMaker : MonoBehaviour
{
    AudioSource aS;
    private void Start()
    {
        aS = GetComponent<AudioSource>();
        this.GetComponentInChildren<TextMeshProUGUI>().text = aS.clip.name;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        aS.Play();
    }
}
