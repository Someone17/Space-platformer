using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioVolume : MonoBehaviour
{
    public AudioMixer group;
    public string floatParam = "MyExposedParam";

    public void ChangeValue(float f) {
        
        group.SetFloat(floatParam, f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
