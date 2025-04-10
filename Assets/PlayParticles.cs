using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticles : MonoBehaviour
{
    public ParticleSystem parti;
    public void PlayTheParticles()
    {
        parti.Play();
    }
}
