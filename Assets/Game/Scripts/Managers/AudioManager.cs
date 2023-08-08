using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour 
{
    public static AudioManager Instance;

    #region Public Variables
    public AudioClip SwapAudioClip;
    public AudioClip CeleberationAudioClip;
    
    public float SwapAudioVolume;
    public float CeleberationVolume;
    #endregion

    #region Unity Delegates
    private void Awake()
    {
        Instance = this;
    }
    #endregion


    #region Public Variables
    public void PlaySwapSound()
    {
        AudioSource.PlayClipAtPoint(SwapAudioClip, Camera.main.transform.position, SwapAudioVolume);
    }
    public void PlayCeleberationSound()
    {
        AudioSource.PlayClipAtPoint(CeleberationAudioClip, Camera.main.transform.position, CeleberationVolume);
    }
    #endregion
}
