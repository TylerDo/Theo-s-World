using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordParticles : MonoBehaviour
{
  public ParticleSystem particleSystem; // The particle system attached to the sword

  public void EnableParticles()
  {
    // Enable emission from the particle system
    var emission = particleSystem.emission;
    emission.enabled = true;
  }

  public void DisableParticles()
  {
    // Disable emission from the particle system
    var emission = particleSystem.emission;
    emission.enabled = false;
  }
}