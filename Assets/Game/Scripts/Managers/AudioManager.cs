using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioManager
{
    public AudioClip SwapAudioClip;
    public AudioClip CeleberationAudioClip;
    
    public float SwapAudioVolume;
    public float CeleberationVolume;


    public void PlaySwapSound()
    {
        AudioSource.PlayClipAtPoint(SwapAudioClip, Camera.main.transform.position, SwapAudioVolume);
    }
    public void PlayCeleberationSound()
    {
        AudioSource.PlayClipAtPoint(CeleberationAudioClip, Camera.main.transform.position, CeleberationVolume);
    }



}
