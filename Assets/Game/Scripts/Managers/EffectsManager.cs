using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EffectsManager : MonoBehaviour
{
    #region Public Variables
    public static EffectsManager Instance;
    public ParticleSystem CelebrationParticleSystem;
    #endregion

    #region Unity Delegates
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    #region Public Variables
    public void PlayCelebrationEffect()
    {
        CelebrationParticleSystem.Play();
    }
    #endregion
}
