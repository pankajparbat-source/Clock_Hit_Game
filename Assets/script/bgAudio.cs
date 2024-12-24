using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bgAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Slider slider;

    private void Start()
    {
        slider.value = audioSource.volume;
    }
    private void Update()
    {

    }
    public void musicVolume()
    {
        float volume = slider.value;
        audioSource.volume = volume;
    }
    public void muteUnmute()
    {
        audioSource.mute = !audioSource.mute;
    }
}

