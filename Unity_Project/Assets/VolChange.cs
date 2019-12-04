using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolChange : MonoBehaviour
{
    //Mixer and Slider being used to change volume
    public AudioMixer audioMixer;
    public Slider Slide;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Vol", volume);
    }
}
