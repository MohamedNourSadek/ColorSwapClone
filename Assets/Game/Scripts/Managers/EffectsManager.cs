using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class EffectsManager
{
    [SerializeField] ParticleSystem CelebrationParticleSystem;

    public void PlayCelebrationEffect()
    {
        CelebrationParticleSystem.Play();
    }
}
